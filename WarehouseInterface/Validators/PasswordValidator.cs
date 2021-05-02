using System.Windows.Forms;
using WarehouseInterface.Managers;
using WarehouseInterface.Repositories;

namespace WarehouseInterface.Validators
{
    public class PasswordValidator
    {
        private PasswordManager _passwordManager;
        private PasswordRepository _passwordRepository;

        public PasswordValidator()
        {
            var context = new DatabaseContext();
            _passwordManager = new PasswordManager(context);
            _passwordRepository = new PasswordRepository(context);
        }

        public bool ValidateNewPassword(string actualPassword, string newPassword, string newPassword2)
        {
            if (!_passwordManager.PasswordCheck(actualPassword))
            {
                MessageBox.Show("Podano niepoprawne hasło!");
                return false;
            };

            if (newPassword == null || newPassword.Equals(""))
            {
                MessageBox.Show("Nie podano nowego hasła!");
                return false;
            }

            if (!newPassword.Equals(newPassword2))
            {
                MessageBox.Show("Powtórzone hasła nie są takie same!");
                return false;
            }

            if (_passwordManager.PasswordCheck(newPassword))
            {
                MessageBox.Show("Nowe hasło jest takie samo jak poprzednie!");
                return false;
            }

            return true;
        }
    }
}
