using System;

namespace MyFirtWebApi.Models
{
    /// <summary>
    /// Matches
    /// </summary>
    public class Matches
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// DemandsId
        /// </summary>
        public int DemandsId { get; set; }

        /// <summary>
        /// Demands
        /// </summary>
        public Demands Demands { get; set; }

        /// <summary>
        /// SeekerUsersId
        /// </summary>
        public int SeekerUsersId { get; set; }

        /// <summary>
        /// VolonteerUsersId
        /// </summary>
        public int VolonteerUsersId { get; set; }

        /// <summary>
        /// DemandStatusId
        /// </summary>
        public int DemandStatusId { get; set; }

        /// <summary>
        /// Date
        /// </summary>
        public DateTime Date { get; set; }
    }
}
