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

        public DatabaseContext(bool isTest = false)
        {
            _isTest = isTest;
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
