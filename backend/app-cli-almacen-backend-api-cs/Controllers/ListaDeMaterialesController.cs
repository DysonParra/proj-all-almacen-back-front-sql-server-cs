/*
 * @fileoverview    {ListaDeMaterialesController}
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
     * TODO: Description of {@code ListaDeMaterialesController}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class ListaDeMaterialesController : Controller {
        private readonly AlmacenContext _context;

        /**
         * TODO: Description of method {@code ListaDeMaterialesController}.
         *
         */
        public ListaDeMaterialesController(AlmacenContext context) {
            _context = context;
        }

        /**
         * GET: ListaDeMateriales
         *
         */
        public async Task<IActionResult> Index() {
            return View(await _context.ListaDeMateriales.ToListAsync());
        }

        /**
         * GET: ListaDeMateriales/Details/5
         *
         */
        public async Task<IActionResult> Details(long? id) {
            if (id == null || _context.ListaDeMateriales == null) {
                return NotFound();
            }

            var listaDeMateriales = await _context.ListaDeMateriales
                .FirstOrDefaultAsync(m => m.IntIdListaMaterial == id);
            if (listaDeMateriales == null) {
                return NotFound();
            }

            return View(listaDeMateriales);
        }

        /**
         * GET: ListaDeMateriales/Create
         *
         */
        public IActionResult Create() {
            return View();
        }

        /**
         * POST: ListaDeMateriales/Create
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntIdListaMaterial,DtFechaInicio,DtFechaFin,IntCantidad,DecPrecioUnitario,StrUsuario,DtFecha,IntIdBodega,IntIdTipoListaMaterial,IntIdListaPrecio,StrCodigoMaterial,StrCodigoComponente,IntIdUnidadMedida")] ListaDeMateriales listaDeMateriales) {
            if (ModelState.IsValid) {
                _context.Add(listaDeMateriales);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(listaDeMateriales);
        }

        /**
         * GET: ListaDeMateriales/Edit/5
         *
         */
        public async Task<IActionResult> Edit(long? id) {
            if (id == null || _context.ListaDeMateriales == null) {
                return NotFound();
            }

            var listaDeMateriales = await _context.ListaDeMateriales.FindAsync(id);
            if (listaDeMateriales == null) {
                return NotFound();
            }
            return View(listaDeMateriales);
        }

        /**
         * POST: ListaDeMateriales/Edit/5
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IntIdListaMaterial,DtFechaInicio,DtFechaFin,IntCantidad,DecPrecioUnitario,StrUsuario,DtFecha,IntIdBodega,IntIdTipoListaMaterial,IntIdListaPrecio,StrCodigoMaterial,StrCodigoComponente,IntIdUnidadMedida")] ListaDeMateriales listaDeMateriales) {
            if (id != listaDeMateriales.IntIdListaMaterial) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(listaDeMateriales);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) {
                    if (!ListaDeMaterialesExists(listaDeMateriales.IntIdListaMaterial)) {
                        return NotFound();
                    }
                    else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(listaDeMateriales);
        }

        /**
         * GET: ListaDeMateriales/Delete/5
         *
         */
        public async Task<IActionResult> Delete(long? id) {
            if (id == null || _context.ListaDeMateriales == null) {
                return NotFound();
            }

            var listaDeMateriales = await _context.ListaDeMateriales
                .FirstOrDefaultAsync(m => m.IntIdListaMaterial == id);
            if (listaDeMateriales == null) {
                return NotFound();
            }

            return View(listaDeMateriales);
        }

        /**
         * POST: ListaDeMateriales/Delete/5
         *
         */
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id) {
            if (_context.ListaDeMateriales == null) {
                return Problem("Entity set 'AlmacenContext.ListaDeMateriales'  is null.");
            }
            var listaDeMateriales = await _context.ListaDeMateriales.FindAsync(id);
            if (listaDeMateriales != null) {
                _context.ListaDeMateriales.Remove(listaDeMateriales);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /**
         * TODO: Description of method {@code ListaDeMaterialesExists}.
         *
         */
        private bool ListaDeMaterialesExists(long? id) {
            return _context.ListaDeMateriales.Any(e => e.IntIdListaMaterial == id);
        }
    }
}
