using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class AppMilestone
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<AppProject> Projects { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}