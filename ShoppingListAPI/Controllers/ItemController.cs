using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingListAPI.Dtos;
using ShoppingListAPI.Models;
using ShoppingListAPI.Services.ItemService;

namespace ShoppingListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin, User")]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Item>>> Get()
        {
            return Ok(_itemService.Get());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetById(Guid id)
        {
            var item = _itemService.GetById(id);

            if(item == null)
                return BadRequest("Item not found");

            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<List<Item>>> Add(ItemDto request)
        {
            _itemService.Add(request);

            return Ok(_itemService.Get());
        }

        [HttpPut]
        public async Task<ActionResult<List<Item>>> Update(Item request)
        {
            var item = _itemService.GetById(request.Id);

            if (item == null)
                return BadRequest("Item not found");

            item.Description = request.Description;
            item.Complete = request.Complete;

            _itemService.Update(item);

            return Ok(_itemService.Get());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Item>>> Delete(Guid id)
        {
            var item = _itemService.GetById(id);

            if (item == null)
                return BadRequest("Item not found");

            _itemService.Update(item);

            return Ok(_itemService.Get());
        }
    }
}
