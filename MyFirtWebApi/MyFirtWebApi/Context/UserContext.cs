
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace MyFirtWebApi.Context
{
    /// <summary>
    /// UserContext
    /// </summary>
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        private string connetionString = "Data Source=192.168.250.65;Initial Catalog=pingflood;User ID=sa;Password=shawi123@";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connetionString);
        }
    }

    public class User
    {
        public int Id { get; set; }
    }
}
