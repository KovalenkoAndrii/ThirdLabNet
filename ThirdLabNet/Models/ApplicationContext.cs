using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;

namespace ThirdLabNet.Models
{
    public class ApplicationContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = "MyRazorDb.db" };
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);

            optionsBuilder.UseSqlite(connection);
        }

        public DbSet<Visit> Visits { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<Client> Clients { get; set; }
    }
}
