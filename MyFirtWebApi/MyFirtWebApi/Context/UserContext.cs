using Microsoft.EntityFrameworkCore;
using MyFirtWebApi.Models;

namespace MyFirtWebApi.Context
{
    /// <summary>
    /// UserContext
    /// </summary>
    public class UserContext : DbContext
    {
        /// <summary>
        /// Users
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// _connetionString
        /// </summary>
        private string _connetionString = "Data Source=192.168.250.65;Initial Catalog=pingflood;User ID=sa;Password=shawi123@";

        /// <summary>
        /// OnConfiguring
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connetionString);
        }
    }
}
