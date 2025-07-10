/*
 * @overview        {UbicacionesController}
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
     * TODO: Description of {@code UbicacionesController}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class UbicacionesController : Controller {
        private readonly AlmacenContext _context;

        /**
         * TODO: Description of method {@code UbicacionesController}.
         *
         */
        public UbicacionesController(AlmacenContext context) {
            _context = context;
        }

        /**
         * GET: Ubicaciones
         *
         */
        public async Task<IActionResult> Index() {
            return View(await _context.Ubicaciones.ToListAsync());
        }

        /**
         * GET: Ubicaciones/Details/5
         *
         */
        public async Task<IActionResult> Details(long? id) {
            if (id == null || _context.Ubicaciones == null) {
                return NotFound();
            }

            var ubicaciones = await _context.Ubicaciones
                .FirstOrDefaultAsync(m => m.IntIdUbicacion == id);
            if (ubicaciones == null) {
                return NotFound();
            }

            return View(ubicaciones);
        }

        /**
         * GET: Ubicaciones/Create
         *
         */
        public IActionResult Create() {
            return View();
        }

        /**
         * POST: Ubicaciones/Create
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntIdUbicacion,StrCodigoUbicacion,StrDescripcionUbicacion,BitDedicado,BitActivo,StrUsuario,DtFecha,StrCodigoZona")] Ubicaciones ubicaciones) {
            if (ModelState.IsValid) {
                _context.Add(ubicaciones);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ubicaciones);
        }

        /**
         * GET: Ubicaciones/Edit/5
         *
         */
        public async Task<IActionResult> Edit(long? id) {
            if (id == null || _context.Ubicaciones == null) {
                return NotFound();
            }

            var ubicaciones = await _context.Ubicaciones.FindAsync(id);
            if (ubicaciones == null) {
                return NotFound();
            }
            return View(ubicaciones);
        }

        /**
         * POST: Ubicaciones/Edit/5
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IntIdUbicacion,StrCodigoUbicacion,StrDescripcionUbicacion,BitDedicado,BitActivo,StrUsuario,DtFecha,StrCodigoZona")] Ubicaciones ubicaciones) {
            if (id != ubicaciones.IntIdUbicacion) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(ubicaciones);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) {
                    if (!UbicacionesExists(ubicaciones.IntIdUbicacion)) {
                        return NotFound();
                    }
                    else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ubicaciones);
        }

        /**
         * GET: Ubicaciones/Delete/5
         *
         */
        public async Task<IActionResult> Delete(long? id) {
            if (id == null || _context.Ubicaciones == null) {
                return NotFound();
            }

            var ubicaciones = await _context.Ubicaciones
                .FirstOrDefaultAsync(m => m.IntIdUbicacion == id);
            if (ubicaciones == null) {
                return NotFound();
            }

            return View(ubicaciones);
        }

        /**
         * POST: Ubicaciones/Delete/5
         *
         */
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id) {
            if (_context.Ubicaciones == null) {
                return Problem("Entity set 'AlmacenContext.Ubicaciones'  is null.");
            }
            var ubicaciones = await _context.Ubicaciones.FindAsync(id);
            if (ubicaciones != null) {
                _context.Ubicaciones.Remove(ubicaciones);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /**
         * TODO: Description of method {@code UbicacionesExists}.
         *
         */
        private bool UbicacionesExists(long? id) {
            return _context.Ubicaciones.Any(e => e.IntIdUbicacion == id);
        }
    }
}
