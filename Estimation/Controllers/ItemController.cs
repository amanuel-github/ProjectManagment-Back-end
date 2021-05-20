using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Estimation.Domain.interfaces;
using Estimation.Domain.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Estimation.Domain.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {

        //private readonly IRepositoryWrapper _repoWrapper;
        private readonly IItemRepository _itemRepo;
        
        public ItemController(IItemRepository itemRepo)
        {
            _itemRepo = itemRepo;
        }


        // GET: api/Item
        [HttpGet]
        public IActionResult Get()
        {
            var Items = _itemRepo.FindAll();

            return Ok(Items);
        }

        // GET: api/Item/5
        [HttpGet("{id}", Name = "GetItem")]
        public IActionResult Get(int id)
        {
            var Item = _itemRepo.FindByCondition(id);

            return Ok(Item);
        }

        // POST: api/Item
        [HttpPost]
        public IActionResult Post([FromBody] Item value)
        {
            if (value == null)
            {
                return BadRequest();
            }

            _itemRepo.Create(value);
            

            return CreatedAtRoute("GetItem", new { Id = value.Id }, value);
        }

        [Route("postExcel")]
        [HttpPost()]
        public async Task<IActionResult> PostExcel([FromBody]Item[] value)
        {
            if (value == null)
            {
                return BadRequest();
            }

            foreach(var elelment in value){
                
                _itemRepo.Create(elelment);
               await _itemRepo.SaveChangesAsync();
            }
            
            

            return CreatedAtRoute("GetItem", new { Id = value[0].Id }, value);
        }

        // PUT: api/Item/5
        [HttpPut]
        public IActionResult Put(int id, [FromBody] Item value)
        {
            if (value == null)
            {
                return BadRequest();
            }

            _itemRepo.Update(value);
            //_repoWrapper.Save();

            return CreatedAtRoute("GetItem", new { Id = value.Id }, value);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var Item = _itemRepo.FindByCondition(id).Result;

            _itemRepo.Delete(Item);
            // _repoWrapper.Save();
        }
    }
}
