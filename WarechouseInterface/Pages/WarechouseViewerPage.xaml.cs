using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
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
using WarechouseInterface.Db.Repositories;
using WarechouseInterface.DbDtos;
using WarechouseInterface.Repositories;

namespace WarechouseInterface.Pages
{
    /// <summary>
    /// Interaction logic for WarechouseViewerPage.xaml
    /// </summary>
    public partial class WarechouseViewerPage : Window
    {
        private ItemRepository _itemRepository;

        public ObservableCollection<ItemDbDto> DataGridCollection = new ObservableCollection<ItemDbDto>();
        public WarechouseViewerPage()
        {
            var context = new DatabaseContext();
            _itemRepository = new ItemRepository(context);

            InitializeComponent();

            DataGridGenerator();
        }

        private void DataGridGenerator()
        {
            //_itemRepository.SetImage();

            var items = _itemRepository.GetItems().ToList();

            foreach (var item in items)
            {
                DataGridCollection.Add(item);
            }

            TestDataGrid.ItemsSource = DataGridCollection;
            //  TestDataGrid.Items.Refresh();

        }

        private void Details_Click(object sender, RoutedEventArgs e)
        {
            var itemId = (int)((Button)sender).CommandParameter;
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            var itemId = (int)((Button)sender).CommandParameter;
        }
    }
}
