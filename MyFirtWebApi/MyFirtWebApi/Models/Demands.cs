using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyFirtWebApi.Models
{
    /// <summary>
    /// Demand
    /// </summary>
    public class Demands
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// DemandTypeId
        /// </summary>
        public int DemandTypeId { get; set; }

        /// <summary>
        /// DemandType
        /// </summary>
        public DemandTypes DemandType { get; set; }

        /// <summary>
        /// SeekerUserId
        /// </summary>
        public int? SeekerUserId { get; set; }

        /// <summary>
        /// SeekerUser
        /// </summary>
        public Users SeekerUser { get; set; }

        /// <summary>
        /// VolonteerUserId
        /// </summary>
        public int? VolonteerUserId { get; set; }

        /// <summary>
        /// VolonteerUser
        /// </summary>
        public Users VolonteerUser { get; set; }

        /// <summary>
        /// IsConfirmationRequired
        /// </summary>
        public bool IsConfirmationRequired { get; set; }

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
