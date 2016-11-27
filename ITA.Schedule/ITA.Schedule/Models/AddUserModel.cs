using System;
using System.Collections.Generic;
using ITA.Schedule.Entity.Entities;

namespace ITA.Schedule.Models
{
    /// <summary>
    /// Use this model for AddUser view
    /// </summary>
    public class AddUserModel
    {
        public Dictionary<Guid, string> Teachers { get; set; }
        public Dictionary<Guid, string> Students { get; set; }
        public Dictionary<Guid, string> SecurityGroups { get; set; }
    }
}