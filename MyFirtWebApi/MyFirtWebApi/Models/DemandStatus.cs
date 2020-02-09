namespace MyFirtWebApi.Models
{
    /// <summary>
    /// DemandStatus
    /// </summary>
    public enum DemandStatus
    {
        /// <summary>
        /// WaitingSecure
        /// </summary>
        WaitingSecure = 1,

        /// <summary>
        /// WaitingVolunteer
        /// </summary>
        WaitingVolunteer = 2,

        /// <summary>
        /// Approved
        /// </summary>
        Approved = 3,

        /// <summary>
        /// Reject
        /// </summary>
        Reject = 4
    }
}
