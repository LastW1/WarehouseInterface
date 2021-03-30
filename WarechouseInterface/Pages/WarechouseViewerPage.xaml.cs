using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WarechouseInterface.Db.Repositories;
using WarechouseInterface.Repositories;
using WarechouseInterface.Dtos;
using WarechouseInterface.Managers;
using System.Collections.Generic;

namespace WarechouseInterface.Pages
{
    public partial class WarechouseViewerPage : Window
    {
        private bool _isAllertView = false;
        private string _searchCategory = null;
        private string _searchName = null;

        private SettingsPage _settingsPage;
        private ItemRepository _itemRepository;
        private RootManager _rootManager;

        public ObservableCollection<ItemDto> _dataGridCollection;
        public WarechouseViewerPage(SettingsPage settingsPage)
        {
            _settingsPage = settingsPage;

            var context = new DatabaseContext();
            _itemRepository = new ItemRepository(context);

            _rootManager = new RootManager();
        
            InitializeComponent();

            DataGridGenerator();
        }
        public void DataGridGenerator()
        {
            _dataGridCollection = new ObservableCollection<ItemDto>();

            List<ItemDto> items;

            if (_isAllertView)
            {
                items = _itemRepository.GetAllertItemsBynameAndCategory(_searchCategory, _searchName).ToList();
            }
            else
            {
                items = _itemRepository.GetItemsByNameAndCategory(_searchCategory, _searchName).ToList();
            }       

            foreach (var item in items)
            {
                _dataGridCollection.Add(item);
            }

            TestDataGrid.ItemsSource = _dataGridCollection;
            TestDataGrid.Items.Refresh();
        }

        private void Details_Click(object sender, RoutedEventArgs e)
        {
            var itemId = (int)((Button)sender).CommandParameter;
            _rootManager.RootFromToWindowOnTop(new DetailsPage(itemId));
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            var itemId = (int)((Button)sender).CommandParameter;
            _rootManager.RootFromToWindowOnTop(new EditItemPage(this, itemId));
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            _rootManager.RootFromToWindowOnTop(new AddItemPage(this));
        }

        private void CategoryTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _searchCategory = CategoryTextBox.Text;
            DataGridGenerator();
        }

        private void NameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _searchName = NameTextBox.Text;
            DataGridGenerator();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            _rootManager.CloseFromShowTo(this, _settingsPage);
        }

        private void ZamowienieButton_Click(object sender, RoutedEventArgs e)
        {
            _rootManager.RootFromTo(this, new OrderPage(this));
        }

        private void SupplyButton_Click(object sender, RoutedEventArgs e)
        {
            _rootManager.RootFromTo(this, new SupplyPage(this));
        }

        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            _rootManager.RootFromTo(this, new ReturnPage(this));
        }

        private void AllertButton_Click(object sender, RoutedEventArgs e)
        {
            _isAllertView = !_isAllertView;
            if (_isAllertView)
            {
                AllertButton.Background = System.Windows.Media.Brushes.Red;
            }
            else
            {
                AllertButton.Background = System.Windows.Media.Brushes.LightGray;
            }
           
            DataGridGenerator();
        }

        private void HistoryButton_Click(object sender, RoutedEventArgs e)
        {
            _rootManager.RootFromToWindowOnTop(new TransactionHistoryPage());
        }
    }
}
