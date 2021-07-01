using NUnit.Framework;
using WarehouseInterface.Validators;

namespace WarehouseInterface.Tests.Validators
{
    [TestFixture]
    class PasswordValidatorTest
    {
        private PasswordValidator _passwordValidator;

        [SetUp]
        public void SetUp()
        {
            _passwordValidator = new PasswordValidator();
        }

        [Test]
        public void ValidateNewPassword_WhenCorrectDataGiven_ShouldReturnTrue_Test()
        {
            Assert.IsTrue(_passwordValidator.ValidateNewPassword("admin", "new", "new"));
        }

        [Test]
        public void ValidateNewPassword_WhenUncorrectActualPasswordGiven_ShouldReturnFalse_Test()
        {
            Assert.IsFalse(_passwordValidator.ValidateNewPassword("uncorrectPassword", "new", "new"));
        }

        [Test]
        public void ValidateNewPassword_WhenNewPasswordNotGiven_ShouldReturnFalse_Test()
        {
            Assert.IsFalse(_passwordValidator.ValidateNewPassword("uncorrectPassword", "", ""));
        }

        [Test]
        public void ValidateNewPassword_WhenReapeatNotCorrect_ShouldReturnFalse_Test()
        {
            Assert.IsFalse(_passwordValidator.ValidateNewPassword("admin", "new", "new2"));
        }

        [Test]
        public void ValidateNewPassword_WhenPasswordSameAsBefore_ShouldReturnFalse_Test()
        {
            Assert.IsFalse(_passwordValidator.ValidateNewPassword("admin", "admin", "admin"));
        }
    }
}
