using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class AppTicket
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DateCreated { get; set; }
        public AppUser AssignedUser { get; set; }
        public string Description { get; set; }
        public int PriorityId { get; set; }
        
        //Nav
        public AppProject Project { get; set; }
        public Priority Priority { get; set; }
    }
}