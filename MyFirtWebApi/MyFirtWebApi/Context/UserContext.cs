
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace MyFirtWebApi.Context
{
    /// <summary>
    /// UserContext
    /// </summary>
    public class UserContext : DbContext
    {
        SqlConnection cnn;

        string connetionString = "Data Source=192.168.250.65;Initial Catalog=pingflood;User ID=sa;Password=shawi123@";

        public UserContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connetionString);
        }
    }
}
