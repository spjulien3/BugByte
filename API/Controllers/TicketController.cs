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
            
            if(tickets == null) return null;


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
                if (authorUser == null) return BadRequest();

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

                if (authorUser == null) return BadRequest();
                if (assignedUser == null) return BadRequest();



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


        [HttpPut("/update-ticket")]
        public async Task<ActionResult<AppTicket>> UpdateTicket(UpdateTicketDto request)
        {

            var ticket = await _context.Tickets
                .Where( t => t.Id == request.Id)
                .FirstOrDefaultAsync();
            if (ticket == null) return BadRequest();

            var assignedUser = await _context.Users
                .Where(u => u.Id == request.AssignedUserId)
                .FirstOrDefaultAsync();
            if (assignedUser == null) return BadRequest();


            ticket.Title = request.Title;
            ticket.Description = request.Description;
            ticket.AssignedUserId = ticket.AssignedUserId;
            ticket.AssignedUser = assignedUser;
            ticket.ProjectId = request.ProjectId;
            ticket.PriorityId = request.PriorityId;


            await _context.SaveChangesAsync();
            return Ok(ticket);

        }

        [HttpDelete("/delete-ticket/{id}")]
        public async Task<ActionResult<AppTicket>> DeleteTicket(int id)
        {
            var ticket = await _context.Tickets.Where(t => t.Id == id).FirstOrDefaultAsync();
            if(ticket == null) return BadRequest();

            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync();
            return Ok(ticket);

        }




    }
}
