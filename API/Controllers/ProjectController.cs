using API.Data;
using API.DTOs;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class ProjectController : BaseApiController
    {
        private readonly DataContext _context;

        public ProjectController(DataContext context)
        {
            _context = context;
        }


        [HttpGet("get/{projectId}")]
        public async Task<ActionResult<AppProject>> GetProjectByProjectId(int projectId)
        {
            var project = await _context.Projects
                .Where(p => p.Id == projectId)
                .Include(p => p.Tickets)
                .FirstOrDefaultAsync();

            if (project == null) return NotFound();


            return project;
        }


        [HttpPost("/register-project")]
        public async Task<ActionResult<AppProject>> CreateProject(RegisterProjectDto request)
        {
            

            var newProject = new AppProject
            {
                Title = request.Title,
                Description = request.Description,
                MilestoneId = request.milestoneId

            };

            _context.Projects.Add(newProject);
            await _context.SaveChangesAsync();



            return await GetProjectByProjectId((int)newProject.Id);
        }
    }
}
