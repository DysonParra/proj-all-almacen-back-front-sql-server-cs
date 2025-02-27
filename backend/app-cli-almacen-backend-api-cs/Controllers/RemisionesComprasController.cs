/*
 * @fileoverview    {RemisionesComprasController}
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
     * TODO: Description of {@code RemisionesComprasController}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class RemisionesComprasController : Controller {
        private readonly AlmacenContext _context;

        /**
         * TODO: Description of method {@code RemisionesComprasController}.
         *
         */
        public RemisionesComprasController(AlmacenContext context) {
            _context = context;
        }

        /**
         * GET: RemisionesCompras
         *
         */
        public async Task<IActionResult> Index() {
            return View(await _context.RemisionesCompras.ToListAsync());
        }

        /**
         * GET: RemisionesCompras/Details/5
         *
         */
        public async Task<IActionResult> Details(long? id) {
            if (id == null || _context.RemisionesCompras == null) {
                return NotFound();
            }

            var remisionesCompras = await _context.RemisionesCompras
                .FirstOrDefaultAsync(m => m.IntIdRemisionCompra == id);
            if (remisionesCompras == null) {
                return NotFound();
            }

            return View(remisionesCompras);
        }

        /**
         * GET: RemisionesCompras/Create
         *
         */
        public IActionResult Create() {
            return View();
        }

        /**
         * POST: RemisionesCompras/Create
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntIdRemisionCompra,StrNumeroRemisionCompra,DtFechaContabilizacion,DtFechaValidez,DtFechaDocumento,DtFechaNecesaria,StrNumeroReferencia,DecTotalBruto,DblPorcentajeDescuento,DblPorcentajeImpuesto,DecValorTotal,StrComentarios,StrUsuario,DtFecha,IntIdInterlocutor,IntIdRemision,IntIdTipoDocumento")] RemisionesCompras remisionesCompras) {
            if (ModelState.IsValid) {
                _context.Add(remisionesCompras);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(remisionesCompras);
        }

        /**
         * GET: RemisionesCompras/Edit/5
         *
         */
        public async Task<IActionResult> Edit(long? id) {
            if (id == null || _context.RemisionesCompras == null) {
                return NotFound();
            }

            var remisionesCompras = await _context.RemisionesCompras.FindAsync(id);
            if (remisionesCompras == null) {
                return NotFound();
            }
            return View(remisionesCompras);
        }

        /**
         * POST: RemisionesCompras/Edit/5
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IntIdRemisionCompra,StrNumeroRemisionCompra,DtFechaContabilizacion,DtFechaValidez,DtFechaDocumento,DtFechaNecesaria,StrNumeroReferencia,DecTotalBruto,DblPorcentajeDescuento,DblPorcentajeImpuesto,DecValorTotal,StrComentarios,StrUsuario,DtFecha,IntIdInterlocutor,IntIdRemision,IntIdTipoDocumento")] RemisionesCompras remisionesCompras) {
            if (id != remisionesCompras.IntIdRemisionCompra) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(remisionesCompras);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) {
                    if (!RemisionesComprasExists(remisionesCompras.IntIdRemisionCompra)) {
                        return NotFound();
                    }
                    else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(remisionesCompras);
        }

        /**
         * GET: RemisionesCompras/Delete/5
         *
         */
        public async Task<IActionResult> Delete(long? id) {
            if (id == null || _context.RemisionesCompras == null) {
                return NotFound();
            }

            var remisionesCompras = await _context.RemisionesCompras
                .FirstOrDefaultAsync(m => m.IntIdRemisionCompra == id);
            if (remisionesCompras == null) {
                return NotFound();
            }

            return View(remisionesCompras);
        }

        /**
         * POST: RemisionesCompras/Delete/5
         *
         */
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id) {
            if (_context.RemisionesCompras == null) {
                return Problem("Entity set 'AlmacenContext.RemisionesCompras'  is null.");
            }
            var remisionesCompras = await _context.RemisionesCompras.FindAsync(id);
            if (remisionesCompras != null) {
                _context.RemisionesCompras.Remove(remisionesCompras);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /**
         * TODO: Description of method {@code RemisionesComprasExists}.
         *
         */
        private bool RemisionesComprasExists(long? id) {
            return _context.RemisionesCompras.Any(e => e.IntIdRemisionCompra == id);
        }
    }
}
