using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingListAPI.Models;
using ShoppingListAPI.Repositories;

namespace ShoppingListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IRepository<Item> _repository;

        public ItemController(IRepository<Item> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Item>>> Get()
        {
            return Ok(await _repository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetById(Guid id)
        {
            var item = await _repository.GetById(id);

            if(item == null)
                return BadRequest("Item not found");

            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<List<Item>>> Add(Item item)
        {
            _repository.Add(item);

            return Ok(await _repository.GetAll());
        }

        [HttpPut]
        public async Task<ActionResult<List<Item>>> Update(Item request)
        {
            var item = await _repository.GetById(request.Id);

            if (item == null)
                return BadRequest("Item not found");

            item.Description = request.Description;
            item.Complete = request.Complete;

            _repository.Update(item);

            return Ok(await _repository.GetAll());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Item>>> Delete(Guid id)
        {
            var item = await _repository.GetById(id);

            if (item == null)
                return BadRequest("Item not found");

            _repository.Delete(item);

            return Ok(await _repository.GetAll());
        }
    }
}
