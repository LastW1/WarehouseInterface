using System.Linq;
using System.Security.Cryptography;
using System.Text;
using WarehouseInterface.Repositories;

namespace WarehouseInterface.Managers
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

            return false;
        }

        public void SetNewPassword(string password)
        {
            var hashPassword = HashPassword(password);

            var actualPassword = _passwordRepository.GetActualPassword();

            _passwordRepository.ArchivePassword(actualPassword.Id);
            _passwordRepository.AddPassword(hashPassword);
        }

        public string HashPassword(string password)
        {
            var hash = new SHA1Managed().ComputeHash(Encoding.UTF8.GetBytes(password));
            return string.Concat(hash.Select(b => b.ToString("x2")));
        }
    }
}
