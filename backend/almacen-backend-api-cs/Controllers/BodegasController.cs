/*
 * @fileoverview    {BodegasController}
 *
 * @version         2.0
 *
 * @author          Dyson Arley Parra Tilano <dysontilano@gmail.com>
 *
 * @copyright       Dyson Parra
 * @see             github.com/DysonParra
 *
 * History
 * @version 1.0     Implementación realizada.
 * @version 2.0     Documentación agregada.
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
    public class BodegasController : Controller
    {
        private readonly AlmacenContext _context;

        public BodegasController(AlmacenContext context)
        {
            _context = context;
        }

        // GET: Bodegas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bodegas.ToListAsync());
        }

        // GET: Bodegas/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Bodegas == null)
            {
                return NotFound();
            }

            var bodegas = await _context.Bodegas
                .FirstOrDefaultAsync(m => m.IntIdBodega == id);
            if (bodegas == null)
            {
                return NotFound();
            }

            return View(bodegas);
        }

        // GET: Bodegas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bodegas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntIdBodega,StrCodigoBodega,StrDescripcionBodega,BitActivo,StrUsuario,DtFecha,IntIdAgente")] Bodegas bodegas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bodegas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bodegas);
        }

        // GET: Bodegas/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Bodegas == null)
            {
                return NotFound();
            }

            var bodegas = await _context.Bodegas.FindAsync(id);
            if (bodegas == null)
            {
                return NotFound();
            }
            return View(bodegas);
        }

        // POST: Bodegas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IntIdBodega,StrCodigoBodega,StrDescripcionBodega,BitActivo,StrUsuario,DtFecha,IntIdAgente")] Bodegas bodegas)
        {
            if (id != bodegas.IntIdBodega)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bodegas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BodegasExists(bodegas.IntIdBodega))
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
            return View(bodegas);
        }

        // GET: Bodegas/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Bodegas == null)
            {
                return NotFound();
            }

            var bodegas = await _context.Bodegas
                .FirstOrDefaultAsync(m => m.IntIdBodega == id);
            if (bodegas == null)
            {
                return NotFound();
            }

            return View(bodegas);
        }

        // POST: Bodegas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            if (_context.Bodegas == null)
            {
                return Problem("Entity set 'AlmacenContext.Bodegas'  is null.");
            }
            var bodegas = await _context.Bodegas.FindAsync(id);
            if (bodegas != null)
            {
                _context.Bodegas.Remove(bodegas);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BodegasExists(long? id)
        {
            return _context.Bodegas.Any(e => e.IntIdBodega == id);
        }
    }
}
