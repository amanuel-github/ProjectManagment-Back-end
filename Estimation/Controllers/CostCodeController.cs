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
    public class CostCodeController : ControllerBase
    {

        private readonly IRepositoryWrapper _repoWrapper;

        public CostCodeController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        // GET: api/CostCode
        [HttpGet]
        public IActionResult Get()
        {
            var CostCodes = _repoWrapper.CostCode.FindAll();

            return Ok(CostCodes);
        }

        // GET: api/CostCode/5
        [HttpGet("{id}", Name = "GetCostCode")]
        public IActionResult Get(int id)
        {
            var CostCode = _repoWrapper.CostCode.FindByCondition(x => x.Id == id);

            return Ok(CostCode);
        }

        // POST: api/CostCode
        [HttpPost]
        public IActionResult Post([FromBody] CostCode value)
        {
            if(value == null)
            {
                return BadRequest();
            }

            _repoWrapper.CostCode.Create(value);
            _repoWrapper.Save();

            return CreatedAtRoute("GetCostCode", new { Id = value.Id }, value);
        }

        // PUT: api/CostCode/5
        [HttpPut]
        public IActionResult Put(int id, [FromBody] CostCode value)
        {
            if (value == null)
            {
                return BadRequest();
            }

            _repoWrapper.CostCode.Update(value);
            _repoWrapper.Save();

            return CreatedAtRoute("GetCostCode", new { Id = value.Id }, value);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var CostCode = _repoWrapper.CostCode.FindByCondition(x => x.Id == id).First();
            _repoWrapper.CostCode.Delete(CostCode);
            _repoWrapper.Save();

        }
    }
}
