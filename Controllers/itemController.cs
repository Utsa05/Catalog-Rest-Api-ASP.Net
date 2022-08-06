using System.Linq;
using Catelog.Dtos;
using Catelog.Entities;
using Catelog;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Controllers
{

    [ApiController]
    [Route("items")]
    public class ItemController : ControllerBase
    {
        private readonly IIitemRepository? repository;

        public ItemController(IIitemRepository repository)
        {
            this.repository = repository;
        }

        //Get/items
        [HttpGet]
        public IEnumerable<ItemDto> GetItems()
        {
            var items = repository!.GetItems().Select(item => item.AsDto());

            return items;
        }

        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetItem(Guid id)
        {
            var item = repository!.GetItem(id);
            if (item is null)
            {
                return NotFound();
            }

            return item.AsDto();
        }

        [HttpPost]
        public ActionResult<CreateItemDto> CreateItem(CreateItemDto itemDto)
        {
            Item item = new()
            {
                Id = Guid.NewGuid(),
                Name = itemDto.Name,
                Price = itemDto.Price,
                CreatedDate = DateTimeOffset.UtcNow
            };

            repository!.CreateItem(item);

            return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item.AsDto());
        }

        [HttpPut("{id}")]
        public ActionResult updateItem(Guid id, UpdateItemDto itemDto)
        {

            var exestingItem = repository!.GetItem(id);

            if (exestingItem is null)
            {
                return NotFound();
            }

            Item item = exestingItem with
            {
                Name = itemDto.Name,
                Price = itemDto.Price
            };

            repository.updateItem(item);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteItem(Guid id)
        {
            var exestingItem = repository!.GetItem(id);

            if (exestingItem is null)
            {
                return NotFound();
            }

            repository.deleteItem(id);
            return NoContent();
        }

    }
}