using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Estimation.Domain.models;

using Estimation.Domain;
using Estimation.Domain.interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using ProjectEngine.Application.Queries.GetProjectList;
using ProjectEngine.Application.Queries.GetProjectDetail;
using ProjectEngine.Application.Command.DeleteProject;
using ProjectEngine.Application.Command.CreateProject;
using ProjectEngine.Application.Command.UpdateProject;

namespace Estimation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ProjectController : BaseController
    {

        private readonly IRepositoryWrapper _repoWrapper;
        private readonly IProjectRepository _projectRepo;
        public ProjectController(IRepositoryWrapper repoWrapper, IProjectRepository projectRepo)
        {
            _repoWrapper = repoWrapper;
            _projectRepo = projectRepo;
        }

        [HttpGet]
        public async Task<ActionResult<Project>> Get()
        {
           
            return Ok(await Mediator.Send(new GetAllProjectsQuery()));
           // var projects = _repoWrapper.Project.FindAll();
            
            //return Ok(projects);
        }

        [HttpGet("{id}", Name = "GetProject")]
        public async Task<IActionResult> Get(int id)
        {
            var projects = await Mediator.Send(new GetProjectDetailQuery { Id = id });
            return Ok(projects);
            
        }

        // POST: api/Project
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Project value)
        {

            /*
            //var User = await _userManager.GetUserAsync(HttpContext.User).ConfigureAwait(true);
            //var user = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;

            //ApplicationUser applicationUser = new ApplicationUser();
            //value.ApplicationUser = applicationUser;
            //value.ApplicationUser.Id = userId;

            _repoWrapper.Project.Create(value);
            _repoWrapper.Save();

            return CreatedAtRoute("GetProject", new { Id = value.Id }, value);
            */
            var project = await Mediator.Send(new CreateProjectCommand { Project = value });

            return Ok(project);
        }

        [Route("postExcel")]
        [HttpPost()]
        public async Task<IActionResult> PostExcel([FromBody]Project[] value)
        {
            if (value == null)
            {
                return BadRequest();
            }

            foreach (var elelment in value)
            {

                _projectRepo.Create(elelment);
                await _projectRepo.SaveChangesAsync();
            }



            return CreatedAtRoute("GetProject", new { Id = value[0].Id }, value);

        }

        // PUT: api/Project/5
        [HttpPut]
        public async Task<IActionResult> PutAsync(int id, [FromBody] Project value)
        {
            /* if (value == null)
             {

                 return BadRequest();
             }

             //var UserId = _userManager.GetUserId(HttpContext.User);
             //value.ApplicationUser.Id = UserId;

             _repoWrapper.Project.Update(value);
             _repoWrapper.Save();

             return CreatedAtRoute("GetProject", new { Id = id }, value);
             */
            var project = await Mediator.Send(new UpdateProjectCommand { Project = value });

            return Ok(project);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            // var project = _repoWrapper.Project.FindByCondition(id);
            //_repoWrapper.Project.Delete(project);
            //_repoWrapper.Save();

            //var projects = _repoWrapper.Project.FindAll();

            //return Ok(projects);

            var result = await Mediator.Send(new DeleteProjectCommand { Id = id});

        }
    }
}
