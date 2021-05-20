using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Estimation.Domain.interfaces;
using Estimation.Domain.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Estimation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectStatusController : ControllerBase
    {

        private readonly IRepositoryWrapper _repoWrapper;

        public ProjectStatusController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }


        // GET: api/ProjectStatus
        [HttpGet]
        public IActionResult Get()
        {
            var ProjectStatuses = _repoWrapper.ProjectStatus.FindAll();

            return Ok(ProjectStatuses);
        }

        // GET: api/ProjectStatus/5
        [HttpGet("{id}", Name = "GetProjectStatus")]
        public IActionResult Get(int id)
        {
            var ProjectStatus = _repoWrapper.ProjectStatus.FindByCondition(x => x.Id == id);

            return Ok(ProjectStatus);
        }

        // POST: api/ProjectStatus
        [HttpPost]
        public IActionResult Post([FromBody] ProjectStatus value)
        {
            if (value == null)
            {
                return BadRequest();
            }

            _repoWrapper.ProjectStatus.Create(value);
            _repoWrapper.Save();

            return CreatedAtRoute("GetProjectStatus", new { Id = value.Id }, value);
        }

        // PUT: api/ProjectStatus/5
        [HttpPut]
        public IActionResult Put(int id, [FromBody] ProjectStatus value)
        {
            if (value == null)
            {
                return BadRequest();
            }

            _repoWrapper.ProjectStatus.Update(value);
            _repoWrapper.Save();

            return CreatedAtRoute("GetProjectStatus", new { Id = value.Id }, value);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var ProjectStatus =  _repoWrapper.ProjectStatus.FindByCondition(x => x.Id == id).First();

            _repoWrapper.ProjectStatus.Delete(ProjectStatus);
            _repoWrapper.Save();
        }
    }
}
