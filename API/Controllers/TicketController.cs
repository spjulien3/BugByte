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
        public async Task<List<AppTicket>> GetTicketsByAssignedUserId(int assignedUserId)
        {
            var tickets = await _context.Tickets
                .Where(t => t.AssignedUserId == assignedUserId)
                .Include(t => t.Project)
                .Include(t => t.AssignedUser)
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
                .Include(t => t.AssignedUser)
                .Include(t => t.Priority)
                .FirstOrDefaultAsync();

            if(tickets == null) return NotFound();


            return tickets;
        }


        [HttpPost("/create-ticket")]
        public async Task<ActionResult<AppTicket>> CreateTicket(CreateTicketDto request)
        {

            if (request.AssignedUserId == 0)
            {

                var authorUser = await _context.Users.FindAsync(request.AuthorUserId);

                var newTicket = new AppTicket
                {
                    Title = request.Title,
                    Description = request.Description,
                    AuthorUserId = request.AuthorUserId,
                    ProjectId = request.ProjectId,
                    PriorityId = request.PriorityId,
                    AuthorUser = authorUser
                };

                _context.Tickets.Add(newTicket);
                await _context.SaveChangesAsync();
                return await GetTicketByTicketId((int)newTicket.Id);
            }
            else
            {
                var authorUser = await _context.Users.FindAsync(request.AuthorUserId);
                var assignedUser = await _context.Users.FindAsync(request.AssignedUserId);



                var newTicket = new AppTicket
                {
                    Title = request.Title,
                    Description = request.Description,
                    AuthorUserId = request.AuthorUserId,
                    AssignedUserId = request.AssignedUserId,
                    ProjectId = request.ProjectId,
                    PriorityId = request.PriorityId,
                    AuthorUser = authorUser,
                    AssignedUser = assignedUser
                };

                _context.Tickets.Add(newTicket);
                await _context.SaveChangesAsync();
                return await GetTicketByTicketId((int)newTicket.Id);

            }


            
        }

        



    }
}
