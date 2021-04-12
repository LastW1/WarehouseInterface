using System.Collections.ObjectModel;
using System.Windows;
using WarehouseInterface.Db.DbDtos;
using WarehouseInterface.Db.Repositories;
using WarehouseInterface.Repositories;

namespace WarehouseInterface.Managers
{
    public class CategoryManager
    {
        private readonly CategoryRepository _categoryRepository;

        public CategoryManager(DatabaseContext context)
        {
            _categoryRepository = new CategoryRepository(context);
        }
        public ObservableCollection<CategoryDbDto> LoadCategoryCombo()
        {
            var items = _categoryRepository.GetCategories();

            var comboCollection = new ObservableCollection<CategoryDbDto>();

            foreach (var item in items)
            {
                comboCollection.Add(item);
            }

            return comboCollection;
        }

        public int? AddCategory(string categoryName)
        {
            if (categoryName == "")
            {
                MessageBox.Show("Nie podano nazwy kategorii");
                return null;
            }

            var categoryId = _categoryRepository.AddCategory(categoryName);

            if(categoryId == null)
            {
                MessageBox.Show("Kategoria o tej nazwie już istnieje");
                return null;
            }

            return categoryId;
        }
    }
}
