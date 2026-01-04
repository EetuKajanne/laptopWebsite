using laptopWebsite.Data;
using laptopWebsite.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace laptopWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaptopsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LaptopsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Laptop>>> GetLaptops()
        {
            // Retrieves all laptop entries from the database
            return await _context.Laptops.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Laptop>> GetLaptop(int id)
        {
            // FindAsync searches specifically by Primary Key (Id)
            var laptop = await _context.Laptops.FindAsync(id);

            if (laptop == null)
            {
                return NotFound(); // Returns 404 if ID doesn't exist
            }

            return laptop; // Returns 200 OK with the laptop data
        }

        [HttpPost]
        public async Task<ActionResult<Laptop>> PostLaptop(Laptop laptop)
        {
            _context.Laptops.Add(laptop);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetLaptops), new { id = laptop.Id }, laptop);
        }
    }
}
