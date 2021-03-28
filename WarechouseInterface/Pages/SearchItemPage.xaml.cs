using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WarechouseInterface.Db.Repositories;
using WarechouseInterface.Dtos;
using WarechouseInterface.Managers;
using WarechouseInterface.Repositories;

namespace WarechouseInterface.Pages
{
    public partial class SearchItemPage : Window
    {
        private string _searchCategory = null;
        private string _searchName = null;

        private OrderPage _orderPage;
        private ItemRepository _itemRepository;
        private RootManager _rootManager;

        public ObservableCollection<ItemDto> _dataGridCollection;
        public SearchItemPage(OrderPage orderPage)
        {
            _orderPage = orderPage;

            var context = new DatabaseContext();
            _itemRepository = new ItemRepository(context);
            _rootManager = new RootManager();
            InitializeComponent();
            DataGridGenerator();

            _orderPage._isSearchAlive = true;
        }

        public void DataGridGenerator()
        {
            _dataGridCollection = new ObservableCollection<ItemDto>();

            var items = _itemRepository.GetItemsByNameAndCategory(_searchCategory, _searchName).ToList();

            foreach (var item in items)
            {
                _dataGridCollection.Add(item);
            }

            TestDataGrid.ItemsSource = _dataGridCollection;
            TestDataGrid.Items.Refresh();
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

        private void Details_Click(object sender, RoutedEventArgs e)
        {
            var itemId = (int)((Button)sender).CommandParameter;
        }

        private void SelectItemButton_Click(object sender, RoutedEventArgs e)
        {
            List<int> selectedItems = new List<int>();

            foreach(var item in TestDataGrid.SelectedItems)
            {
                selectedItems.Add(((ItemDto)item).Id);
            };  

            if(selectedItems.Count > 0)
            {
                _orderPage.AddItems(selectedItems);
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            _orderPage._isSearchAlive = false;
            _rootManager.TerminateWindow(this);
        }
    }
}
