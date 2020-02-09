using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MyFirtWebApi.Models;

namespace MyFirtWebApi.Context
{
    /// <summary>
    /// DemandContext
    /// </summary>
    public class DemandContext : DbContext
    {
        /// <summary>
        /// Demands
        /// </summary>
        public DbSet<Demand> Demands { get; set; }

        /// <summary>
        /// _connetionString
        /// </summary>
        private static string _connetionString = "Data Source=192.168.250.65;Initial Catalog=pingflood;User ID=sa;Password=shawi123@";

        /// <summary>
        /// sqlConnection
        /// </summary>
        private readonly SqlConnection sqlConnection;

        /// <summary>
        /// DemandContext
        /// </summary>
        public DemandContext()
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
        public Demand Detail(int id)
        {
            try
            {
                this.sqlConnection.Open();

                Demand result = this.Demands.Where(x => x.Id == id).FirstOrDefault();

                this.sqlConnection.Close();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="demand"></param>
        /// <returns></returns>
        public Demand Create(Demand demand)
        {
            try
            {
                this.sqlConnection.Open();

                EntityEntry<Demand> entity = this.Demands.Add(demand);

                this.SaveChanges();

                Demand result = entity.Entity;

                this.sqlConnection.Close();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// GetDemandList
        /// </summary>
        /// <param name="isSeeker"></param>
        /// <param name="isVolonteer"></param>
        /// <returns></returns>
        public IEnumerable<Demand> GetDemandList(bool isSeeker, bool isVolonteer)
        {
            try
            {
                this.sqlConnection.Open();

                IEnumerable<Demand> result = Enumerable.Empty<Demand>();

                if (isSeeker && !isVolonteer)
                {
                    result = this.Demands.Where(x => x.VolonteerUserId.HasValue &&
                                                x.Expiration >= DateTime.Now).ToList();
                }
                else if (isVolonteer && !isSeeker)
                {
                    result = this.Demands.Where(x => x.SeekerUserId.HasValue &&
                                                x.Expiration >= DateTime.Now).ToList();
                }
                else if (isVolonteer && isSeeker)
                {
                    result = this.Demands.Where(x => x.Expiration >= DateTime.Now).ToList();
                }

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
