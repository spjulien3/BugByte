﻿namespace API.DTOs
{
    public class UpdateTicketDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int? AssignedUserId { get; set; }
        public int ProjectId { get; set; } = 0;
        public int PriorityId { get; set; } = 0;
    }
}
