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
    public class EstimationController : ControllerBase
    {

        private readonly IEstimationProjectRepository _repoWrapper;
        
        public EstimationController(IEstimationProjectRepository repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        // GET: api/Estimation
        [HttpGet]
        public IActionResult Get()
        {
            var Estimations = _repoWrapper.FindAll();
           /* 
            foreach(var element in Estimations){

                var project = _repoWrapper.Project.FindByCondition(x => x.Id == element.ProjectId).First();
                element.Project = project;

                var descipline = _repoWrapper.Descipline.FindByCondition(x => x.Id == element.DesciplineId).First();
                element.Descipline = descipline;

                var item = _repoWrapper.Item.FindByCondition(x => x.Id == element.ItemId).First();
                element.Item = item;

                var costCode = _repoWrapper.CostCode.FindByCondition(x => x.Id == element.CostCodeId).First();
                element.CostCode = costCode;

            }
            */
            return Ok(Estimations);
        }

        // GET: api/Estimation/5
        [HttpGet("{id}", Name = "GetEstimation")]
        public IActionResult Get(int id)
        {
            //var estimation = _repoWrapper.FindByCondition(x => x.Id == id);

            //return Ok(estimation);
            return null;
        }

        // POST: api/Estimation
        [HttpPost]
        public IActionResult Post([FromBody] EstimationProject value)
        {
            if (value == null)
            {
                return BadRequest();
            }

            _repoWrapper.Create(value);
            

            return CreatedAtRoute("GetEstimation", new { Id = value.Id }, value);
        }

        [Route("postExcel")]
        [HttpPost]
        public async Task<IActionResult> PostExcel([FromBody] EstimationProject[] value)
        {
            if (value == null)
            {
                return BadRequest();
            }

             foreach (var elelment in value)
            {

                _repoWrapper.Create(elelment);
                await _repoWrapper.SaveChangesAsync();
            }


            return CreatedAtRoute("GetEstimation", new { Id = value[0].Id }, value);
        }

        // PUT: api/Estimation/5
        [HttpPut]
        public IActionResult Put(int id, [FromBody] EstimationProject value)
        {
            if (value == null)
            {
                return BadRequest();
            }

            _repoWrapper.Update(value);
            

            return CreatedAtRoute("GetEstimation", new { Id = value.Id }, value);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            //var Estimation = _repoWrapper.FindByCondition(x => x.Id == id);

            //_repoWrapper.Delete(Estimation);
            
        }
    }
}
