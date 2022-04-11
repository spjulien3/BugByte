using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;

namespace API.DTOs
{
    public class ProjectDto
    {
        

        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<AppUser> AssignedUsers { get; set;}
        public ICollection<AppTicket> Tickets { get; set; }
        public AppMilestone Milestone { get; set; }
    }
}