using System;
using System.Linq;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
        private static string _connetionString = "Data Source=192.168.250.65;Initial Catalog=pingflood;User ID=sa;Password=shawi123@";

        /// <summary>
        /// sqlConnection
        /// </summary>
        private readonly SqlConnection sqlConnection;

        /// <summary>
        /// UserContext
        /// </summary>
        public UserContext()
        {
            this.sqlConnection = new SqlConnection(_connetionString);
        }

        /// <summary>
        /// OnConfiguring
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connetionString);
        }

        /// <summary>
        /// Detail
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User Detail(int id)
        {
            try
            {
                this.sqlConnection.Open();

                User result = null;//= this.Users.Where(x => x.Id == id).FirstOrDefault();

                this.sqlConnection.Close();

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public User Create(User user)
        {
            try
            {
                this.sqlConnection.Open();

                EntityEntry<User> entity = this.Users.Add(user);

                this.SaveChanges();

                User result = entity.Entity;

                this.sqlConnection.Close();

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Authenticate
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool Authenticate(User user)
        {
            bool exist = this.Users.Where(x => x.Email == user.Email && x.Password == user.Password).Any();

            return exist;
        }
    }
}
