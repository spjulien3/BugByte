namespace API.DTOs
{
    public class UpdateProjectDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? milestoneId { get; set; }
    }
}
