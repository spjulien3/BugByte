using API.Data;
using API.DTOs;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class MilestoneController : BaseApiController
    {
        private readonly DataContext _context;

        public MilestoneController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("/milestones")]
        public async Task<ActionResult<List<AppMilestone>>> GetTicketsByUserId()
        {
            var milestones = await _context.Milestones.Where( m => m.Id != 0).Include(m => m.Projects).ToListAsync();
            if (milestones == null) return NotFound();


            return milestones;
        }

        [HttpGet("get/{milestoneId}")]
        public async Task<ActionResult<AppMilestone>> GetMilestoneByMilestoneId(int milestoneId)
        {
            var milestone = await _context.Milestones.
                Where(m => m.Id == milestoneId)
                .Include(t => t.Projects)
                .FirstOrDefaultAsync();

            if (milestone == null) return NotFound();


            return milestone;
        }


        [HttpPost("/create-Milestone")]
        public async Task<ActionResult<AppMilestone>> CreateTicket(CreateMilestoneDto request)
        {

            var newMilestone = new AppMilestone
            {
                Title = request.Title,
                Description = request.Description,
         

            };

            _context.Milestones.Add(newMilestone);
            await _context.SaveChangesAsync();



            return await GetMilestoneByMilestoneId((int)newMilestone.Id);
        }
    }
}
