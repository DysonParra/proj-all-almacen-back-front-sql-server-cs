/*
 * @overview        {TiposMaterialesController}
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
     * TODO: Description of {@code TiposMaterialesController}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class TiposMaterialesController : Controller {
        private readonly AlmacenContext _context;

        /**
         * TODO: Description of method {@code TiposMaterialesController}.
         *
         */
        public TiposMaterialesController(AlmacenContext context) {
            _context = context;
        }

        /**
         * GET: TiposMateriales
         *
         */
        public async Task<IActionResult> Index() {
            return View(await _context.TiposMateriales.ToListAsync());
        }

        /**
         * GET: TiposMateriales/Details/5
         *
         */
        public async Task<IActionResult> Details(long? id) {
            if (id == null || _context.TiposMateriales == null) {
                return NotFound();
            }

            var tiposMateriales = await _context.TiposMateriales
                .FirstOrDefaultAsync(m => m.IntIdTipoMaterial == id);
            if (tiposMateriales == null) {
                return NotFound();
            }

            return View(tiposMateriales);
        }

        /**
         * GET: TiposMateriales/Create
         *
         */
        public IActionResult Create() {
            return View();
        }

        /**
         * POST: TiposMateriales/Create
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntIdTipoMaterial,StrTipoMaterial,StrDescripcionTipoMaterial,StrUsuario,DtFecha")] TiposMateriales tiposMateriales) {
            if (ModelState.IsValid) {
                _context.Add(tiposMateriales);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tiposMateriales);
        }

        /**
         * GET: TiposMateriales/Edit/5
         *
         */
        public async Task<IActionResult> Edit(long? id) {
            if (id == null || _context.TiposMateriales == null) {
                return NotFound();
            }

            var tiposMateriales = await _context.TiposMateriales.FindAsync(id);
            if (tiposMateriales == null) {
                return NotFound();
            }
            return View(tiposMateriales);
        }

        /**
         * POST: TiposMateriales/Edit/5
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IntIdTipoMaterial,StrTipoMaterial,StrDescripcionTipoMaterial,StrUsuario,DtFecha")] TiposMateriales tiposMateriales) {
            if (id != tiposMateriales.IntIdTipoMaterial) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(tiposMateriales);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) {
                    if (!TiposMaterialesExists(tiposMateriales.IntIdTipoMaterial)) {
                        return NotFound();
                    }
                    else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tiposMateriales);
        }

        /**
         * GET: TiposMateriales/Delete/5
         *
         */
        public async Task<IActionResult> Delete(long? id) {
            if (id == null || _context.TiposMateriales == null) {
                return NotFound();
            }

            var tiposMateriales = await _context.TiposMateriales
                .FirstOrDefaultAsync(m => m.IntIdTipoMaterial == id);
            if (tiposMateriales == null) {
                return NotFound();
            }

            return View(tiposMateriales);
        }

        /**
         * POST: TiposMateriales/Delete/5
         *
         */
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id) {
            if (_context.TiposMateriales == null) {
                return Problem("Entity set 'AlmacenContext.TiposMateriales'  is null.");
            }
            var tiposMateriales = await _context.TiposMateriales.FindAsync(id);
            if (tiposMateriales != null) {
                _context.TiposMateriales.Remove(tiposMateriales);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /**
         * TODO: Description of method {@code TiposMaterialesExists}.
         *
         */
        private bool TiposMaterialesExists(long? id) {
            return _context.TiposMateriales.Any(e => e.IntIdTipoMaterial == id);
        }
    }
}
