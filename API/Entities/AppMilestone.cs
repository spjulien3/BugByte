using System.Text.Json.Serialization;

namespace API.Entities
{
    public class AppMilestone
    {

        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<AppProject> Projects { get; set; }

    }
}
