using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using WarechouseInterface.Dtos;
using WarechouseInterface.Managers;
using WarechouseInterface.Repositories;

namespace WarechouseInterface.Pages
{
    public partial class TransactionHistoryPage : Window
    {
        private RootManager _rootManager;
        private TransactionManager _transactionManager;

        public ObservableCollection<TransactionViewDto> _dataGridCollection;
        public TransactionHistoryPage()
        {
            var context = new DatabaseContext();
            _transactionManager = new TransactionManager(context);
            _rootManager = new RootManager();

            InitializeComponent();
            DataGridGenerator();
        }

        private void DataGridGenerator()
        {
            _dataGridCollection = new ObservableCollection<TransactionViewDto>();

            var items = _transactionManager.GetAllTransactions();

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

        }
    }
}
