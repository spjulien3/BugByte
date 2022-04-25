namespace API.DTOs
{
    public class RegisterProjectDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int? milestoneId { get; set; }
    }
}
