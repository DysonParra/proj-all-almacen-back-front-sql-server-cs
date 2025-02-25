/*
 * @fileoverview    {MaterialesCostosPromediosController}
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
     * TODO: Description of {@code MaterialesCostosPromediosController}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class MaterialesCostosPromediosController : Controller {
        private readonly AlmacenContext _context;

        public MaterialesCostosPromediosController(AlmacenContext context) {
            _context = context;
        }

        // GET: MaterialesCostosPromedios
        public async Task<IActionResult> Index() {
            return View(await _context.MaterialesCostosPromedios.ToListAsync());
        }

        // GET: MaterialesCostosPromedios/Details/5
        public async Task<IActionResult> Details(long? id) {
            if (id == null || _context.MaterialesCostosPromedios == null) {
                return NotFound();
            }

            var materialesCostosPromedios = await _context.MaterialesCostosPromedios
                .FirstOrDefaultAsync(m => m.IntIdMaterialCostoPromedio == id);
            if (materialesCostosPromedios == null) {
                return NotFound();
            }

            return View(materialesCostosPromedios);
        }

        // GET: MaterialesCostosPromedios/Create
        public IActionResult Create() {
            return View();
        }

        // POST: MaterialesCostosPromedios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntIdMaterialCostoPromedio,DecCostoPromedio,DtFechaInicial,DtFechaFinal,StrUsuario,DtFecha,IntIdMaterial,StrCodigoMaterial")] MaterialesCostosPromedios materialesCostosPromedios) {
            if (ModelState.IsValid) {
                _context.Add(materialesCostosPromedios);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(materialesCostosPromedios);
        }

        // GET: MaterialesCostosPromedios/Edit/5
        public async Task<IActionResult> Edit(long? id) {
            if (id == null || _context.MaterialesCostosPromedios == null) {
                return NotFound();
            }

            var materialesCostosPromedios = await _context.MaterialesCostosPromedios.FindAsync(id);
            if (materialesCostosPromedios == null) {
                return NotFound();
            }
            return View(materialesCostosPromedios);
        }

        // POST: MaterialesCostosPromedios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IntIdMaterialCostoPromedio,DecCostoPromedio,DtFechaInicial,DtFechaFinal,StrUsuario,DtFecha,IntIdMaterial,StrCodigoMaterial")] MaterialesCostosPromedios materialesCostosPromedios) {
            if (id != materialesCostosPromedios.IntIdMaterialCostoPromedio) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(materialesCostosPromedios);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) {
                    if (!MaterialesCostosPromediosExists(materialesCostosPromedios.IntIdMaterialCostoPromedio)) {
                        return NotFound();
                    }
                    else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(materialesCostosPromedios);
        }

        // GET: MaterialesCostosPromedios/Delete/5
        public async Task<IActionResult> Delete(long? id) {
            if (id == null || _context.MaterialesCostosPromedios == null) {
                return NotFound();
            }

            var materialesCostosPromedios = await _context.MaterialesCostosPromedios
                .FirstOrDefaultAsync(m => m.IntIdMaterialCostoPromedio == id);
            if (materialesCostosPromedios == null) {
                return NotFound();
            }

            return View(materialesCostosPromedios);
        }

        // POST: MaterialesCostosPromedios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id) {
            if (_context.MaterialesCostosPromedios == null) {
                return Problem("Entity set 'AlmacenContext.MaterialesCostosPromedios'  is null.");
            }
            var materialesCostosPromedios = await _context.MaterialesCostosPromedios.FindAsync(id);
            if (materialesCostosPromedios != null) {
                _context.MaterialesCostosPromedios.Remove(materialesCostosPromedios);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MaterialesCostosPromediosExists(long? id) {
            return _context.MaterialesCostosPromedios.Any(e => e.IntIdMaterialCostoPromedio == id);
        }
    }
}
