
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProjectController : BaseApiController
    {
        private readonly DataContext _dataContext;
            public ProjectController(DataContext dataContext)
            {
            _dataContext = dataContext;

            }

            [HttpPost("register-project")]
            public async Task<ActionResult<AppProject>> RegisterProject(ProjectDto projectDto){

                var project =  new AppProject{
                    Title = projectDto.Title,
                    Description = projectDto.Description,
                };
                _dataContext.Projects.Add(project);
                await _dataContext.SaveChangesAsync();
                return project; 
            }

            // [HttpPost("new-ticket")]
            // public async Task<ActionResult<AppTicket>> NewTicket(string title, AppUser assignedUser,
            //  AppProject project, Priority priority, string description)
            //  {
            //     var ticket = new AppTicket 
            //     {
            //         Title = title,
            //         Description = description,
            //         AssignedUser = assignedUser,
            //         Priority = priority,
            //         Project = project
            //     };
            //     _dataContext.Tickets.Add(ticket);
            //     await _dataContext.SaveChangesAsync();
            //     return ticket;
            //  }

    }
}