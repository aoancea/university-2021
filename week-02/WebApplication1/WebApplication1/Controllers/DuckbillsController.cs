using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DuckbillsController : Controller
    {
        static List<Duckbill> duckbills = new List<Duckbill>()
        {
            new Duckbill() { ID = Guid.NewGuid(), Name = "Duckbill 1", Name2= "Name 2" },
            new Duckbill() { ID = Guid.NewGuid(), Name = "Duckbill 2", Name2= "Name 2" },
            new Duckbill() { ID = Guid.NewGuid(), Name = "Duckbill 3", Name2= "Name 2" },
            new Duckbill() { ID = Guid.NewGuid(), Name = "Duckbill 4", Name2= "Name 2" },
            new Duckbill() { ID = Guid.NewGuid(), Name = "Duckbill 5", Name2= "Name 2" },
        };


        private readonly WebApplication1Context _context;

        public DuckbillsController(WebApplication1Context context)
        {
            _context = context;
        }

        // GET: Duckbills
        public IActionResult Index()
        {
            return View(duckbills);
        }

        // GET: Duckbills/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var duckbill = await _context.Duckbill
                .FirstOrDefaultAsync(m => m.ID == id);
            if (duckbill == null)
            {
                return NotFound();
            }

            return View(duckbill);
        }

        // GET: Duckbills/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Duckbills/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] Duckbill duckbill)
        {
            if (ModelState.IsValid)
            {
                duckbill.ID = Guid.NewGuid();

                duckbills.Add(duckbill);

                return RedirectToAction(nameof(Index));
            }
            return View(duckbill);
        }

        // GET: Duckbills/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var duckbill = duckbills.FirstOrDefault(x => x.ID == id);
            if (duckbill == null)
            {
                return NotFound();
            }
            return View(duckbill);
        }

        // POST: Duckbills/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,Name,Name2")] Duckbill duckbill)
        {
            if (id != duckbill.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var currentDuckbill = duckbills.FirstOrDefault(x => x.ID == id);
                currentDuckbill.Name = duckbill.Name;
                currentDuckbill.Name2 = duckbill.Name2;

                return RedirectToAction(nameof(Index));
            }
            return View(duckbill);
        }

        // GET: Duckbills/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var duckbill = await _context.Duckbill
                .FirstOrDefaultAsync(m => m.ID == id);
            if (duckbill == null)
            {
                return NotFound();
            }

            return View(duckbill);
        }

        // POST: Duckbills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var duckbill = await _context.Duckbill.FindAsync(id);
            _context.Duckbill.Remove(duckbill);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DuckbillExists(Guid id)
        {
            return _context.Duckbill.Any(e => e.ID == id);
        }
    }
}
