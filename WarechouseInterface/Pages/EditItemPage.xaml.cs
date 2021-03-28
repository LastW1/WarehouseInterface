using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WarechouseInterface.Db.DbDtos;
using WarechouseInterface.Db.Repositories;
using WarechouseInterface.Managers;
using WarechouseInterface.Repositories;
using WarechouseInterface.Validators;

namespace WarechouseInterface.Pages
{
    // zrobić szersze okna dla opisów z zawijaniem
    public partial class EditItemPage : Window
    {
        public ObservableCollection<CategoryDbDto> _comboCollection { get; set; }

        private bool _isImageChanged = false;
        private int _itemId;
        private WarechouseViewerPage _warechouseViewWindow;
        private CategoryRepository _categoryRepository;
        private CategoryManager _categoryManager;
        private RootManager _rootManager;

        private readonly ItemRepository _itemRepository;

        public EditItemPage(WarechouseViewerPage warechouseViewWindow, int itemId)
        {
            _warechouseViewWindow = warechouseViewWindow;

            _itemId = itemId;

            var context = new DatabaseContext();
            _itemRepository = new ItemRepository(context);
            _categoryRepository = new CategoryRepository(context);
            _categoryManager = new CategoryManager(context);
            _rootManager = new RootManager();

            InitializeComponent();

            GenerateFields();

            DataContext = this;
        }

        private void GenerateFields()
        {
            var item = _itemRepository.GetItemById(_itemId);

            ReloadCategoryCollection(item.CategoryId);

            NameTextBox.Text = item.Name;

            if (item.Picture != null)
            {
                ImageButtonImage.Source = ImageManager.ByteToImage(item.Picture);
            }

            CountTextBox.Text = item.Count.ToString();

            PriceTextBox.Text = item.Price.ToString();

            DescrieTextBox.Text = item.Describe;

            LocationTextBox.Text = item.Location;

            AdditionalInfoTextBox.Text = item.AdditionalInfo;

            MinAllertTextBox.Text = item.MinAllert.ToString();

            MaxAllertTextBox.Text = item.MaxAllert.ToString();
        }

        public void ReloadCategoryCollection(int categoryId)
        {
            _comboCollection = _categoryManager.LoadCategoryCombo();

            CategoryComboBox.ItemsSource = _comboCollection;

            CategoryComboBox.SelectedItem = _comboCollection.FirstOrDefault(a => a.Id == categoryId);
        }

        private void ImageButton_Click(object sender, RoutedEventArgs e)
        {
            if (ImageManager.OnClickImageLoad(ref ImageButtonImage))
            {
                _isImageChanged = true;
            }
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            _rootManager.TerminateWindow(this);
        }

        private void DeleteBuddton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Czy na pewno chcesz usunąć ten produkt?","Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                _itemRepository.RemoveItem(_itemId);

                _warechouseViewWindow.DataGridGenerator();
                _rootManager.TerminateWindow(this);
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (ItemValidator.ValidateItem(CategoryComboBox, NameTextBox, ref PriceTextBox, CountTextBox, MinAllertTextBox, MaxAllertTextBox, ref ImageButtonImage))
            {
                var item = new ItemDbDto
                {
                    Id = _itemId,
                    CategoryId = (int)CategoryComboBox.SelectedValue,
                    Name = NameTextBox.Text,
                    Price = decimal.Parse(PriceTextBox.Text),
                    Count = int.Parse(CountTextBox.Text),
                    Describe = DescrieTextBox.Text,
                    Location = LocationTextBox.Text,
                    AdditionalInfo = AdditionalInfoTextBox.Text,
                    MinAllert = MinAllertTextBox.Text.Equals("") ? null : (int?)int.Parse(MinAllertTextBox.Text),
                    MaxAllert = MaxAllertTextBox.Text.Equals("") ? null : (int?)int.Parse(MaxAllertTextBox.Text)
                };

                if (_isImageChanged)
                {
                    item.Picture = ImageManager.ImageToByte(ImageButtonImage);
                }

                _itemRepository.EditItem(item, _isImageChanged);

                _warechouseViewWindow.DataGridGenerator();
                _rootManager.TerminateWindow(this);
            }
        }

        private void CategoryAddButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            TextBoxValidator.NumberValidationTextBox(e);
        }

        private void DecimalValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            TextBoxValidator.DecimalValidationTextBox(sender,e);
        }
    }
}
