using Microsoft.EntityFrameworkCore;
using System.Configuration;
using WarechouseInterface.Db.DbDtos;

namespace WarechouseInterface.Repositories
{
    public class DatabaseContext : DbContext
    {
        private bool _isTest;
        public DbSet<PasswordDbDto> Password { get; set; }
        public DbSet<ItemDbDto> Item { get; set; }
        public DbSet<CategoryDbDto> Category { get; set; }
        public DbSet<TransactionDbDto> Transaction { get; set; }
        public DbSet<TransactionTypeDbDto> TransactionType { get; set; }
        public DbSet<TransactionItemsDbDto> TransactionItem { get; set; }

        public DatabaseContext(bool isTest = false)
        {
            _isTest = isTest;

            //jeśli jest to test to przestawić automatycznie na werechouse = 1;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            if (_isTest)
            {
                optionBuilder.UseSqlite(ConfigurationManager.AppSettings.Get("SqlTestConnect"));
            }
            else
            {
                optionBuilder.UseSqlite(ConfigurationManager.AppSettings.Get("SqlConnect"));
            }
        }
    }
}
