using System;

namespace MyFirtWebApi.Models
{
    /// <summary>
    /// Demands
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
        /// SeekerUsersId
        /// </summary>
        public int? SeekerUsersId { get; set; }

        /// <summary>
        /// SeekerUser
        /// </summary>
        public Users SeekerUser { get; set; }

        /// <summary>
        /// VolunteerUsersId
        /// </summary>
        public int? VolunteerUsersId { get; set; }

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

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }
    }
}
