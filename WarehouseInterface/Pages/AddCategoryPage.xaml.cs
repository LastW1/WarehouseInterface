using System;
using System.Windows;
using WarehouseInterface.Managers;
using WarehouseInterface.Repositories;

namespace WarehouseInterface.Pages
{
    public partial class AddCategoryPage : Window
    {
        private AddItemPage _addItemPage;
        private EditItemPage _editItemPage;

        private RootManager _rootManager;
        private CategoryManager _categoryManager;
        private CategorySettingPage _categorySettingPage;
        public AddCategoryPage(AddItemPage addItemPage)
        {
            _addItemPage = addItemPage;
            InitializePage();
        }

        public AddCategoryPage(EditItemPage editItemPage)
        {
            _editItemPage = editItemPage;
            InitializePage();
        }

        public AddCategoryPage(CategorySettingPage categorySettingPage)
        {
            _categorySettingPage = categorySettingPage;
            InitializePage();
        }

        private void InitializePage()
        {
            var context = new DatabaseContext();

            _rootManager = new RootManager();
            _categoryManager = new CategoryManager(context);

            InitializeComponent();
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            _rootManager.TerminateWindow(this);
        }

        private void AddCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            var categoryId = _categoryManager.AddCategory(NameTextBox.Text);

            if (categoryId != null)
            {
                if (_addItemPage != null)
                {
                    _addItemPage.ReloadCategoryCombo(categoryId);
                    _rootManager.TerminateWindow(this);
                    return;
                }
                else if (_editItemPage != null)
                {
                    _editItemPage.ReloadCategoryCollection(categoryId.Value);
                    _rootManager.TerminateWindow(this);
                    return;
                }
                else if(_categorySettingPage != null)
                {
                    _categorySettingPage.DataGridGenerator();
                    _rootManager.TerminateWindow(this);
                    return;
                }

                throw new Exception("nie zidentyfikowano okna pochodzenia");
            }
        }
    }
}
