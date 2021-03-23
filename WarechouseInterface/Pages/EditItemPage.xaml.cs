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

namespace WarechouseInterface.Pages
{
    /// <summary>
    /// Interaction logic for EditItemPage.xaml
    /// </summary>
    public partial class EditItemPage : Window
    {
        public ObservableCollection<CategoryDbDto> _comboCollection { get; set; }

        private int _itemId;
        private WarechouseViewerPage _warechouseViewWindow;
        private CategoryRepository _categoryRepository;
        private CategoryManager _categoryManager;

        private readonly ItemRepository _itemRepository;

        public EditItemPage(WarechouseViewerPage warechouseViewWindow, int itemId)
        {
            _itemId = itemId;

            var context = new DatabaseContext();
            _itemRepository = new ItemRepository(context);
            _categoryRepository = new CategoryRepository(context);
            _categoryManager = new CategoryManager(context);

            InitializeComponent();

            GenerateFields();

            DataContext = this;
        }

        private void GenerateFields()
        {
            var item = _itemRepository.GetItemById(_itemId);

            ReloadCategoryCollection(item.CategoryId);

            NameTextBox.Text = item.Name;
        }

        public void ReloadCategoryCollection(int categoryId)
        {
            _comboCollection = _categoryManager.LoadCategoryCombo();

            CategoryComboBox.ItemsSource = _comboCollection;

            CategoryComboBox.SelectedItem = _comboCollection.FirstOrDefault(a => a.Id == categoryId);
        }

        private void ImageButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e) //do managera to
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteBuddton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CategoryAddButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
