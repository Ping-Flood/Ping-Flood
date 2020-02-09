using System;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MyFirtWebApi.Models;

namespace MyFirtWebApi.Context
{
    /// <summary>
    /// MatcheContext
    /// </summary>
    public class MatcheContext : DbContext
    {
        /// <summary>
        /// Matches
        /// </summary>
        public DbSet<Matche> Matches { get; set; }

        /// <summary>
        /// _connetionString
        /// </summary>
        private static string _connetionString = "Data Source=192.168.250.65;Initial Catalog=pingflood;User ID=sa;Password=shawi123@";

        /// <summary>
        /// sqlConnection
        /// </summary>
        private readonly SqlConnection sqlConnection;

        /// <summary>
        /// MatchesContext
        /// </summary>
        public MatcheContext()
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
        /// Create
        /// </summary>
        /// <param name="matche"></param>
        /// <returns></returns>
        public Matche Create(Matche matche)
        {
            try
            {
                this.sqlConnection.Open();

                EntityEntry<Matche> entity = this.Matches.Add(matche);

                this.SaveChanges();

                Matche result = entity.Entity;

                this.sqlConnection.Close();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
