using NUnit.Framework;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Controls;
using WarechouseInterface.Repositories;

namespace WarechouseInterface.Managers
{
    public class PasswordManager
    {
        private PasswordRepository _passwordRepository;

        public PasswordManager(DatabaseContext context)
        {
            _passwordRepository = new PasswordRepository(context);
        }

        public bool PasswordCheck(string password)
        {
            var hashPassword = HashPassword(password);

            var dbPassword = _passwordRepository.GetHashPassword();

            if (dbPassword.Equals(hashPassword))
            {
                return true;
            }

            throw new System.Exception("Podano nieprawidłowe hasło");
        }

        public void SetNewPassword(string password)
        {
            var hashPassword = HashPassword(password);

            var actualPassword = _passwordRepository.GetActualPassword();

            if (actualPassword.Hash.Equals(hashPassword))
            {
                throw new System.Exception("Nowe hasło jest takie samo jak wcześniejsze!");
            }

            _passwordRepository.ArchivePassword(actualPassword.Id);
            _passwordRepository.AddPassword(hashPassword);
        }

        private string HashPassword(string password)
        {
            var hash = new SHA1Managed().ComputeHash(Encoding.UTF8.GetBytes(password));
            return string.Concat(hash.Select(b => b.ToString("x2")));
        }
    }
}
