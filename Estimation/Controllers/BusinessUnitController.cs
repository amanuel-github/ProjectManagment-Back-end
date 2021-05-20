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
    public class BusinessUnitController : ControllerBase
    {
        private readonly IRepositoryWrapper _repoWrapper;

        public BusinessUnitController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        // GET: api/BusinessUnit
        [HttpGet]
        public IActionResult Get()
        {
            var businessUnits = _repoWrapper.BusinessUnit.FindAll();

            return Ok(businessUnits);
        }

        // GET: api/BusinessUnit/5
        [HttpGet("{id}", Name = "GetBusinessUnit")]
        public IActionResult Get(int id)
        {
            var businessUnit = _repoWrapper.BusinessUnit.FindByCondition(x => x.Id == id);

            return Ok(businessUnit);
        }

        // POST: api/BusinessUnit
        [HttpPost]
        public IActionResult Post([FromBody] BusinessUnit value)
        {

            if (value == null)
            {

                return BadRequest();
            }

            _repoWrapper.BusinessUnit.Create(value);
            _repoWrapper.Save();

            return CreatedAtRoute("GetBusinessUnit", new { Id = value.Id }, value);
        }

        // PUT: api/BusinessUnit/5
        [HttpPut]
        public IActionResult Put(int id, [FromBody] BusinessUnit value)
        {
            if (value == null)
            {

                return BadRequest();
            }

            _repoWrapper.BusinessUnit.Update(value);
            _repoWrapper.Save();

            return CreatedAtRoute("GetBusinessUnit", new { Id = value.Id }, value);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

            var businessUnit = _repoWrapper.BusinessUnit.FindByCondition(x => x.Id == id).First();

            _repoWrapper.BusinessUnit.Delete(businessUnit);
            _repoWrapper.Save();
        }
    }
}
