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
    public class AutobusController : Controller
    {
        private readonly AppDbContext _context;

        public AutobusController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Autobus
        public async Task<IActionResult> Index()
        {
            return View(await _context.Autobuses.ToListAsync());
        }

        // GET: Autobus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autobus = await _context.Autobuses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (autobus == null)
            {
                return NotFound();
            }

            return View(autobus);
        }

        // GET: Autobus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Autobus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Marca,Modelo,Capacidad,Placa")] Autobus autobus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(autobus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(autobus);
        }

        // GET: Autobus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autobus = await _context.Autobuses.FindAsync(id);
            if (autobus == null)
            {
                return NotFound();
            }
            return View(autobus);
        }

        // POST: Autobus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Marca,Modelo,Capacidad,Placa")] Autobus autobus)
        {
            if (id != autobus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(autobus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutobusExists(autobus.Id))
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
            return View(autobus);
        }

        // GET: Autobus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autobus = await _context.Autobuses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (autobus == null)
            {
                return NotFound();
            }

            return View(autobus);
        }

        // POST: Autobus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var autobus = await _context.Autobuses.FindAsync(id);
            if (autobus != null)
            {
                _context.Autobuses.Remove(autobus);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AutobusExists(int id)
        {
            return _context.Autobuses.Any(e => e.Id == id);
        }
    }
}
