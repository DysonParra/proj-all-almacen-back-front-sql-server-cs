/*
 * @fileoverview    {EstadosRemisionesController}
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

namespace Almacen.Controllers {

    /**
     * TODO: Description of {@code EstadosRemisionesController}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class EstadosRemisionesController : Controller {
        private readonly AlmacenContext _context;

        public EstadosRemisionesController(AlmacenContext context) {
            _context = context;
        }

        // GET: EstadosRemisiones
        public async Task<IActionResult> Index() {
            return View(await _context.EstadosRemisiones.ToListAsync());
        }

        // GET: EstadosRemisiones/Details/5
        public async Task<IActionResult> Details(long? id) {
            if (id == null || _context.EstadosRemisiones == null) {
                return NotFound();
            }

            var estadosRemisiones = await _context.EstadosRemisiones
                .FirstOrDefaultAsync(m => m.IntIdEstadoRemision == id);
            if (estadosRemisiones == null) {
                return NotFound();
            }

            return View(estadosRemisiones);
        }

        // GET: EstadosRemisiones/Create
        public IActionResult Create() {
            return View();
        }

        // POST: EstadosRemisiones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntIdEstadoRemision,StrDescripcionEstadoRemision,StrUsuario,DtFecha")] EstadosRemisiones estadosRemisiones) {
            if (ModelState.IsValid) {
                _context.Add(estadosRemisiones);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estadosRemisiones);
        }

        // GET: EstadosRemisiones/Edit/5
        public async Task<IActionResult> Edit(long? id) {
            if (id == null || _context.EstadosRemisiones == null) {
                return NotFound();
            }

            var estadosRemisiones = await _context.EstadosRemisiones.FindAsync(id);
            if (estadosRemisiones == null) {
                return NotFound();
            }
            return View(estadosRemisiones);
        }

        // POST: EstadosRemisiones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IntIdEstadoRemision,StrDescripcionEstadoRemision,StrUsuario,DtFecha")] EstadosRemisiones estadosRemisiones) {
            if (id != estadosRemisiones.IntIdEstadoRemision) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(estadosRemisiones);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) {
                    if (!EstadosRemisionesExists(estadosRemisiones.IntIdEstadoRemision)) {
                        return NotFound();
                    }
                    else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(estadosRemisiones);
        }

        // GET: EstadosRemisiones/Delete/5
        public async Task<IActionResult> Delete(long? id) {
            if (id == null || _context.EstadosRemisiones == null) {
                return NotFound();
            }

            var estadosRemisiones = await _context.EstadosRemisiones
                .FirstOrDefaultAsync(m => m.IntIdEstadoRemision == id);
            if (estadosRemisiones == null) {
                return NotFound();
            }

            return View(estadosRemisiones);
        }

        // POST: EstadosRemisiones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id) {
            if (_context.EstadosRemisiones == null) {
                return Problem("Entity set 'AlmacenContext.EstadosRemisiones'  is null.");
            }
            var estadosRemisiones = await _context.EstadosRemisiones.FindAsync(id);
            if (estadosRemisiones != null) {
                _context.EstadosRemisiones.Remove(estadosRemisiones);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstadosRemisionesExists(long? id) {
            return _context.EstadosRemisiones.Any(e => e.IntIdEstadoRemision == id);
        }
    }
}
