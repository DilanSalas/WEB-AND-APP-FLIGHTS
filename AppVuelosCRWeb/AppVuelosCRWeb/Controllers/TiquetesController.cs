using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppVuelosCRWeb.Models;

namespace AppVuelosCRWeb.Controllers
{
    public class TiquetesController : Controller
    {
        private readonly DbConextVuelos _context;

        public TiquetesController(DbConextVuelos context)
        {
            _context = context;
        }

        // GET: Tiquetes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tiquete.OrderByDescending(p => p.precioFinal).ToListAsync());
        }

        // GET: Tiquetes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiquete = await _context.Tiquete
                .FirstOrDefaultAsync(m => m.cedula == id);
            if (tiquete == null)
            {
                return NotFound();
            }

            return View(tiquete);
        }

        // GET: Tiquetes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tiquetes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("cedula,nombreCompleto,lugarDestino,aerolinea,pagoTiquete,impuesto,precioFinal")] Tiquete tiquete)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tiquete);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tiquete);
        }

        // GET: Tiquetes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiquete = await _context.Tiquete.FindAsync(id);
            if (tiquete == null)
            {
                return NotFound();
            }
            return View(tiquete);
        }

        // POST: Tiquetes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("cedula,nombreCompleto,lugarDestino,aerolinea,pagoTiquete,impuesto,precioFinal")] Tiquete tiquete)
        {
            if (id != tiquete.cedula)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tiquete);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TiqueteExists(tiquete.cedula))
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
            return View(tiquete);
        }

        // GET: Tiquetes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiquete = await _context.Tiquete
                .FirstOrDefaultAsync(m => m.cedula == id);
            if (tiquete == null)
            {
                return NotFound();
            }

            return View(tiquete);
        }

        // POST: Tiquetes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tiquete = await _context.Tiquete.FindAsync(id);
            if (tiquete != null)
            {
                _context.Tiquete.Remove(tiquete);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TiqueteExists(string id)
        {
            return _context.Tiquete.Any(e => e.cedula == id);
        }
    }
}
