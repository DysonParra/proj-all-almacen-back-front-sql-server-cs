/*
 * @fileoverview    {ListasPreciosMaterialesController}
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
     * TODO: Description of {@code ListasPreciosMaterialesController}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class ListasPreciosMaterialesController : Controller {
        private readonly AlmacenContext _context;

        /**
         * TODO: Description of method {@code ListasPreciosMaterialesController}.
         *
         */
        public ListasPreciosMaterialesController(AlmacenContext context) {
            _context = context;
        }

        /**
         * GET: ListasPreciosMateriales
         *
         */
        public async Task<IActionResult> Index() {
            return View(await _context.ListasPreciosMateriales.ToListAsync());
        }

        /**
         * GET: ListasPreciosMateriales/Details/5
         *
         */
        public async Task<IActionResult> Details(long? id) {
            if (id == null || _context.ListasPreciosMateriales == null) {
                return NotFound();
            }

            var listasPreciosMateriales = await _context.ListasPreciosMateriales
                .FirstOrDefaultAsync(m => m.IntId == id);
            if (listasPreciosMateriales == null) {
                return NotFound();
            }

            return View(listasPreciosMateriales);
        }

        /**
         * GET: ListasPreciosMateriales/Create
         *
         */
        public IActionResult Create() {
            return View();
        }

        /**
         * POST: ListasPreciosMateriales/Create
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntId,IntIdMateriales,IntIdListasPrecios")] ListasPreciosMateriales listasPreciosMateriales) {
            if (ModelState.IsValid) {
                _context.Add(listasPreciosMateriales);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(listasPreciosMateriales);
        }

        /**
         * GET: ListasPreciosMateriales/Edit/5
         *
         */
        public async Task<IActionResult> Edit(long? id) {
            if (id == null || _context.ListasPreciosMateriales == null) {
                return NotFound();
            }

            var listasPreciosMateriales = await _context.ListasPreciosMateriales.FindAsync(id);
            if (listasPreciosMateriales == null) {
                return NotFound();
            }
            return View(listasPreciosMateriales);
        }

        /**
         * POST: ListasPreciosMateriales/Edit/5
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IntId,IntIdMateriales,IntIdListasPrecios")] ListasPreciosMateriales listasPreciosMateriales) {
            if (id != listasPreciosMateriales.IntId) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(listasPreciosMateriales);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) {
                    if (!ListasPreciosMaterialesExists(listasPreciosMateriales.IntId)) {
                        return NotFound();
                    }
                    else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(listasPreciosMateriales);
        }

        /**
         * GET: ListasPreciosMateriales/Delete/5
         *
         */
        public async Task<IActionResult> Delete(long? id) {
            if (id == null || _context.ListasPreciosMateriales == null) {
                return NotFound();
            }

            var listasPreciosMateriales = await _context.ListasPreciosMateriales
                .FirstOrDefaultAsync(m => m.IntId == id);
            if (listasPreciosMateriales == null) {
                return NotFound();
            }

            return View(listasPreciosMateriales);
        }

        /**
         * POST: ListasPreciosMateriales/Delete/5
         *
         */
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id) {
            if (_context.ListasPreciosMateriales == null) {
                return Problem("Entity set 'AlmacenContext.ListasPreciosMateriales'  is null.");
            }
            var listasPreciosMateriales = await _context.ListasPreciosMateriales.FindAsync(id);
            if (listasPreciosMateriales != null) {
                _context.ListasPreciosMateriales.Remove(listasPreciosMateriales);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /**
         * TODO: Description of method {@code ListasPreciosMaterialesExists}.
         *
         */
        private bool ListasPreciosMaterialesExists(long? id) {
            return _context.ListasPreciosMateriales.Any(e => e.IntId == id);
        }
    }
}
