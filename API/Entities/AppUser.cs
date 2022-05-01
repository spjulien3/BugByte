using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace API.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public ICollection<AppUserRole> UserRoles { get; set; }
        [ForeignKey("AssignedUserId")]
        public virtual List<AppTicket> AssignedTickets { get; set; }
        [ForeignKey("AuthorUserId")]
        public virtual List<AppTicket> CreatedTickets { get; set; }


    }
}