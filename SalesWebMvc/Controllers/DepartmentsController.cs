using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;
using SalesWebMvc.Models;

namespace SalesWebMvc.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly SalesWebMvcContext _context;

        public DepartmentsController(SalesWebMvcContext context)
        {
            _context = context;
        }

        // GET: Departmets
        public async Task<IActionResult> Index()
        {
            return View(await _context.Departmet.ToListAsync());
        }

        // GET: Departmets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departmet = await _context.Departmet
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departmet == null)
            {
                return NotFound();
            }

            return View(departmet);
        }

        // GET: Departmets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Departmets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Departmet departmet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(departmet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(departmet);
        }

        // GET: Departmets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departmet = await _context.Departmet.FindAsync(id);
            if (departmet == null)
            {
                return NotFound();
            }
            return View(departmet);
        }

        // POST: Departmets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Departmet departmet)
        {
            if (id != departmet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(departmet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartmetExists(departmet.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(departmet);
        }

        // GET: Departmets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departmet = await _context.Departmet
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departmet == null)
            {
                return NotFound();
            }

            return View(departmet);
        }

        // POST: Departmets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var departmet = await _context.Departmet.FindAsync(id);
            _context.Departmet.Remove(departmet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartmetExists(int id)
        {
            return _context.Departmet.Any(e => e.Id == id);
        }
    }
}
