using System;
using System.Windows;
using WarechouseInterface.Managers;
using WarechouseInterface.Repositories;

namespace WarechouseInterface.Pages
{
    public partial class AddCategoryPage : Window
    {
        private AddItemPage _addItemPage;
        private EditItemPage _editItemPage;

        private RootManager _rootManager;
        private CategoryManager _categoryManager;
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
                if (_editItemPage != null)
                {
                    _editItemPage.ReloadCategoryCollection(categoryId.Value);
                    _rootManager.TerminateWindow(this);
                    return;
                }

                throw new Exception("nie zidentyfikowano okna pochodzenia");
            }
        }
    }
}
