using System;
using System.Linq;
using WarechouseInterface.DbDtos;

namespace WarechouseInterface.Repositories
{
    public class PasswordRepository
    {
        private readonly DatabaseContext _databaseContext;
        public PasswordRepository(DatabaseContext context)
        {
            _databaseContext = context;
        }

        public string GetHashPassword()
        {
           return _databaseContext.Password.Where(a=>a.DataK == null).FirstOrDefault().Hash;
        }

        public PasswordDbDto GetActualPassword()
        {
            return _databaseContext.Password.Where(a => a.DataK == null).FirstOrDefault();
        }

        public void AddPassword(string password)
        {
            var newPassword = new PasswordDbDto
            {
                Hash = password
            };

            _databaseContext.Add(newPassword);
            _databaseContext.SaveChanges();
        }

        public void ArchivePassword(int id)
        {
            var password = _databaseContext.Password.FirstOrDefault(a => a.Id == id);

            password.DataK = DateTime.Now;

            _databaseContext.SaveChanges();
        }
    }
}
