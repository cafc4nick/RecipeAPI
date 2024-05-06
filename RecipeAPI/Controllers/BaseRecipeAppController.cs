using Business;
using Business.DTOs.Interfaces;
using Business.Exceptions;
using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore.Query;

namespace RecipeAPI.Controllers
{
    public class BaseRecipeAppController<TDomain, TPost, TPut, TGet> : ControllerBase
        where TPut : IPutDto
    {
        internal readonly IBusinessBase<TDomain, TPost, TPut, TGet> _business;

        public BaseRecipeAppController(
            IBusinessBase<TDomain, TPost, TPut, TGet> business
        )
        {
            _business = business;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TGet>>> Get()
        {
            var items = await _business.GetAllAsync();
            return items;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TGet>> GetOne(Guid id)
        {
            var item = await _business.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, TPut item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }
            await _business.PutAsync(id, item);

            return NoContent();
        }

        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Guid>> Post(TPost item)
        {
            var new_item_id = await _business.AddAsync(item);
            return CreatedAtAction(nameof(Post), new_item_id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _business.DeleteAsync(id);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
