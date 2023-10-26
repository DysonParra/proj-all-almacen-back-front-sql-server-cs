/*
 * @fileoverview    {SociedadController}
 *
 * @version         2.0
 *
 * @author          Dyson Arley Parra Tilano <dysontilano@gmail.com>
 *
 * @copyright       Dyson Parra
 * @see             github.com/DysonParra
 *
 * History
 * @version 1.0     Implementation done.
 * @version 2.0     Documentation added.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Almacen.Data;
using Project.Models;

namespace Almacen.Controllers
{
    public class SociedadController : Controller
    {
        private readonly AlmacenContext _context;

        public SociedadController(AlmacenContext context)
        {
            _context = context;
        }

        // GET: Sociedad
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sociedad.ToListAsync());
        }

        // GET: Sociedad/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Sociedad == null)
            {
                return NotFound();
            }

            var sociedad = await _context.Sociedad
                .FirstOrDefaultAsync(m => m.IntIdSociedad == id);
            if (sociedad == null)
            {
                return NotFound();
            }

            return View(sociedad);
        }

        // GET: Sociedad/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sociedad/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntIdSociedad,StrCodigoSociedad,StrNombreSociedad,StrDescripcionSociedad,StrUsuario,DtFecha")] Sociedad sociedad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sociedad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sociedad);
        }

        // GET: Sociedad/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Sociedad == null)
            {
                return NotFound();
            }

            var sociedad = await _context.Sociedad.FindAsync(id);
            if (sociedad == null)
            {
                return NotFound();
            }
            return View(sociedad);
        }

        // POST: Sociedad/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IntIdSociedad,StrCodigoSociedad,StrNombreSociedad,StrDescripcionSociedad,StrUsuario,DtFecha")] Sociedad sociedad)
        {
            if (id != sociedad.IntIdSociedad)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sociedad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SociedadExists(sociedad.IntIdSociedad))
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
            return View(sociedad);
        }

        // GET: Sociedad/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Sociedad == null)
            {
                return NotFound();
            }

            var sociedad = await _context.Sociedad
                .FirstOrDefaultAsync(m => m.IntIdSociedad == id);
            if (sociedad == null)
            {
                return NotFound();
            }

            return View(sociedad);
        }

        // POST: Sociedad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            if (_context.Sociedad == null)
            {
                return Problem("Entity set 'AlmacenContext.Sociedad'  is null.");
            }
            var sociedad = await _context.Sociedad.FindAsync(id);
            if (sociedad != null)
            {
                _context.Sociedad.Remove(sociedad);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SociedadExists(long? id)
        {
            return _context.Sociedad.Any(e => e.IntIdSociedad == id);
        }
    }
}
