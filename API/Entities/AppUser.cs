using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace API.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public ICollection<AppUserRole> UserRoles { get; set; }
        public ICollection<AppProject> AssignedProjects { get; set; }
        public ICollection<AppTicket> AssignedTickets { get; set; }
    }
}