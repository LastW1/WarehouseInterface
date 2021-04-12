using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;
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
            var categories = _categoryRepository.GetCategories().OrderBy(a=>a.Name);

            var comboCollection = new ObservableCollection<CategoryDbDto>();

            foreach (var category in categories)
            {
                comboCollection.Add(category);
            }

            return comboCollection;
        }

        public ObservableCollection<CategoryDbDto> LoadCategoryComboBasedOnName(string name)
        {
            if(name == null || name.Equals(""))
            {
                return LoadCategoryCombo();
            };

            var categories = _categoryRepository.GetCategories()
                .Where(a=>a.Name.ToLower().Contains(name.ToLower()))
                .OrderBy(a => a.Name);

            var comboCollection = new ObservableCollection<CategoryDbDto>();

            foreach (var category in categories)
            {
                comboCollection.Add(category);
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

            if (categoryId == null)
            {
                MessageBox.Show("Kategoria o tej nazwie już istnieje");
                return null;
            }

            return categoryId;
        }

        public void RemoveCategory(int categoryId)
        {
            var items = _categoryRepository.GetItemsAssignedToCategory(categoryId).ToList();
            if (items.Count != 0)
            {
                MessageBox.Show($"Nie można usunąć tej kategorii ponieważ jest powiązana z następującymi produktami:\n{items.Join("\n")}");
                return;
            }

            _categoryRepository.RemoveCategory(categoryId);
        }
    }
}
