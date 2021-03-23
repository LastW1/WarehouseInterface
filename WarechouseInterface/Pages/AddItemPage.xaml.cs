using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using WarechouseInterface.Db.DbDtos;
using WarechouseInterface.Db.Repositories;
using WarechouseInterface.Managers;
using WarechouseInterface.Repositories;
using WarechouseInterface.Validators;

namespace WarechouseInterface.Pages
{
    public partial class AddItemPage : Window
    {
        private ItemRepository _itemRepository;
        private RootManager _rootManager;
        private CategoryManager _categoryManager;

        private WarechouseViewerPage _warechouseViewerPage;

        public ObservableCollection<CategoryDbDto> CategoryComboItems { get; set; }
        public AddItemPage(WarechouseViewerPage warechouseViewWindow)
        {
            // If item.Name == "JEBAĆ PIS" then gratulację i przekierowanie na yt
            var context = new DatabaseContext();
            _itemRepository = new ItemRepository(context);
            _categoryManager = new CategoryManager(context);

            _warechouseViewerPage = warechouseViewWindow;

            _rootManager = new RootManager();

            InitializeComponent();

            ReloadCategoryCombo(null);

            DataContext = this;
        }
        public void ReloadCategoryCombo(int? categoryId)
        {
            CategoryComboItems = _categoryManager.LoadCategoryCombo();

            CategoryComboBox.ItemsSource = CategoryComboItems;

            if (categoryId != null)
            {
                CategoryComboBox.SelectedItem = CategoryComboItems.FirstOrDefault(a => a.Id == categoryId);
            }
        }
        private void ImageButton_Click(object sender, RoutedEventArgs e)
        {
            ImageManager.OnClickImageLoad(ref ImageButtonImage);
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            _rootManager.TerminateWindow(this);
        }

        private void AddItemButon_Click(object sender, RoutedEventArgs e)
        {
           if(ItemValidator.ValidateItem(CategoryComboBox, NameTextBox, ref PriceTextBox, CountTextBox, MinAllertTextBox, MaxAllertTextBox, ref ImageButtonImage))
            {
                var item = new ItemDbDto
                {
                    CategoryId = (int)CategoryComboBox.SelectedValue,
                    Picture = ImageManager.ImageToByte(ImageButtonImage),
                    Name = NameTextBox.Text,
                    Price = decimal.Parse(PriceTextBox.Text),
                    Count = int.Parse(CountTextBox.Text),
                    Describe = DescrieTextBox.Text,
                    Location = LocationTextBox.Text,
                    AdditionalInfo = AdditionalInfoTextBox.Text,
                    MinAllert = MinAllertTextBox.Text.Equals("") ? null : (int?)int.Parse(MinAllertTextBox.Text),
                    MaxAllert = MaxAllertTextBox.Text.Equals("") ? null : (int?)int.Parse(MaxAllertTextBox.Text)
                };

                _itemRepository.AddItem(item);

                _warechouseViewerPage.DataGridGenerator();
                _rootManager.TerminateWindow(this);
            }
        }

        private void CategoryAddButton_Click(object sender, RoutedEventArgs e)
        {
            _rootManager.RootFromToWindowOnTop(new AddCategoryPage(this));
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            TextBoxValidator.NumberValidationTextBox(e);
        }

        private void DecimalValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            TextBoxValidator.DecimalValidationTextBox(sender, e);
        }
    }
}
