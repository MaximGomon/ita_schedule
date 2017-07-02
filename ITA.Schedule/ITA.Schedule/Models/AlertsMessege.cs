namespace ITA.Schedule.Models
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

        /// <summary>Method return AlertsMessege about error in form validation</summary>
        /// <returns>AlertsMessege class with filled parameters</returns>
        public AlertsMessege LoginFormNotValid()
        {
            return new AlertsMessege
            {
                Status = StatusesEnum.Warning,
                Tittle = "Warning!",
                Text   = "The entered Login data are not valid, Try again."
            };
        }

        /// <summary>Method return AlertsMessege about error in user email</summary>
        /// <returns>AlertsMessege class with filled parameters</returns>
        public AlertsMessege LoginNoMatchesInDb()
        {
            return new AlertsMessege
            {
                Status = StatusesEnum.Warning,
                Tittle = "Warning!",
                Text   = "There is no user with such email and password. Try again."
            };
        }

        /// <summary>Method return AlertsMessege about error "Sorry something went wrong"</summary>
        /// <returns>AlertsMessege class with filled parameters</returns>
        public AlertsMessege LoginSomethingWentWrong()
        {
            return new AlertsMessege
            {
                Status = StatusesEnum.Warning,
                Tittle = "Warning!",
                Text   = "Sorry something went wrong. Contact the administration."
            };
        }

        /// <summary>Method return AlertsMessege about error in form validation</summary>
        /// <returns>AlertsMessege class with filled parameters</returns>
        public AlertsMessege RegisterFormNotValid()
        {
            return new AlertsMessege
            {
                Status = StatusesEnum.Warning,
                Tittle = "Warning!",
                Text   = "The entered Registeration data are not valid Try again."
            };
        }

        /// <summary>Method return AlertsMessege about error that user with such email</summary>
        /// <returns>AlertsMessege class with filled parameters</returns>
        public AlertsMessege RegisterEmailAlreadyExist()
        {
            return new AlertsMessege
            {
                Status = StatusesEnum.Warning,
                Tittle = "Warning!",
                Text   = "There is user with such email already exist. Try to use \"forgot your password\" or contact the administration."
            };
        }
    }
}