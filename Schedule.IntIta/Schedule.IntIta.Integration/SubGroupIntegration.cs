﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schedule.IntIta.Integration.IntegrationModels
{
    public class SubGroupIntegration
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }

    }
}
