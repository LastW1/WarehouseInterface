using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WarehouseInterface.Db.Repositories;
using WarehouseInterface.Dtos;
using WarehouseInterface.Managers;
using WarehouseInterface.Repositories;

namespace WarehouseInterface.Pages
{
    /// <summary>
    /// Interaction logic for TransactionDetailsPage.xaml
    /// </summary>
    public partial class TransactionDetailsPage : Window
    {
        private int _transactionId;
        private RootManager _rootManager;
        private TransactionManager _transactionManager;
        private TransactionItemsRepository _transactionItemsRepository;

        public ObservableCollection<TransactionItemViewDto> _dataGridCollection;

        public TransactionDetailsPage(int transactionId)
        {
            _transactionId = transactionId;

            _rootManager = new RootManager();

            var context = new DatabaseContext();
            _transactionManager = new TransactionManager(context);
            _transactionItemsRepository = new TransactionItemsRepository(context);

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
