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
    public class DesciplineController : ControllerBase
    {
        private readonly IRepositoryWrapper _repoWrapper;

        public DesciplineController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        // GET: api/Descipline
        [HttpGet]
        public IActionResult Get()
        {
            var Desciplines = _repoWrapper.Descipline.FindAll();

            return Ok(Desciplines);
        }

        // GET: api/Descipline/5
        [HttpGet("{id}", Name = "GetDescipline")]
        public IActionResult Get(int id)
        {
            var Descipline = _repoWrapper.Descipline.FindByCondition(x => x.Id == id);

            return Ok(Descipline);
        }

        // POST: api/Descipline
        [HttpPost]
        public IActionResult Post([FromBody] Descipline value)
        {
            if (value == null)
            {
                return BadRequest();
            }

            _repoWrapper.Descipline.Create(value);
            _repoWrapper.Save();

            return CreatedAtRoute("GetDescipline", new { Id = value.Id }, value);
           
        }

        // PUT: api/Descipline/5
        [HttpPut]
        public IActionResult Put(int id, [FromBody] Descipline value)
        {
            if (value == null)
            {
                return BadRequest();
            }

            _repoWrapper.Descipline.Update(value);
            _repoWrapper.Save();

            return CreatedAtRoute("GetDescipline", new { Id = value.Id }, value);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var Descipline = _repoWrapper.Descipline.FindByCondition(x => x.Id == id).First();

            _repoWrapper.Descipline.Delete(Descipline);
            _repoWrapper.Save();
        }
    }
}
