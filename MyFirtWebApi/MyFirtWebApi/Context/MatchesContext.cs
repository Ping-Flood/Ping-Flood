using System;
using System.Linq;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MyFirtWebApi.Helpers;
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
        /// Users
        /// </summary>
        public DbSet<Users> Users { get; set; }

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
        public Users Create(Matches matche)
        {
            try
            {
                this.sqlConnection.Open();

                Demands demand = this.Demands.Where(x => x.Id == matche.DemandsId).First();

                demand.IsConfirmationRequired = false;

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

                if (matche.Date == default)
                {
                    matche.Date = DateTime.Now;
                }

                EntityEntry<Matches> entity = this.Matches.Add(matche);

                this.SaveChanges();

                Matches result = entity.Entity;

                this.sqlConnection.Close();

                return this.Users
                    .Where(x => x.Id == matche.SeekerUsersId)
                    .Select(x => new Users
                    {
                        Id = x.Id,
                        Address = x.Address,
                        City = x.City,
                        Email = x.Email,
                        EmailAlert = x.EmailAlert,
                        Firstname = x.Firstname,
                        IsSeeker = x.IsSeeker,
                        IsVolonteer = x.IsVolonteer,
                        Lastname = x.Lastname,
                        Password = x.Password,
                        Phone = x.Phone,
                        SmsAlert = x.SmsAlert
                    })
                    .FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// HandleSecureDemand
        /// </summary>
        /// <param name="demand"></param>
        private static void HandleSecureDemand(Demands demand)
        {
            string message = $"User.FirstName & User.LastName Catégorie: Demand.DemandType User." +
                $"Ville Voici le lien afin de confirmer votre participation LINK Merci de participer au soutien collectif via Ping-Flood";

            string phoneNumber = demand.SeekerUsers.Phone;

            SMSHelper.SendSMS(phoneNumber, $"+1{message}");
        }
    }
}
