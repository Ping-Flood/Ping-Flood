using System;
using System.Linq;
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
        public DbSet<Matches> Matches { get; set; }

        /// <summary>
        /// Demands
        /// </summary>
        public DbSet<Demands> Demands { get; set; }

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
        public Matches Create(Matches matche)
        {
            try
            {
                this.sqlConnection.Open();

                Demands demand = this.Demands.Where(x => x.Id == matche.DemandsId).First();

                if (demand.IsConfirmationRequired)
                {
                    matche.DemandStatusId = (int)DemandStatus.WaitingSecure;
                    HandleSecureDemand(demand);
                }
                else
                {
                    matche.DemandStatusId = (int)DemandStatus.Approved;
                    matche.Demands = demand;
                }

                EntityEntry<Matches> entity = this.Matches.Add(matche);

                this.SaveChanges();

                Matches result = entity.Entity;

                this.sqlConnection.Close();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Waiting for approval
        /// </summary>
        /// <param name="demand"></param>
        private static void HandleSecureDemand(Demands demand)
        {
            string phoneNumber = demand.SeekerUser.Phone;

            SMSHelper.SendSMS(phoneNumber, "just a test");
        }
    }
}
