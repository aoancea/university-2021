using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DuckbillsController : ControllerBase
    {
        private readonly WebApplication1Context _context;

        public DuckbillsController(WebApplication1Context context)
        {
            _context = context;
        }

        // GET: api/Duckbills
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Duckbill>>> GetDuckbill()
        {
            return await _context.Duckbill.ToListAsync();
        }

        // GET: api/Duckbills/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Duckbill>> GetDuckbill(Guid id)
        {
            var duckbill = await _context.Duckbill.FindAsync(id);

            if (duckbill == null)
            {
                return NotFound();
            }

            return duckbill;
        }

        // PUT: api/Duckbills/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDuckbill(Guid id, Duckbill duckbill)
        {
            if (id != duckbill.ID)
            {
                return BadRequest();
            }

            _context.Entry(duckbill).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DuckbillExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Duckbills
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Duckbill>> PostDuckbill(Duckbill duckbill)
        {
            _context.Duckbill.Add(duckbill);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDuckbill", new { id = duckbill.ID }, duckbill);
        }

        // DELETE: api/Duckbills/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDuckbill(Guid id)
        {
            var duckbill = await _context.Duckbill.FindAsync(id);
            if (duckbill == null)
            {
                return NotFound();
            }

            _context.Duckbill.Remove(duckbill);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DuckbillExists(Guid id)
        {
            return _context.Duckbill.Any(e => e.ID == id);
        }
    }
}
