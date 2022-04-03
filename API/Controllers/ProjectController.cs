using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
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
            public async Task<ActionResult<AppProject>> RegisterProject(string title, string description){

                var project =  new AppProject{
                    Title = title,
                    Description = description,
                };
                _dataContext.Projects.Add(project);
                await _dataContext.SaveChangesAsync();
                return project; 
            }

    }
}