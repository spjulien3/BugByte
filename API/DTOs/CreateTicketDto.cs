namespace API.DTOs
{
    public class CreateTicketDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int UserId { get; set; } = 0;
        public int ProjectId { get; set; } = 0;
        public int PriorityId { get; set; } = 0;
    }
}
