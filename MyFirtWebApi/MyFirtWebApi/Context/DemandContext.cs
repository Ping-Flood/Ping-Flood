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
        public Demands Detail(int id)
        {
            try
            {
                this.sqlConnection.Open();

                Demands result = this.Demands.Where(x => x.Id == id).Select(x => new Demands
                {
                    Id = x.Id,
                    DemandType = x.DemandType,
                    Date = x.Date,
                    Expiration = x.Expiration,
                    SeekerUser = x.SeekerUser,
                    SeekerUserId = x.SeekerUserId,
                    VolonteerUserId = x.VolonteerUserId,
                    VolonteerUser = x.VolonteerUser,
                    Description = x.Description,
                    DemandTypeId = x.DemandTypeId
                }).FirstOrDefault();

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
        public Demands Create(Demands demand)
        {
            try
            {
                this.sqlConnection.Open();

                EntityEntry<Demands> entity = this.Demands.Add(demand);

                this.SaveChanges();

                Demands result = entity.Entity;

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
        public IEnumerable<Demands> GetDemandList(bool isSeeker, bool isVolonteer)
        {
            try
            {
                this.sqlConnection.Open();

                IEnumerable<Demands> result = Enumerable.Empty<Demands>();

                if (isSeeker && !isVolonteer)
                {
                    result = this.Demands.Where(x
                        => x.SeekerUserId.HasValue && x.Expiration >= DateTime.Now).Select(x
                        => new Demands
                        {
                            Id = x.Id,
                            DemandType = x.DemandType,
                            Date = x.Date,
                            Expiration = x.Expiration,
                            SeekerUser = x.SeekerUser,
                            SeekerUserId = x.SeekerUserId
                        }).ToList();
                }
                else if (isVolonteer && !isSeeker)
                {
                    result = this.Demands.Where(x
                        => x.VolonteerUserId.HasValue && x.Expiration >= DateTime.Now).Select(x
                        => new Demands
                        {
                            Id = x.Id,
                            Expiration = x.Expiration,
                            DemandType = x.DemandType,
                            Date = x.Date,
                            VolonteerUser = x.VolonteerUser,
                            VolonteerUserId = x.VolonteerUserId
                        }).ToList();
                }
                else if (isVolonteer && isSeeker)
                {
                    result = this.Demands.Where(x
                        => x.Expiration >= DateTime.Now).Select(x
                        => new Demands
                        {
                            Id = x.Id,
                            DemandType = x.DemandType,
                            Date = x.Date,
                            SeekerUser = x.SeekerUser,
                            VolonteerUser = x.VolonteerUser,
                            SeekerUserId = x.SeekerUserId,
                            VolonteerUserId = x.VolonteerUserId,
                            Expiration = x.Expiration
                        }).ToList();
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
