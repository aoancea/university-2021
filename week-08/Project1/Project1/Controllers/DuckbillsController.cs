using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project1.Data;
using Project1.Models;

namespace Project1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DuckbillsController : ControllerBase
    {
        private readonly Project1Context _context;

        public DuckbillsController(Project1Context context)
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
        public async Task PostDuckbill([FromBody] Duckbill duckbill)
        {
            if (duckbill.ID == Guid.Empty)
            {
                duckbill.ID = Guid.NewGuid();
            }

            _context.Duckbill.Add(duckbill);
            await _context.SaveChangesAsync();
        }

        // DELETE: api/Duckbills/5
        [HttpDelete("{id}")]
        public async Task DeleteDuckbill(Guid id)
        {
            Duckbill duckbill = await _context.Duckbill.FindAsync(id);
            if (duckbill != null)
            {
                _context.Duckbill.Remove(duckbill);
                await _context.SaveChangesAsync();
            }
        }

        private bool DuckbillExists(Guid id)
        {
            return _context.Duckbill.Any(e => e.ID == id);
        }
    }
}
