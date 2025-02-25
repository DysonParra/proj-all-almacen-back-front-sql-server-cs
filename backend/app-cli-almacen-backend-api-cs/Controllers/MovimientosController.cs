/*
 * @fileoverview    {MovimientosController}
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
     * TODO: Description of {@code MovimientosController}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class MovimientosController : Controller {
        private readonly AlmacenContext _context;

        public MovimientosController(AlmacenContext context) {
            _context = context;
        }

        // GET: Movimientos
        public async Task<IActionResult> Index() {
            return View(await _context.Movimientos.ToListAsync());
        }

        // GET: Movimientos/Details/5
        public async Task<IActionResult> Details(long? id) {
            if (id == null || _context.Movimientos == null) {
                return NotFound();
            }

            var movimientos = await _context.Movimientos
                .FirstOrDefaultAsync(m => m.IntIdMovimiento == id);
            if (movimientos == null) {
                return NotFound();
            }

            return View(movimientos);
        }

        // GET: Movimientos/Create
        public IActionResult Create() {
            return View();
        }

        // POST: Movimientos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntIdMovimiento,StrNumeroDocumento,DtFechaCreacion,DtFechaAnulacion,DecSobreCosto,DecSobreCostoAplicadoProducto,StrObservaciones,StrUsuario,DtFecha,IntIdBodega,IntIdConcepto,IntIdEstadoMovimiento,IntIdRemision,IntIdTipoDocumento,IntIdTipoMovimiento")] Movimientos movimientos) {
            if (ModelState.IsValid) {
                _context.Add(movimientos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movimientos);
        }

        // GET: Movimientos/Edit/5
        public async Task<IActionResult> Edit(long? id) {
            if (id == null || _context.Movimientos == null) {
                return NotFound();
            }

            var movimientos = await _context.Movimientos.FindAsync(id);
            if (movimientos == null) {
                return NotFound();
            }
            return View(movimientos);
        }

        // POST: Movimientos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IntIdMovimiento,StrNumeroDocumento,DtFechaCreacion,DtFechaAnulacion,DecSobreCosto,DecSobreCostoAplicadoProducto,StrObservaciones,StrUsuario,DtFecha,IntIdBodega,IntIdConcepto,IntIdEstadoMovimiento,IntIdRemision,IntIdTipoDocumento,IntIdTipoMovimiento")] Movimientos movimientos) {
            if (id != movimientos.IntIdMovimiento) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(movimientos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) {
                    if (!MovimientosExists(movimientos.IntIdMovimiento)) {
                        return NotFound();
                    }
                    else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movimientos);
        }

        // GET: Movimientos/Delete/5
        public async Task<IActionResult> Delete(long? id) {
            if (id == null || _context.Movimientos == null) {
                return NotFound();
            }

            var movimientos = await _context.Movimientos
                .FirstOrDefaultAsync(m => m.IntIdMovimiento == id);
            if (movimientos == null) {
                return NotFound();
            }

            return View(movimientos);
        }

        // POST: Movimientos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id) {
            if (_context.Movimientos == null) {
                return Problem("Entity set 'AlmacenContext.Movimientos'  is null.");
            }
            var movimientos = await _context.Movimientos.FindAsync(id);
            if (movimientos != null) {
                _context.Movimientos.Remove(movimientos);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovimientosExists(long? id) {
            return _context.Movimientos.Any(e => e.IntIdMovimiento == id);
        }
    }
}
