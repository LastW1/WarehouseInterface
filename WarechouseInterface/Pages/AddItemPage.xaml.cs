using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using WarechouseInterface.Db.DbDtos;
using WarechouseInterface.Db.Repositories;
using WarechouseInterface.Managers;
using WarechouseInterface.Repositories;

namespace WarechouseInterface.Pages
{
    /// <summary>
    /// Interaction logic for AddItemPage.xaml
    /// </summary>
    public partial class AddItemPage : Window
    {
        private CategoryRepository _categoryRepository;
        private ItemRepository _itemRepository;
        private RootManager _rootManager;

        private WarechouseViewerPage _warechouseViewerPage;

        public ObservableCollection<CategoryDbDto> CategoryComboItems { get; set; }
        public AddItemPage(WarechouseViewerPage warechouseViewWindow)
        {
             // If item.Name == "JEBAĆ PIS" then gratulację i przekierowanie na yt
             var context = new DatabaseContext();
            _categoryRepository = new CategoryRepository(context);
            _itemRepository = new ItemRepository(context);

            _warechouseViewerPage = warechouseViewWindow;

            _rootManager = new RootManager();

            InitializeComponent();

            LoadCategoryCombo();

            DataContext = this; // nie mam pojęcia po co to ale bez tego combo box się nie ładuje xD
        }

        private void ImageButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog();

            bool? response = dialog.ShowDialog();

            if (response == true)
            {
                string filePath = dialog.FileName;

                ImageButtonImage.Source = new BitmapImage(new Uri(filePath));
            }
        }

        private void LoadCategoryCombo()
        {
            var items = _categoryRepository.GetCategories();

            CategoryComboItems = new ObservableCollection<CategoryDbDto>();

            foreach(var item in items)
            {
                CategoryComboItems.Add(item);
            }
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            _rootManager.TerminateWindow(this);
        }

        private void AddItemButon_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateItem())
            {
                var item = new ItemDbDto
                {
                    CategoryId = (int)CategoryComboBox.SelectedValue,
                    Picture = ImageToByte(ImageButtonImage),
                    Name = NameTextBox.Text,
                    Price = decimal.Parse(PriceTextBox.Text), //dorobić validację tego pola
                    Count = int.Parse(CountTextBox.Text),
                    Describe = DescrieTextBox.Text,
                    Location = LocationTextBox.Text,
                    AdditionalInfo = AdditionalInfoTextBox.Text,
                    MinAllert = MinAllertTextBox.Text.Equals("") ? 0 : int.Parse(MinAllertTextBox.Text),
                    MaxAllert = MaxAllertTextBox.Text.Equals("") ? 0 : int.Parse(MaxAllertTextBox.Text)
                };

                // validator dla obiektu

                _itemRepository.AddItem(item);

                _warechouseViewerPage.DataGridGenerator();
                _rootManager.TerminateWindow(this);
            }
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private bool ValidateItem()
        {
            if (CategoryComboBox.SelectedValue == null)
            {
                System.Windows.Forms.MessageBox.Show("Nie podano kategorii!");
                return false;
            }
            if (NameTextBox.Text.Equals(""))
            {
                System.Windows.Forms.MessageBox.Show("Nie podano nazwy produktu!");
                return false;
            }
            if (CountTextBox.Text.Equals(""))
            {
                System.Windows.Forms.MessageBox.Show("Nie podano ilości produktu!");
                return false;
            }     
            if (ImageButtonImage.Source.ToString().Equals("pack://application:,,,/WarechouseInterface;component/Images/addPictureImage.png"))
            {
                ImageButtonImage.Source = null;
            }

            return true;
        }

        private byte[] ImageToByte(Image image) //to do osobnego managera
        {
            if(image.Source == null)
            {
                return null;
            }

            var imagePath = image.Source.ToString().Replace("file:///","");

            return File.ReadAllBytes(imagePath);
        }
    }
}
