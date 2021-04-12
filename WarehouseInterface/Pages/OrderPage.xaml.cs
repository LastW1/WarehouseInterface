using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WarehouseInterface.Db.DbDtos;
using WarehouseInterface.Db.Repositories;
using WarehouseInterface.Dtos;
using WarehouseInterface.Managers;
using WarehouseInterface.Repositories;
using WarehouseInterface.Validators;

namespace WarehouseInterface.Pages
{
    // większość tego kodu do managera
    public partial class OrderPage : Window
    {
        public bool _isSearchAlive = false;
        public List<int> _selectedItems = new List<int>();
        public List<CountValueDto> _countValue = new List<CountValueDto>();

        public ObservableCollection<ItemDto> _dataGridCollection;

        private WarehouseViewerPage _warehouseViewerPage;

        private ItemRepository _itemRepository;
        private TransactionManager _transactionManager;
        private RootManager _rootManager;

        public OrderPage(WarehouseViewerPage warehouseViewerPage)
        {
            _warehouseViewerPage = warehouseViewerPage;

            var context = new DatabaseContext();
            _itemRepository = new ItemRepository(context);
            _transactionManager = new TransactionManager(context);
            _rootManager = new RootManager();

            InitializeComponent();
        }

        public void DataGridGenerator()
        {
            _dataGridCollection = new ObservableCollection<ItemDto>();

            var items = _itemRepository.GetItemsByIds(_selectedItems).ToList();

            foreach (var item in items)
            {
                var countValue = _countValue.FirstOrDefault(a => a.ItemId == item.Id);
                if(countValue != null)
                {
                    item.Count = countValue.Count;
                    item.Price = countValue.SingleValue;
                }

                _dataGridCollection.Add(item);
            }

            TestDataGrid.ItemsSource = _dataGridCollection;
            TestDataGrid.Items.Refresh();
        }

        public void AddItems(IEnumerable<int> ids)
        {
            ids = ids.Where(a => !_selectedItems.Contains(a));

            foreach(var id in ids)
            {
                var item = _itemRepository.GetItemById(id);

                var countValue = new CountValueDto
                {
                    ItemId = item.Id,
                    SingleValue = item.Price.GetValueOrDefault(),
                    Count = 1
                };
                _countValue.Add(countValue);
            }
            _selectedItems.AddRange(ids);
            DataGridGenerator();
        }

        private void SelectItemButton_Click(object sender, RoutedEventArgs e)
        {
            if (_isSearchAlive)
            {
                MessageBox.Show("Wyszukiwarka już jest otwarta");
                return;
            }
            _rootManager.RootFromToWindowOnTop(new SearchItemPage(this));
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            if (_isSearchAlive)
            {
                MessageBox.Show("Najpierw zamknij wyszukiwarkę");
                return;
            }

            _warehouseViewerPage.DataGridGenerator();
            _warehouseViewerPage.Show();
            _rootManager.TerminateWindow(this);
        }

        private void AddOrderButton_Click(object sender, RoutedEventArgs e)
        {
            //dorobić validator

            var items = new List<TransactionItemsDbDto>();

            foreach(var countValue in _countValue)
            {
                var item = new TransactionItemsDbDto
                {
                    ItemId = countValue.ItemId,
                    Count = countValue.Count,
                    SinglePrice = countValue.SingleValue
                };

                items.Add(item);
            }

            var transaction = new FullTransactionDto
            {
                Describe = OrdetTextBox.Text,
                Items = items
            };

            _transactionManager.AddOrderTransaction(transaction);

            MessageBox.Show("Pomyślnie dodano zamówienie");

            if (_isSearchAlive)
            {
                MessageBox.Show("Najpierw zamknij wyszukiwarkę");
                return;
            }

            _warehouseViewerPage.DataGridGenerator();
            _warehouseViewerPage.Show();
            _rootManager.TerminateWindow(this);
        }

        private void CalculateSum_Click(object sender, RoutedEventArgs e)
        {
            DataGridGenerator();

            decimal sum = 0;
            foreach(var item in _countValue)
            {
                sum += item.Count * item.SingleValue;
            }
          
            SumTextBlock.Text = $"Suma:{Math.Round(sum, 2)}";
        }

        private void CountLabel_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = (TextBox)sender;

            var givenCount = 0;
            if (!textBox.Text.Equals("") && !int.TryParse(textBox.Text, out givenCount))
            {
                MessageBox.Show("Niepoprawny format danej ilości!");
                return;
            }

            var item = _countValue.First(a => a.ItemId == int.Parse(textBox.Uid));

            _countValue.Remove(item);

            var actualPrice = item.Count * item.SingleValue;
            item.Count = givenCount;

            _countValue.Add(item);
        }

        private void PriceLabel_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = (TextBox)sender;

            decimal givenPrice = 0;
            if (!textBox.Text.Equals("") && !decimal.TryParse(textBox.Text.Replace('.',','), out givenPrice))
            {
                MessageBox.Show("Niepoprawny format danej ceny!");
                return;
            }

            var item = _countValue.First(a => a.ItemId == int.Parse(textBox.Uid));

            _countValue.Remove(item);

            item.SingleValue = givenPrice;

            _countValue.Add(item);
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            TextBoxValidator.NumberValidationTextBox(e);
        }

        private void DecimalValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            TextBoxValidator.DecimalValidationTextBox(sender, e);
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var itemId = int.Parse(button.Uid);
            _selectedItems.Remove(itemId);

            var countValie = _countValue.First(a => a.ItemId == itemId);
            _countValue.Remove(countValie);

            DataGridGenerator();
        }
    }
}
