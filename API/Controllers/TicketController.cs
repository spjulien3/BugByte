using Microsoft.AspNetCore.Mvc;
using API.Data;
using API.Entities;
using Microsoft.EntityFrameworkCore;
using API.DTOs;

namespace API.Controllers
{
    public class TicketController : BaseApiController
    {
        private readonly DataContext _context;

        public TicketController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("/tickets/{userId}")]
        public async Task<List<AppTicket>> GetTicketsByUserId(int userId)
        {
            var tickets = await _context.Tickets
                .Where(t => t.UserId == userId)
                .Include(t => t.Project)
                .Include(t => t.User)
                .Include(t => t.Priority)
                .ToListAsync();


            return tickets;
        }

        [HttpGet("get/{ticketId}")]
        public async Task<ActionResult<AppTicket>> GetTicketByTicketId(int ticketId)
        {
            var tickets = await _context.Tickets.
                Where(t => t.Id == ticketId)
                .Include(t => t.Project)
                .Include(t => t.User)
                .Include(t => t.Priority)
                .FirstOrDefaultAsync();

            if(tickets == null) return NotFound();


            return tickets;
        }


        [HttpPost("/create-ticket")]
        public async Task<ActionResult<AppTicket>> CreateTicket(CreateTicketDto request)
        {
            var user = await _context.Users.FindAsync(request.UserId);
            if (user == null)
                return NotFound();

            var newTicket = new AppTicket
            {
                Title = request.Title,
                Description = request.Description,
                UserId = request.UserId,
                ProjectId = request.ProjectId,
                PriorityId = request.PriorityId,
                User = user
            };

            _context.Tickets.Add(newTicket);
            await _context.SaveChangesAsync();
            


            return await GetTicketByTicketId((int)newTicket.Id) ;
        }



    }
}
