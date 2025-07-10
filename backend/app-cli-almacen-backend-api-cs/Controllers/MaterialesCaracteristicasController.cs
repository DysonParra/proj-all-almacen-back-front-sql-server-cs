/*
 * @overview        {MaterialesCaracteristicasController}
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
     * TODO: Description of {@code MaterialesCaracteristicasController}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class MaterialesCaracteristicasController : Controller {
        private readonly AlmacenContext _context;

        /**
         * TODO: Description of method {@code MaterialesCaracteristicasController}.
         *
         */
        public MaterialesCaracteristicasController(AlmacenContext context) {
            _context = context;
        }

        /**
         * GET: MaterialesCaracteristicas
         *
         */
        public async Task<IActionResult> Index() {
            return View(await _context.MaterialesCaracteristicas.ToListAsync());
        }

        /**
         * GET: MaterialesCaracteristicas/Details/5
         *
         */
        public async Task<IActionResult> Details(long? id) {
            if (id == null || _context.MaterialesCaracteristicas == null) {
                return NotFound();
            }

            var materialesCaracteristicas = await _context.MaterialesCaracteristicas
                .FirstOrDefaultAsync(m => m.IntIdMaterialCaracteristica == id);
            if (materialesCaracteristicas == null) {
                return NotFound();
            }

            return View(materialesCaracteristicas);
        }

        /**
         * GET: MaterialesCaracteristicas/Create
         *
         */
        public IActionResult Create() {
            return View();
        }

        /**
         * POST: MaterialesCaracteristicas/Create
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntIdMaterialCaracteristica,StrValorCaracteristica,StrUsuario,DtFecha,StrCodigoMaterial,IntIdMaterial,IntIdTipoMaterialCaracteristica,IntIdTipoMaterial")] MaterialesCaracteristicas materialesCaracteristicas) {
            if (ModelState.IsValid) {
                _context.Add(materialesCaracteristicas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(materialesCaracteristicas);
        }

        /**
         * GET: MaterialesCaracteristicas/Edit/5
         *
         */
        public async Task<IActionResult> Edit(long? id) {
            if (id == null || _context.MaterialesCaracteristicas == null) {
                return NotFound();
            }

            var materialesCaracteristicas = await _context.MaterialesCaracteristicas.FindAsync(id);
            if (materialesCaracteristicas == null) {
                return NotFound();
            }
            return View(materialesCaracteristicas);
        }

        /**
         * POST: MaterialesCaracteristicas/Edit/5
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IntIdMaterialCaracteristica,StrValorCaracteristica,StrUsuario,DtFecha,StrCodigoMaterial,IntIdMaterial,IntIdTipoMaterialCaracteristica,IntIdTipoMaterial")] MaterialesCaracteristicas materialesCaracteristicas) {
            if (id != materialesCaracteristicas.IntIdMaterialCaracteristica) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(materialesCaracteristicas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) {
                    if (!MaterialesCaracteristicasExists(materialesCaracteristicas.IntIdMaterialCaracteristica)) {
                        return NotFound();
                    }
                    else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(materialesCaracteristicas);
        }

        /**
         * GET: MaterialesCaracteristicas/Delete/5
         *
         */
        public async Task<IActionResult> Delete(long? id) {
            if (id == null || _context.MaterialesCaracteristicas == null) {
                return NotFound();
            }

            var materialesCaracteristicas = await _context.MaterialesCaracteristicas
                .FirstOrDefaultAsync(m => m.IntIdMaterialCaracteristica == id);
            if (materialesCaracteristicas == null) {
                return NotFound();
            }

            return View(materialesCaracteristicas);
        }

        /**
         * POST: MaterialesCaracteristicas/Delete/5
         *
         */
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id) {
            if (_context.MaterialesCaracteristicas == null) {
                return Problem("Entity set 'AlmacenContext.MaterialesCaracteristicas'  is null.");
            }
            var materialesCaracteristicas = await _context.MaterialesCaracteristicas.FindAsync(id);
            if (materialesCaracteristicas != null) {
                _context.MaterialesCaracteristicas.Remove(materialesCaracteristicas);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /**
         * TODO: Description of method {@code MaterialesCaracteristicasExists}.
         *
         */
        private bool MaterialesCaracteristicasExists(long? id) {
            return _context.MaterialesCaracteristicas.Any(e => e.IntIdMaterialCaracteristica == id);
        }
    }
}
