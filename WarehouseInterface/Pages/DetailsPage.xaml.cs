using System.Collections.Generic;
using System.Linq;
using System.Windows;
using WarehouseInterface.Db.Repositories;
using WarehouseInterface.Managers;
using WarehouseInterface.Repositories;

namespace WarehouseInterface.Pages
{
    public partial class DetailsPage : Window
    {
        private int _itemId;

        private RootManager _rootManager;
        private ItemRepository _itemRepository;
        public DetailsPage(int itemId)
        {
            _itemId = itemId;

            var context = new DatabaseContext();
            _itemRepository = new ItemRepository(context);
            _rootManager = new RootManager();

            InitializeComponent();
            LoadItemData();
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            _rootManager.TerminateWindow(this);
        }

        private void LoadItemData()
        {
            var item = _itemRepository.GetItemsByIds(new List<int>() { _itemId }).FirstOrDefault();

            if(item.Picture != null)
            {
                PictureImage.Source = ImageManager.ByteToImage(item.Picture);
            }
            
            NameTextBlock.Text = item.Name;
            CategoryTextBlock.Text = item.Category;
            CountTextBlock.Text = item.Count.ToString();
            PriceTextBlock.Text = item.Price.ToString();
            DescribeTextBlock.Text = item.Describe;
            LocalisationTextBlock.Text = item.Location;
            AdditionalInfoTextBlock.Text = item.AdditionalInfo;
            MinAllertTextBlock.Text = item.MinAllert == null ? "" : item.MinAllert.ToString();
            MaxAllertTextBlock.Text = item.MaxAllert == null ? "" : item.MaxAllert.ToString();
        }

        private void HistoryButton_Click(object sender, RoutedEventArgs e)
        {
            _rootManager.RootFromToWindowOnTop(new ItemTransactionHistoryPage(_itemId));
        }
    }
}
