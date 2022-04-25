using System.Text.Json.Serialization;

namespace API.Entities
{
    public class AppProject
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public List<AppTicket> Tickets { get; set; }
        [JsonIgnore]
        public AppMilestone Milestone { get; set; }
        public int? MilestoneId { get; set; }

        

    }
}
