﻿/*
 * @overview        {CotizacionController}
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
     * TODO: Description of {@code CotizacionController}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class CotizacionController : Controller {
        private readonly AlmacenContext _context;

        /**
         * TODO: Description of method {@code CotizacionController}.
         *
         */
        public CotizacionController(AlmacenContext context) {
            _context = context;
        }

        /**
         * GET: Cotizacion
         *
         */
        public async Task<IActionResult> Index() {
            return View(await _context.Cotizacion.ToListAsync());
        }

        /**
         * GET: Cotizacion/Details/5
         *
         */
        public async Task<IActionResult> Details(int? id) {
            if (id == null || _context.Cotizacion == null) {
                return NotFound();
            }

            var cotizacion = await _context.Cotizacion
                .FirstOrDefaultAsync(m => m.IntIdCotizacion == id);
            if (cotizacion == null) {
                return NotFound();
            }

            return View(cotizacion);
        }

        /**
         * GET: Cotizacion/Create
         *
         */
        public IActionResult Create() {
            return View();
        }

        /**
         * POST: Cotizacion/Create
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntIdCotizacion,IntCabecera,IntIdProveedor,StrEstado,IntCodigoMaterial,StrDescripcionMaterial,StrNombreProveedor,StrBuzonProveedor,DblCantidadRequerida,DblCantidadCotizada,DblValorCotizado,DblDescuento,DtFechaNecesaria,DtFechaEntrega,DtFechaCreacion,IntIdPlanCompra")] Cotizacion cotizacion) {
            if (ModelState.IsValid) {
                _context.Add(cotizacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cotizacion);
        }

        /**
         * GET: Cotizacion/Edit/5
         *
         */
        public async Task<IActionResult> Edit(int? id) {
            if (id == null || _context.Cotizacion == null) {
                return NotFound();
            }

            var cotizacion = await _context.Cotizacion.FindAsync(id);
            if (cotizacion == null) {
                return NotFound();
            }
            return View(cotizacion);
        }

        /**
         * POST: Cotizacion/Edit/5
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("IntIdCotizacion,IntCabecera,IntIdProveedor,StrEstado,IntCodigoMaterial,StrDescripcionMaterial,StrNombreProveedor,StrBuzonProveedor,DblCantidadRequerida,DblCantidadCotizada,DblValorCotizado,DblDescuento,DtFechaNecesaria,DtFechaEntrega,DtFechaCreacion,IntIdPlanCompra")] Cotizacion cotizacion) {
            if (id != cotizacion.IntIdCotizacion) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(cotizacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) {
                    if (!CotizacionExists(cotizacion.IntIdCotizacion)) {
                        return NotFound();
                    }
                    else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cotizacion);
        }

        /**
         * GET: Cotizacion/Delete/5
         *
         */
        public async Task<IActionResult> Delete(int? id) {
            if (id == null || _context.Cotizacion == null) {
                return NotFound();
            }

            var cotizacion = await _context.Cotizacion
                .FirstOrDefaultAsync(m => m.IntIdCotizacion == id);
            if (cotizacion == null) {
                return NotFound();
            }

            return View(cotizacion);
        }

        /**
         * POST: Cotizacion/Delete/5
         *
         */
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id) {
            if (_context.Cotizacion == null) {
                return Problem("Entity set 'AlmacenContext.Cotizacion'  is null.");
            }
            var cotizacion = await _context.Cotizacion.FindAsync(id);
            if (cotizacion != null) {
                _context.Cotizacion.Remove(cotizacion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /**
         * TODO: Description of method {@code CotizacionExists}.
         *
         */
        private bool CotizacionExists(int? id) {
            return _context.Cotizacion.Any(e => e.IntIdCotizacion == id);
        }
    }
}
