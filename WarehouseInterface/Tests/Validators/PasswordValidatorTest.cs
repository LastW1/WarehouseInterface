using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseInterface.Repositories;
using WarehouseInterface.Validators;

namespace WarehouseInterface.Tests.Validators
{
    [TestFixture]
    class PasswordValidatorTest
    {
        private PasswordValidator _passwordValidator;
        private DatabaseContext _databaseContext;

        [SetUp]
        public void SetUp()
        {
            _passwordValidator = new PasswordValidator();
        }

        [Test]
        public void ValidateNewPassword_WhenCorrectDataGiven_ShouldReturnTrue_Test()
        {
            using (_databaseContext = new DatabaseContext(true))
            {
                Assert.IsTrue(_passwordValidator.ValidateNewPassword("admin", "new", "new"));
            }
        }

        [Test]
        public void ValidateNewPassword_WhenUncorrectActualPasswordGiven_ShouldReturnFalse_Test()
        {
            using (_databaseContext = new DatabaseContext(true))
            {
                Assert.IsFalse(_passwordValidator.ValidateNewPassword("uncorrectPassword", "new", "new"));
            }
        }

        [Test]
        public void ValidateNewPassword_WhenNewPasswordNotGiven_ShouldReturnFalse_Test()
        {
            using (_databaseContext = new DatabaseContext(true))
            {
                Assert.IsFalse(_passwordValidator.ValidateNewPassword("uncorrectPassword", "", ""));
            }
        }

        [Test]
        public void ValidateNewPassword_WhenReapeatNotCorrect_ShouldReturnFalse_Test()
        {
            using (_databaseContext = new DatabaseContext(true))
            {
                Assert.IsFalse(_passwordValidator.ValidateNewPassword("admin", "new", "new2"));
            }
        }

        [Test]
        public void ValidateNewPassword_WhenPasswordSameAsBefore_ShouldReturnFalse_Test()
        {
            using (_databaseContext = new DatabaseContext(true))
            {
                Assert.IsFalse(_passwordValidator.ValidateNewPassword("admin", "admin", "admin"));
            }
        }
    }
}
