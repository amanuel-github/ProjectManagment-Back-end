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
    public class ResourceTypeController : ControllerBase
    {

        private readonly IRepositoryWrapper _repoWrapper;

        public ResourceTypeController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        // GET: api/ResourceType
        [HttpGet]
        public IActionResult Get()
        {
            var ResourceTypes = _repoWrapper.ResourceType.FindAll();

            return Ok(ResourceTypes);
        }

        // GET: api/ResourceType/5
        [HttpGet("{id}", Name = "GetResourceType")]
        public IActionResult Get(int id)
        {
            var ResourceType = _repoWrapper.ResourceType.FindByCondition(x => x.Id == id);

            return Ok(ResourceType);
        }

        // POST: api/ResourceType
        [HttpPost]
        public IActionResult Post([FromBody] ResourceType value)
        {
            if (value == null)
            {
                return BadRequest();
            }

            _repoWrapper.ResourceType.Create(value);
            _repoWrapper.Save();

            return CreatedAtRoute("GetResourceType", new { Id = value.Id }, value);
        }

        // PUT: api/ResourceType/5
        [HttpPut]
        public IActionResult Put(int id, [FromBody] ResourceType value)
        {
            if (value == null)
            {
                return BadRequest();
            }

            _repoWrapper.ResourceType.Update(value);
            _repoWrapper.Save();

            return CreatedAtRoute("GetResourceType", new { Id = value.Id }, value);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var ResourceType = _repoWrapper.ResourceType.FindByCondition(x => x.Id == id).First();

            _repoWrapper.ResourceType.Delete(ResourceType);
            _repoWrapper.Save();
        }
    }
}
