using DotNet6api.Data;
using DotNet6api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotNet6api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThingController : ControllerBase
    {
        public ItemsDbContext Context { get; }
        public ThingController(ItemsDbContext context)
        {
            Context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Thing>>> Get(int itemId)
        {
            var things = await Context.Things.Where(t => t.ItemId == itemId).ToListAsync();
            return things; 
        }
        [HttpPost]
        public async Task<ActionResult<List<Thing>>> Create(CreateThingDto request)
        {
            var item = await Context.Items.FindAsync(request.ItemId);
            if (item==null)
            {
                return NotFound();
            }
            var newThing = new Thing
            {
                Title = request.Title,
                ItemId = request.ItemId,
                Item = item
            };
            Context.Things.Add(newThing);
            await Context.SaveChangesAsync();
            return await Get(newThing.ItemId);
        }
    }
}
