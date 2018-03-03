using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Schedule.IntIta.Integration.IntegrationModels
{
    class UserIntegrativeModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        [JsonProperty("middleName")]
        public string MiddleName { get; set; }
        [JsonProperty("secondName")]
        public string SecondName  { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
