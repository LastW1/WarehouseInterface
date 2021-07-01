using System.Collections.ObjectModel;
using System.Windows;
using WarehouseInterface.Dtos;
using WarehouseInterface.Managers;
using WarehouseInterface.Repositories;

namespace WarehouseInterface.Pages
{
    public partial class TransactionDetailsPage : Window
    {
        private int _transactionId;
        private RootManager _rootManager;
        private TransactionManager _transactionManager;

        public ObservableCollection<TransactionItemViewDto> _dataGridCollection;

        public TransactionDetailsPage(int transactionId)
        {
            _transactionId = transactionId;

            _rootManager = new RootManager();

            var context = new DatabaseContext();
            _transactionManager = new TransactionManager(context);

            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            var items = _transactionManager.GetItemsForTransaction(_transactionId);

            var transactionDetails = _transactionManager.GetTransactionView(_transactionId);

            TypeTextBlock.Text = transactionDetails.Type;
            DateTextBlock.Text = transactionDetails.Date.ToString();
            SumTextBlock.Text = transactionDetails.Worth.ToString();
            DescriptionTextBox.Text = transactionDetails.Describe;

            _dataGridCollection = new ObservableCollection<TransactionItemViewDto>();

            foreach (var item in items)
            {
                _dataGridCollection.Add(item);
            }

            TestDataGrid.ItemsSource = _dataGridCollection;
            TestDataGrid.Items.Refresh();
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            _rootManager.TerminateWindow(this);
        }
    }
}
