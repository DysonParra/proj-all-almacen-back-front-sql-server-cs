/*
 * @fileoverview    {RemisionesComprasMaterialesController}
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
     * TODO: Description of {@code RemisionesComprasMaterialesController}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class RemisionesComprasMaterialesController : Controller {
        private readonly AlmacenContext _context;

        /**
         * TODO: Description of method {@code RemisionesComprasMaterialesController}.
         *
         */
        public RemisionesComprasMaterialesController(AlmacenContext context) {
            _context = context;
        }

        /**
         * GET: RemisionesComprasMateriales
         *
         */
        public async Task<IActionResult> Index() {
            return View(await _context.RemisionesComprasMateriales.ToListAsync());
        }

        /**
         * GET: RemisionesComprasMateriales/Details/5
         *
         */
        public async Task<IActionResult> Details(long? id) {
            if (id == null || _context.RemisionesComprasMateriales == null) {
                return NotFound();
            }

            var remisionesComprasMateriales = await _context.RemisionesComprasMateriales
                .FirstOrDefaultAsync(m => m.IntIdRemisionCompraMaterial == id);
            if (remisionesComprasMateriales == null) {
                return NotFound();
            }

            return View(remisionesComprasMateriales);
        }

        /**
         * GET: RemisionesComprasMateriales/Create
         *
         */
        public IActionResult Create() {
            return View();
        }

        /**
         * POST: RemisionesComprasMateriales/Create
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntIdRemisionCompraMaterial,StrNumeroRemisionCompra,StrCodigoMaterial,DtFechaNecesaria,DtFechaSolicitud,DblCantidad,DecValorUnitario,FltPorcentajeDescuento,DecCostoPromedio,StrUsuario,DtFecha,IntIdMaterial,IntIdRemisionCompra")] RemisionesComprasMateriales remisionesComprasMateriales) {
            if (ModelState.IsValid) {
                _context.Add(remisionesComprasMateriales);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(remisionesComprasMateriales);
        }

        /**
         * GET: RemisionesComprasMateriales/Edit/5
         *
         */
        public async Task<IActionResult> Edit(long? id) {
            if (id == null || _context.RemisionesComprasMateriales == null) {
                return NotFound();
            }

            var remisionesComprasMateriales = await _context.RemisionesComprasMateriales.FindAsync(id);
            if (remisionesComprasMateriales == null) {
                return NotFound();
            }
            return View(remisionesComprasMateriales);
        }

        /**
         * POST: RemisionesComprasMateriales/Edit/5
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IntIdRemisionCompraMaterial,StrNumeroRemisionCompra,StrCodigoMaterial,DtFechaNecesaria,DtFechaSolicitud,DblCantidad,DecValorUnitario,FltPorcentajeDescuento,DecCostoPromedio,StrUsuario,DtFecha,IntIdMaterial,IntIdRemisionCompra")] RemisionesComprasMateriales remisionesComprasMateriales) {
            if (id != remisionesComprasMateriales.IntIdRemisionCompraMaterial) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(remisionesComprasMateriales);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) {
                    if (!RemisionesComprasMaterialesExists(remisionesComprasMateriales.IntIdRemisionCompraMaterial)) {
                        return NotFound();
                    }
                    else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(remisionesComprasMateriales);
        }

        /**
         * GET: RemisionesComprasMateriales/Delete/5
         *
         */
        public async Task<IActionResult> Delete(long? id) {
            if (id == null || _context.RemisionesComprasMateriales == null) {
                return NotFound();
            }

            var remisionesComprasMateriales = await _context.RemisionesComprasMateriales
                .FirstOrDefaultAsync(m => m.IntIdRemisionCompraMaterial == id);
            if (remisionesComprasMateriales == null) {
                return NotFound();
            }

            return View(remisionesComprasMateriales);
        }

        /**
         * POST: RemisionesComprasMateriales/Delete/5
         *
         */
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id) {
            if (_context.RemisionesComprasMateriales == null) {
                return Problem("Entity set 'AlmacenContext.RemisionesComprasMateriales'  is null.");
            }
            var remisionesComprasMateriales = await _context.RemisionesComprasMateriales.FindAsync(id);
            if (remisionesComprasMateriales != null) {
                _context.RemisionesComprasMateriales.Remove(remisionesComprasMateriales);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /**
         * TODO: Description of method {@code RemisionesComprasMaterialesExists}.
         *
         */
        private bool RemisionesComprasMaterialesExists(long? id) {
            return _context.RemisionesComprasMateriales.Any(e => e.IntIdRemisionCompraMaterial == id);
        }
    }
}
