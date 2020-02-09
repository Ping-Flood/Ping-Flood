using System;

namespace MyFirtWebApi.Models
{
    /// <summary>
    /// Demand
    /// </summary>
    public class Demand
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// SeekerUserId
        /// </summary>
        public int? SeekerUserId { get; set; }

        /// <summary>
        /// VolonteerUserId
        /// </summary>
        public int? VolonteerUserId { get; set; }

        /// <summary>
        /// ConfirmationRequired
        /// </summary>
        public bool ConfirmationRequired { get; set; }

        /// <summary>
        /// Expiration
        /// </summary>
        public DateTime Expiration { get; set; }

        /// <summary>
        /// Date
        /// </summary>
        public DateTime Date { get; set; }
    }
}
