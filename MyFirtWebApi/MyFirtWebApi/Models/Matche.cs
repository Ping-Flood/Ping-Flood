using System;

namespace MyFirtWebApi.Models
{
    /// <summary>
    /// Matche
    /// </summary>
    public class Matche
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
