/*
 * @overview        {RemisionesVentaMaterialesController}
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
     * TODO: Description of {@code RemisionesVentaMaterialesController}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class RemisionesVentaMaterialesController : Controller {
        private readonly AlmacenContext _context;

        /**
         * TODO: Description of method {@code RemisionesVentaMaterialesController}.
         *
         */
        public RemisionesVentaMaterialesController(AlmacenContext context) {
            _context = context;
        }

        /**
         * GET: RemisionesVentaMateriales
         *
         */
        public async Task<IActionResult> Index() {
            return View(await _context.RemisionesVentaMateriales.ToListAsync());
        }

        /**
         * GET: RemisionesVentaMateriales/Details/5
         *
         */
        public async Task<IActionResult> Details(long? id) {
            if (id == null || _context.RemisionesVentaMateriales == null) {
                return NotFound();
            }

            var remisionesVentaMateriales = await _context.RemisionesVentaMateriales
                .FirstOrDefaultAsync(m => m.IntIdRemisionVentaMaterial == id);
            if (remisionesVentaMateriales == null) {
                return NotFound();
            }

            return View(remisionesVentaMateriales);
        }

        /**
         * GET: RemisionesVentaMateriales/Create
         *
         */
        public IActionResult Create() {
            return View();
        }

        /**
         * POST: RemisionesVentaMateriales/Create
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntIdRemisionVentaMaterial,StrCodigoMaterial,DtFechaNecesaria,DtFechaSolicitud,DblCantidad,DecValorUnitario,FltPorcentajeDescuento,DecCostoPromedio,IntIdRemisionCompra,DecCantidadUnidadMedida,StrUsuario,DtFecha,IntIdMaterial,StrNumeroDocumento,IntIdUnidadMedida")] RemisionesVentaMateriales remisionesVentaMateriales) {
            if (ModelState.IsValid) {
                _context.Add(remisionesVentaMateriales);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(remisionesVentaMateriales);
        }

        /**
         * GET: RemisionesVentaMateriales/Edit/5
         *
         */
        public async Task<IActionResult> Edit(long? id) {
            if (id == null || _context.RemisionesVentaMateriales == null) {
                return NotFound();
            }

            var remisionesVentaMateriales = await _context.RemisionesVentaMateriales.FindAsync(id);
            if (remisionesVentaMateriales == null) {
                return NotFound();
            }
            return View(remisionesVentaMateriales);
        }

        /**
         * POST: RemisionesVentaMateriales/Edit/5
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IntIdRemisionVentaMaterial,StrCodigoMaterial,DtFechaNecesaria,DtFechaSolicitud,DblCantidad,DecValorUnitario,FltPorcentajeDescuento,DecCostoPromedio,IntIdRemisionCompra,DecCantidadUnidadMedida,StrUsuario,DtFecha,IntIdMaterial,StrNumeroDocumento,IntIdUnidadMedida")] RemisionesVentaMateriales remisionesVentaMateriales) {
            if (id != remisionesVentaMateriales.IntIdRemisionVentaMaterial) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(remisionesVentaMateriales);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) {
                    if (!RemisionesVentaMaterialesExists(remisionesVentaMateriales.IntIdRemisionVentaMaterial)) {
                        return NotFound();
                    }
                    else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(remisionesVentaMateriales);
        }

        /**
         * GET: RemisionesVentaMateriales/Delete/5
         *
         */
        public async Task<IActionResult> Delete(long? id) {
            if (id == null || _context.RemisionesVentaMateriales == null) {
                return NotFound();
            }

            var remisionesVentaMateriales = await _context.RemisionesVentaMateriales
                .FirstOrDefaultAsync(m => m.IntIdRemisionVentaMaterial == id);
            if (remisionesVentaMateriales == null) {
                return NotFound();
            }

            return View(remisionesVentaMateriales);
        }

        /**
         * POST: RemisionesVentaMateriales/Delete/5
         *
         */
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id) {
            if (_context.RemisionesVentaMateriales == null) {
                return Problem("Entity set 'AlmacenContext.RemisionesVentaMateriales'  is null.");
            }
            var remisionesVentaMateriales = await _context.RemisionesVentaMateriales.FindAsync(id);
            if (remisionesVentaMateriales != null) {
                _context.RemisionesVentaMateriales.Remove(remisionesVentaMateriales);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /**
         * TODO: Description of method {@code RemisionesVentaMaterialesExists}.
         *
         */
        private bool RemisionesVentaMaterialesExists(long? id) {
            return _context.RemisionesVentaMateriales.Any(e => e.IntIdRemisionVentaMaterial == id);
        }
    }
}
