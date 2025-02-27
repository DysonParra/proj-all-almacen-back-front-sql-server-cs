/*
 * @fileoverview    {OrdenDeTrabajoController}
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
     * TODO: Description of {@code OrdenDeTrabajoController}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class OrdenDeTrabajoController : Controller {
        private readonly AlmacenContext _context;

        /**
         * TODO: Description of method {@code OrdenDeTrabajoController}.
         *
         */
        public OrdenDeTrabajoController(AlmacenContext context) {
            _context = context;
        }

        /**
         * GET: OrdenDeTrabajo
         *
         */
        public async Task<IActionResult> Index() {
            return View(await _context.OrdenDeTrabajo.ToListAsync());
        }

        /**
         * GET: OrdenDeTrabajo/Details/5
         *
         */
        public async Task<IActionResult> Details(long? id) {
            if (id == null || _context.OrdenDeTrabajo == null) {
                return NotFound();
            }

            var ordenDeTrabajo = await _context.OrdenDeTrabajo
                .FirstOrDefaultAsync(m => m.IntIdOrdenTrabajo == id);
            if (ordenDeTrabajo == null) {
                return NotFound();
            }

            return View(ordenDeTrabajo);
        }

        /**
         * GET: OrdenDeTrabajo/Create
         *
         */
        public IActionResult Create() {
            return View();
        }

        /**
         * POST: OrdenDeTrabajo/Create
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntIdOrdenTrabajo,IntIdOperacion,IntIdEstadoOT,IntIdCentroTrabajo,StrNumeroOrden")] OrdenDeTrabajo ordenDeTrabajo) {
            if (ModelState.IsValid) {
                _context.Add(ordenDeTrabajo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ordenDeTrabajo);
        }

        /**
         * GET: OrdenDeTrabajo/Edit/5
         *
         */
        public async Task<IActionResult> Edit(long? id) {
            if (id == null || _context.OrdenDeTrabajo == null) {
                return NotFound();
            }

            var ordenDeTrabajo = await _context.OrdenDeTrabajo.FindAsync(id);
            if (ordenDeTrabajo == null) {
                return NotFound();
            }
            return View(ordenDeTrabajo);
        }

        /**
         * POST: OrdenDeTrabajo/Edit/5
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IntIdOrdenTrabajo,IntIdOperacion,IntIdEstadoOT,IntIdCentroTrabajo,StrNumeroOrden")] OrdenDeTrabajo ordenDeTrabajo) {
            if (id != ordenDeTrabajo.IntIdOrdenTrabajo) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(ordenDeTrabajo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) {
                    if (!OrdenDeTrabajoExists(ordenDeTrabajo.IntIdOrdenTrabajo)) {
                        return NotFound();
                    }
                    else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ordenDeTrabajo);
        }

        /**
         * GET: OrdenDeTrabajo/Delete/5
         *
         */
        public async Task<IActionResult> Delete(long? id) {
            if (id == null || _context.OrdenDeTrabajo == null) {
                return NotFound();
            }

            var ordenDeTrabajo = await _context.OrdenDeTrabajo
                .FirstOrDefaultAsync(m => m.IntIdOrdenTrabajo == id);
            if (ordenDeTrabajo == null) {
                return NotFound();
            }

            return View(ordenDeTrabajo);
        }

        /**
         * POST: OrdenDeTrabajo/Delete/5
         *
         */
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id) {
            if (_context.OrdenDeTrabajo == null) {
                return Problem("Entity set 'AlmacenContext.OrdenDeTrabajo'  is null.");
            }
            var ordenDeTrabajo = await _context.OrdenDeTrabajo.FindAsync(id);
            if (ordenDeTrabajo != null) {
                _context.OrdenDeTrabajo.Remove(ordenDeTrabajo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /**
         * TODO: Description of method {@code OrdenDeTrabajoExists}.
         *
         */
        private bool OrdenDeTrabajoExists(long? id) {
            return _context.OrdenDeTrabajo.Any(e => e.IntIdOrdenTrabajo == id);
        }
    }
}
