using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class AppProject
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<AppUser> AssignedUsers { get; set;}
        public ICollection<AppTicket> Tickets { get; set; }
        public AppMilestone Milestone { get; set; }

    }
}