/*
 * @overview        {EstadosMovimientosController}
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
     * TODO: Description of {@code EstadosMovimientosController}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class EstadosMovimientosController : Controller {
        private readonly AlmacenContext _context;

        /**
         * TODO: Description of method {@code EstadosMovimientosController}.
         *
         */
        public EstadosMovimientosController(AlmacenContext context) {
            _context = context;
        }

        /**
         * GET: EstadosMovimientos
         *
         */
        public async Task<IActionResult> Index() {
            return View(await _context.EstadosMovimientos.ToListAsync());
        }

        /**
         * GET: EstadosMovimientos/Details/5
         *
         */
        public async Task<IActionResult> Details(long? id) {
            if (id == null || _context.EstadosMovimientos == null) {
                return NotFound();
            }

            var estadosMovimientos = await _context.EstadosMovimientos
                .FirstOrDefaultAsync(m => m.IntIdEstadoMovimiento == id);
            if (estadosMovimientos == null) {
                return NotFound();
            }

            return View(estadosMovimientos);
        }

        /**
         * GET: EstadosMovimientos/Create
         *
         */
        public IActionResult Create() {
            return View();
        }

        /**
         * POST: EstadosMovimientos/Create
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntIdEstadoMovimiento,StrDescripcionEstadoMovimiento,StrUsuario,DtFecha")] EstadosMovimientos estadosMovimientos) {
            if (ModelState.IsValid) {
                _context.Add(estadosMovimientos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estadosMovimientos);
        }

        /**
         * GET: EstadosMovimientos/Edit/5
         *
         */
        public async Task<IActionResult> Edit(long? id) {
            if (id == null || _context.EstadosMovimientos == null) {
                return NotFound();
            }

            var estadosMovimientos = await _context.EstadosMovimientos.FindAsync(id);
            if (estadosMovimientos == null) {
                return NotFound();
            }
            return View(estadosMovimientos);
        }

        /**
         * POST: EstadosMovimientos/Edit/5
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IntIdEstadoMovimiento,StrDescripcionEstadoMovimiento,StrUsuario,DtFecha")] EstadosMovimientos estadosMovimientos) {
            if (id != estadosMovimientos.IntIdEstadoMovimiento) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(estadosMovimientos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) {
                    if (!EstadosMovimientosExists(estadosMovimientos.IntIdEstadoMovimiento)) {
                        return NotFound();
                    }
                    else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(estadosMovimientos);
        }

        /**
         * GET: EstadosMovimientos/Delete/5
         *
         */
        public async Task<IActionResult> Delete(long? id) {
            if (id == null || _context.EstadosMovimientos == null) {
                return NotFound();
            }

            var estadosMovimientos = await _context.EstadosMovimientos
                .FirstOrDefaultAsync(m => m.IntIdEstadoMovimiento == id);
            if (estadosMovimientos == null) {
                return NotFound();
            }

            return View(estadosMovimientos);
        }

        /**
         * POST: EstadosMovimientos/Delete/5
         *
         */
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id) {
            if (_context.EstadosMovimientos == null) {
                return Problem("Entity set 'AlmacenContext.EstadosMovimientos'  is null.");
            }
            var estadosMovimientos = await _context.EstadosMovimientos.FindAsync(id);
            if (estadosMovimientos != null) {
                _context.EstadosMovimientos.Remove(estadosMovimientos);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /**
         * TODO: Description of method {@code EstadosMovimientosExists}.
         *
         */
        private bool EstadosMovimientosExists(long? id) {
            return _context.EstadosMovimientos.Any(e => e.IntIdEstadoMovimiento == id);
        }
    }
}
