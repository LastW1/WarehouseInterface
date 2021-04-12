using Microsoft.VisualBasic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using WarehouseInterface.Db.DbDtos;
using WarehouseInterface.Db.Repositories;
using WarehouseInterface.Managers;
using WarehouseInterface.Repositories;

namespace WarehouseInterface.Pages
{
    public partial class CategorySettingPage : Window
    {
        private string _searchCategory;

        private readonly RootManager _rootManager;
        private readonly SettingsPage _settingsPage;
        private readonly CategoryRepository _categoryRepository;
        private readonly CategoryManager _categoryManager;

        public ObservableCollection<CategoryDbDto> _dataGridCollection;
        public CategorySettingPage(SettingsPage settingsPage)
        {
            _settingsPage = settingsPage;

            var context = new DatabaseContext();
            _categoryRepository = new CategoryRepository(context);
            _categoryManager = new CategoryManager(context);
            _rootManager = new RootManager();

            InitializeComponent();
            DataGridGenerator();
        }

        public void DataGridGenerator()
        {
            _dataGridCollection = _categoryManager.LoadCategoryComboBasedOnName(_searchCategory);

            CategoryGrid.ItemsSource = _dataGridCollection;
            CategoryGrid.Items.Refresh();
        }
        private void CategoryTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _searchCategory = CategoryTextBox.Text;
            DataGridGenerator();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            _rootManager.CloseFromShowTo(this, _settingsPage);
        }

        private void AddCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            _rootManager.RootFromToWindowOnTop(new AddCategoryPage(this));
        }

        private void EditCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            var categoryId = (int)((Button)sender).CommandParameter;

            var oldName = _categoryRepository.GetCategory(categoryId).Name;

            var newName = Interaction.InputBox("Podaj nową nazwę dla kategorii", "", oldName);

            if (newName.Equals(""))
            {
                return;
            }

            _categoryRepository.ChangeCategoryName(categoryId, newName);
            DataGridGenerator();
        }

        private void RemoveCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Czy na pewno chcesz usunąć tą kategorię?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var categoryId = (int)((Button)sender).CommandParameter;

                _categoryManager.RemoveCategory(categoryId);
            }

            DataGridGenerator();
        }
    }
}
