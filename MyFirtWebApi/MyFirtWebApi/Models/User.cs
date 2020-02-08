using System;
namespace MyFirtWebApi.Models
{
    /// <summary>
    /// User
    /// </summary>
    public class User
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Firstname { get; set; }

        /// <summary>
        /// Lastname
        /// </summary>
        public string Lastname { get; set; }
    }
}
