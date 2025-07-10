/*
 * @overview        {RemisionesVentaController}
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
     * TODO: Description of {@code RemisionesVentaController}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class RemisionesVentaController : Controller {
        private readonly AlmacenContext _context;

        /**
         * TODO: Description of method {@code RemisionesVentaController}.
         *
         */
        public RemisionesVentaController(AlmacenContext context) {
            _context = context;
        }

        /**
         * GET: RemisionesVenta
         *
         */
        public async Task<IActionResult> Index() {
            return View(await _context.RemisionesVenta.ToListAsync());
        }

        /**
         * GET: RemisionesVenta/Details/5
         *
         */
        public async Task<IActionResult> Details(string id) {
            if (id == null || _context.RemisionesVenta == null) {
                return NotFound();
            }

            var remisionesVenta = await _context.RemisionesVenta
                .FirstOrDefaultAsync(m => m.StrNumeroDocumento == id);
            if (remisionesVenta == null) {
                return NotFound();
            }

            return View(remisionesVenta);
        }

        /**
         * GET: RemisionesVenta/Create
         *
         */
        public IActionResult Create() {
            return View();
        }

        /**
         * POST: RemisionesVenta/Create
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StrNumeroDocumento,DtFechaContabilizacion,DtFechaValidez,DtFechaDocumento,DtFechaNecesaria,StrNumeroReferencia,DecTotalBruto,DblPorcentajeDescuento,DblPorcentajeImpuesto,DecValorTotal,StrComentarios,StrUsuario,DtFecha,IntIdInterlocutor,IntIdRemision,IntIdTipoDocumento,IntListaPrecio")] RemisionesVenta remisionesVenta) {
            if (ModelState.IsValid) {
                _context.Add(remisionesVenta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(remisionesVenta);
        }

        /**
         * GET: RemisionesVenta/Edit/5
         *
         */
        public async Task<IActionResult> Edit(string id) {
            if (id == null || _context.RemisionesVenta == null) {
                return NotFound();
            }

            var remisionesVenta = await _context.RemisionesVenta.FindAsync(id);
            if (remisionesVenta == null) {
                return NotFound();
            }
            return View(remisionesVenta);
        }

        /**
         * POST: RemisionesVenta/Edit/5
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("StrNumeroDocumento,DtFechaContabilizacion,DtFechaValidez,DtFechaDocumento,DtFechaNecesaria,StrNumeroReferencia,DecTotalBruto,DblPorcentajeDescuento,DblPorcentajeImpuesto,DecValorTotal,StrComentarios,StrUsuario,DtFecha,IntIdInterlocutor,IntIdRemision,IntIdTipoDocumento,IntListaPrecio")] RemisionesVenta remisionesVenta) {
            if (id != remisionesVenta.StrNumeroDocumento) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(remisionesVenta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) {
                    if (!RemisionesVentaExists(remisionesVenta.StrNumeroDocumento)) {
                        return NotFound();
                    }
                    else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(remisionesVenta);
        }

        /**
         * GET: RemisionesVenta/Delete/5
         *
         */
        public async Task<IActionResult> Delete(string id) {
            if (id == null || _context.RemisionesVenta == null) {
                return NotFound();
            }

            var remisionesVenta = await _context.RemisionesVenta
                .FirstOrDefaultAsync(m => m.StrNumeroDocumento == id);
            if (remisionesVenta == null) {
                return NotFound();
            }

            return View(remisionesVenta);
        }

        /**
         * POST: RemisionesVenta/Delete/5
         *
         */
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id) {
            if (_context.RemisionesVenta == null) {
                return Problem("Entity set 'AlmacenContext.RemisionesVenta'  is null.");
            }
            var remisionesVenta = await _context.RemisionesVenta.FindAsync(id);
            if (remisionesVenta != null) {
                _context.RemisionesVenta.Remove(remisionesVenta);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /**
         * TODO: Description of method {@code RemisionesVentaExists}.
         *
         */
        private bool RemisionesVentaExists(string id) {
            return _context.RemisionesVenta.Any(e => e.StrNumeroDocumento == id);
        }
    }
}
