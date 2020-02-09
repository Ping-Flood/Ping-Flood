namespace MyFirtWebApi.Models
{
    /// <summary>
    /// Users
    /// </summary>
    public class Users
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

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Address
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// City
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Phone
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// IsSeeker
        /// </summary>
        public bool IsSeeker { get; set; }

        /// <summary>
        /// IsVolonteer
        /// </summary>
        public bool IsVolonteer { get; set; }

        /// <summary>
        /// EmailAlert
        /// </summary>
        public bool EmailAlert { get; set; }

        /// <summary>
        /// SmsAlert
        /// </summary>
        public bool SmsAlert { get; set; }
    }
}
