using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WarechouseInterface.Db.Repositories;
using WarechouseInterface.Repositories;
using WarechouseInterface.Dtos;
using WarechouseInterface.Managers;

namespace WarechouseInterface.Pages
{
    public partial class WarechouseViewerPage : Window
    {
        private ItemRepository _itemRepository;
        private RootManager _rootManager;

        public ObservableCollection<ItemDto> _dataGridCollection;
        public WarechouseViewerPage()
        {
            var context = new DatabaseContext();
            _itemRepository = new ItemRepository(context);

            _rootManager = new RootManager();

            InitializeComponent();

            DataGridGenerator();
        }
        public void DataGridGenerator()
        {
            _dataGridCollection = new ObservableCollection<ItemDto>();
            var items = _itemRepository.GetItems().ToList();

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
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            var itemId = (int)((Button)sender).CommandParameter;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            _rootManager.RootFromToWindowOnTop(new AddItemPage(this));
        }
    }
}
