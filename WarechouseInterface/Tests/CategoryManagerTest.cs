using NUnit.Framework;
using System.Linq;
using WarechouseInterface.Managers;
using WarechouseInterface.Repositories;

namespace WarechouseInterface.Tests
{
    class CategoryManagerTest
    {
        private DatabaseContext _databaseContext;

        [TearDown]
        public void TearDown()
        {
            _databaseContext = null;
        }

        [Test]
        public void LoadCategoryCombo_ShouldReturnCategories_Test()
        {
            using (_databaseContext = new DatabaseContext(true))
            {
                var manager = new CategoryManager(_databaseContext);
                Assert.IsTrue(manager.LoadCategoryCombo().ToList().Count > 0);
            }
        }

        [Test]
        public void AddCategory_WhenCorrectCategoryGiven_ShouldAddCategory_Test()
        {
            using (_databaseContext = new DatabaseContext(true))
            {
                var manager = new CategoryManager(_databaseContext);
                Assert.IsNotNull(manager.AddCategory("category not implemented in test db"));
            }
        }

        [Test]
        public void AddCategory_WhenEmptyNameGiven_ShouldReturnNull_Test()
        {
            using (_databaseContext = new DatabaseContext(true))
            {
                var manager = new CategoryManager(_databaseContext);
                Assert.IsNull(manager.AddCategory(""));
            }
        }

        [Test]
        public void AddCategory_WhenExistingCategoryGiven_ShouldReturnNull_Test()
        {
            using (_databaseContext = new DatabaseContext(true))
            {
                var existingCategoryname = _databaseContext.Category.FirstOrDefault(a => a.WarechouseId == 1).Name;

                var manager = new CategoryManager(_databaseContext);
                Assert.IsNull(manager.AddCategory(existingCategoryname));
            }
        }
    }
}

