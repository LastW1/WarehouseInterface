using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WarehouseInterface.Db.Repositories;
using WarehouseInterface.Dtos;
using WarehouseInterface.Managers;
using WarehouseInterface.Repositories;

namespace WarehouseInterface.Pages
{
    public partial class SearchItemPage : Window
    {
        private string _searchCategory = null;
        private string _searchName = null;

        private OrderPage _orderPage;
        private SupplyPage _supplyPage;
        private ItemRepository _itemRepository;
        private RootManager _rootManager;
        private ReturnPage _returnPage;

        public ObservableCollection<ItemDto> _dataGridCollection;
        public SearchItemPage(SupplyPage supplyPage)
        {
            _supplyPage = supplyPage;
            _supplyPage._isSearchAlive = true;

            BaseConstructor();
        }

        public SearchItemPage(OrderPage orderPage)
        {
            _orderPage = orderPage;
            _orderPage._isSearchAlive = true;

            BaseConstructor();
        }

        public SearchItemPage(ReturnPage returnPage)
        {
            _returnPage = returnPage;
            _returnPage._isSearchAlive = true;

            BaseConstructor();
        }

        public void BaseConstructor()
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
            _rootManager.RootFromToWindowOnTop(new DetailsPage(itemId));
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
                if (_orderPage != null)
                {
                    _orderPage.AddItems(selectedItems);
                }
                else if(_supplyPage != null)
                {
                    _supplyPage.AddItems(selectedItems);
                }
                else if (_returnPage != null)
                {
                    _returnPage.AddItems(selectedItems);
                }
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if(_orderPage != null)
            {
                _orderPage._isSearchAlive = false;
                _rootManager.TerminateWindow(this);
            }
            else if (_supplyPage != null)
            {
                _supplyPage._isSearchAlive = false;
                _rootManager.TerminateWindow(this);
            }
            else if (_returnPage != null)
            {
                _returnPage._isSearchAlive = false;
                _rootManager.TerminateWindow(this);
            }

        }
    }
}
