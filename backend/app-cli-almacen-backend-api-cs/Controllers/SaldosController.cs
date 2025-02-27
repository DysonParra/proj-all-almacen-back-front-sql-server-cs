/*
 * @fileoverview    {SaldosController}
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
     * TODO: Description of {@code SaldosController}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class SaldosController : Controller {
        private readonly AlmacenContext _context;

        /**
         * TODO: Description of method {@code SaldosController}.
         *
         */
        public SaldosController(AlmacenContext context) {
            _context = context;
        }

        /**
         * GET: Saldos
         *
         */
        public async Task<IActionResult> Index() {
            return View(await _context.Saldos.ToListAsync());
        }

        /**
         * GET: Saldos/Details/5
         *
         */
        public async Task<IActionResult> Details(long? id) {
            if (id == null || _context.Saldos == null) {
                return NotFound();
            }

            var saldos = await _context.Saldos
                .FirstOrDefaultAsync(m => m.IntIdSaldo == id);
            if (saldos == null) {
                return NotFound();
            }

            return View(saldos);
        }

        /**
         * GET: Saldos/Create
         *
         */
        public IActionResult Create() {
            return View();
        }

        /**
         * POST: Saldos/Create
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntIdSaldo,DecCantidad,StrUsuario,DtFecha,IntIdEstadoSaldo,StrCodigoProducto,IntIdUbicacion")] Saldos saldos) {
            if (ModelState.IsValid) {
                _context.Add(saldos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(saldos);
        }

        /**
         * GET: Saldos/Edit/5
         *
         */
        public async Task<IActionResult> Edit(long? id) {
            if (id == null || _context.Saldos == null) {
                return NotFound();
            }

            var saldos = await _context.Saldos.FindAsync(id);
            if (saldos == null) {
                return NotFound();
            }
            return View(saldos);
        }

        /**
         * POST: Saldos/Edit/5
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IntIdSaldo,DecCantidad,StrUsuario,DtFecha,IntIdEstadoSaldo,StrCodigoProducto,IntIdUbicacion")] Saldos saldos) {
            if (id != saldos.IntIdSaldo) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(saldos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) {
                    if (!SaldosExists(saldos.IntIdSaldo)) {
                        return NotFound();
                    }
                    else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(saldos);
        }

        /**
         * GET: Saldos/Delete/5
         *
         */
        public async Task<IActionResult> Delete(long? id) {
            if (id == null || _context.Saldos == null) {
                return NotFound();
            }

            var saldos = await _context.Saldos
                .FirstOrDefaultAsync(m => m.IntIdSaldo == id);
            if (saldos == null) {
                return NotFound();
            }

            return View(saldos);
        }

        /**
         * POST: Saldos/Delete/5
         *
         */
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id) {
            if (_context.Saldos == null) {
                return Problem("Entity set 'AlmacenContext.Saldos'  is null.");
            }
            var saldos = await _context.Saldos.FindAsync(id);
            if (saldos != null) {
                _context.Saldos.Remove(saldos);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /**
         * TODO: Description of method {@code SaldosExists}.
         *
         */
        private bool SaldosExists(long? id) {
            return _context.Saldos.Any(e => e.IntIdSaldo == id);
        }
    }
}
