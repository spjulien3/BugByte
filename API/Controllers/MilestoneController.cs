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
                .ThenInclude( p => p.Tickets)
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


        [HttpPut("/update-milestone")]
        public async Task<ActionResult<AppMilestone>> UpdateMilestone(UpdateMilestoneDto request)
        {

            var milestone = await _context.Milestones
                .Where(t => t.Id == request.Id)
                .FirstOrDefaultAsync();
            if (milestone == null) return BadRequest();

            milestone.Title = request.Title;
            milestone.Description = request.Description;

            


            await _context.SaveChangesAsync();
            return Ok(milestone);

        }

        [HttpDelete("/delete-Milestone/{id}")]
        public async Task<ActionResult<AppMilestone>> DeleteMileston(int id)
        {
            var milestone = await _context.Milestones.Where(t => t.Id == id).FirstOrDefaultAsync();
            if (milestone == null) return BadRequest();

            _context.Milestones.Remove(milestone);
            await _context.SaveChangesAsync();
            return Ok(milestone);

        }

    }
}
