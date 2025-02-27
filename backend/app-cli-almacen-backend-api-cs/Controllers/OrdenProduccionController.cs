/*
 * @fileoverview    {OrdenProduccionController}
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
     * TODO: Description of {@code OrdenProduccionController}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class OrdenProduccionController : Controller {
        private readonly AlmacenContext _context;

        /**
         * TODO: Description of method {@code OrdenProduccionController}.
         *
         */
        public OrdenProduccionController(AlmacenContext context) {
            _context = context;
        }

        /**
         * GET: OrdenProduccion
         *
         */
        public async Task<IActionResult> Index() {
            return View(await _context.OrdenProduccion.ToListAsync());
        }

        /**
         * GET: OrdenProduccion/Details/5
         *
         */
        public async Task<IActionResult> Details(string id) {
            if (id == null || _context.OrdenProduccion == null) {
                return NotFound();
            }

            var ordenProduccion = await _context.OrdenProduccion
                .FirstOrDefaultAsync(m => m.StrNumeroOrden == id);
            if (ordenProduccion == null) {
                return NotFound();
            }

            return View(ordenProduccion);
        }

        /**
         * GET: OrdenProduccion/Create
         *
         */
        public IActionResult Create() {
            return View();
        }

        /**
         * POST: OrdenProduccion/Create
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StrNumeroOrden,StrReferencia,IntIdEstadoProduccion,IntIdRutaOrdenTrabajo,IntIdCentroTrabajo,DtFechaEstimada,DtFechaInicioEstimada,DtFechaFinalizacion,DecCantidadPlanificada,StrOrigenOrden,StrUsuario,DtFecha,IntIdListaMateriales,StrCodigoMaterial,IntIdUnidadMedida")] OrdenProduccion ordenProduccion) {
            if (ModelState.IsValid) {
                _context.Add(ordenProduccion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ordenProduccion);
        }

        /**
         * GET: OrdenProduccion/Edit/5
         *
         */
        public async Task<IActionResult> Edit(string id) {
            if (id == null || _context.OrdenProduccion == null) {
                return NotFound();
            }

            var ordenProduccion = await _context.OrdenProduccion.FindAsync(id);
            if (ordenProduccion == null) {
                return NotFound();
            }
            return View(ordenProduccion);
        }

        /**
         * POST: OrdenProduccion/Edit/5
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("StrNumeroOrden,StrReferencia,IntIdEstadoProduccion,IntIdRutaOrdenTrabajo,IntIdCentroTrabajo,DtFechaEstimada,DtFechaInicioEstimada,DtFechaFinalizacion,DecCantidadPlanificada,StrOrigenOrden,StrUsuario,DtFecha,IntIdListaMateriales,StrCodigoMaterial,IntIdUnidadMedida")] OrdenProduccion ordenProduccion) {
            if (id != ordenProduccion.StrNumeroOrden) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(ordenProduccion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) {
                    if (!OrdenProduccionExists(ordenProduccion.StrNumeroOrden)) {
                        return NotFound();
                    }
                    else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ordenProduccion);
        }

        /**
         * GET: OrdenProduccion/Delete/5
         *
         */
        public async Task<IActionResult> Delete(string id) {
            if (id == null || _context.OrdenProduccion == null) {
                return NotFound();
            }

            var ordenProduccion = await _context.OrdenProduccion
                .FirstOrDefaultAsync(m => m.StrNumeroOrden == id);
            if (ordenProduccion == null) {
                return NotFound();
            }

            return View(ordenProduccion);
        }

        /**
         * POST: OrdenProduccion/Delete/5
         *
         */
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id) {
            if (_context.OrdenProduccion == null) {
                return Problem("Entity set 'AlmacenContext.OrdenProduccion'  is null.");
            }
            var ordenProduccion = await _context.OrdenProduccion.FindAsync(id);
            if (ordenProduccion != null) {
                _context.OrdenProduccion.Remove(ordenProduccion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /**
         * TODO: Description of method {@code OrdenProduccionExists}.
         *
         */
        private bool OrdenProduccionExists(string id) {
            return _context.OrdenProduccion.Any(e => e.StrNumeroOrden == id);
        }
    }
}
