using NUnit.Framework;
using System.Linq;
using WarehouseInterface.Managers;
using WarehouseInterface.Repositories;

namespace WarehouseInterface.Tests
{
   // [TestFixture, RequiresSTA] gdy w teście używane są obiekty z okna WPF
    [TestFixture]
    public class PasswordManagerTest
    {
        private DatabaseContext _databaseContext;

        [TearDown]
        public void TearDown()
        {
            _databaseContext = null;
        }

        [Test]
        public void PasswordCheck_WhenCorrectPasswordGiven_Test()
        {
            using (_databaseContext = new DatabaseContext(true))
            {
                var manager = new PasswordManager(_databaseContext);
                Assert.IsTrue(manager.PasswordCheck("admin"));
            }      
        }

        [Test]
        public void SetNewPassword_WhenCorrectPasswordGiven_Test()
        {
            using (_databaseContext = new DatabaseContext(true))
            {
                var manager = new PasswordManager(_databaseContext);

                var previousPassword = _databaseContext.Password.FirstOrDefault(a => a.DataK == null).Hash;

                Assert.DoesNotThrow(()=> manager.SetNewPassword("test"));

                var newPassword = _databaseContext.Password.FirstOrDefault(a => a.DataK == null).Hash;

                Assert.AreNotEqual(previousPassword, newPassword);
            }
        }
    }
}
