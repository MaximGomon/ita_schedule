namespace epamEntryTask.Controllers
{
    /// <summary>Special class for displaying messages on the home page using Bootstrap Alerts</summary>
    public class AlertsMessege
    {
        /// <summary>Represents the types of notifications that Bootstrap Alerts contains</summary>
        public enum StatusesEnum
        {
            Success,
            Info,
            Warning,
            Danger
        }
        /// <summary>Current type of Bootstrap Alerts</summary>
        public StatusesEnum Status { get; set; }
        /// <summary>String that represents HTML class="name" from Bootstrap Alerts</summary>
        public string[] ClassNames =
        {
            "alert-success",
            "alert-info",
            "alert-warning",
            "alert-danger"
        };
        /// <summary>Massage Title</summary>
        public string Tittle { get; set; }
        /// <summary>Massage Text</summary>
        public string Text { get; set; }
    }
}