using DotNet6api.Data;
using DotNet6api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DotNet6api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly ItemsDbContext Context;
        
        //Consructor depending on DbContext
        public ItemsController(ItemsDbContext context)
        {
            Context = context;
        }

        // GET: api/<ItemsController>
        [HttpGet]
        public async Task<IEnumerable<Item>> GetAsync()
        {
            return await Context.Items.ToListAsync();
        }

        // GET api/<ItemsController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var item = Context.Items.SingleOrDefault(x => x.ItemId == id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        // POST api/<ItemsController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Post(Item item)
        {
            await Context.Items.AddAsync(item);
            await Context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = item.ItemId}, item);
        }

        // PUT api/<ItemsController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Put(int id,Item item)
        {
            if (id != item.ItemId) return BadRequest();
            
            Context.Entry(item).State = EntityState.Modified;
            await Context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE api/<ItemsController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            var itemFound = await Context.Items.FindAsync(id);
            if (itemFound == null) return NotFound();

            Context.Items.Remove(itemFound);
            Context.SaveChanges();
            return NoContent();

        }
    }
}
