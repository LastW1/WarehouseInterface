using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WarehouseInterface.Dtos;
using WarehouseInterface.Managers;
using WarehouseInterface.Repositories;

namespace WarehouseInterface.Pages
{
    public partial class ItemTransactionHistoryPage : Window
    {
        private RootManager _rootManager;
        private TransactionManager _transactionManager;

        private int _itemId;

        public ObservableCollection<ItemTransactionViewDto> _dataGridCollection;
        public ItemTransactionHistoryPage(int itemId)
        {
            _itemId = itemId;

            var context = new DatabaseContext();
            _transactionManager = new TransactionManager(context);
            _rootManager = new RootManager();

            InitializeComponent();
            DataGridGenerator();
        }

        private void DataGridGenerator()
        {
            _dataGridCollection = new ObservableCollection<ItemTransactionViewDto>();

            var items = _transactionManager.GetItemTransactions(_itemId);

            foreach (var item in items)
            {
                _dataGridCollection.Add(item);
            }

            _dataGridCollection.OrderBy(a => a.Date);

            TestDataGrid.ItemsSource = _dataGridCollection;
            TestDataGrid.Items.Refresh();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            _rootManager.TerminateWindow(this);
        }

        private void DetailsButton_Click(object sender, RoutedEventArgs e)
        {
            var transactionId = (int)((Button)sender).CommandParameter;
            _rootManager.RootFromToWindowOnTop(new TransactionDetailsPage(transactionId));
        }
    }
}
