﻿using System.Text.Json.Serialization;

namespace API.Entities
{
    public class AppTicket
    {

        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        [JsonIgnore]
        public AppUser User { get; set; }
        [JsonIgnore]
        public AppProject Project { get; set; }
        [JsonIgnore]
        public Priority Priority { get; set; }
        public int? PriorityId { get; set; }
        public int? UserId { get; set; }
        public int? ProjectId { get; set; }

    }
}
