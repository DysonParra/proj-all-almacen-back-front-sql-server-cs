/*
 * @fileoverview    {ListasPreciosController}
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
     * TODO: Description of {@code ListasPreciosController}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class ListasPreciosController : Controller {
        private readonly AlmacenContext _context;

        /**
         * TODO: Description of method {@code ListasPreciosController}.
         *
         */
        public ListasPreciosController(AlmacenContext context) {
            _context = context;
        }

        /**
         * GET: ListasPrecios
         *
         */
        public async Task<IActionResult> Index() {
            return View(await _context.ListasPrecios.ToListAsync());
        }

        /**
         * GET: ListasPrecios/Details/5
         *
         */
        public async Task<IActionResult> Details(long? id) {
            if (id == null || _context.ListasPrecios == null) {
                return NotFound();
            }

            var listasPrecios = await _context.ListasPrecios
                .FirstOrDefaultAsync(m => m.IntIdListaPrecio == id);
            if (listasPrecios == null) {
                return NotFound();
            }

            return View(listasPrecios);
        }

        /**
         * GET: ListasPrecios/Create
         *
         */
        public IActionResult Create() {
            return View();
        }

        /**
         * POST: ListasPrecios/Create
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntIdListaPrecio,StrNombreListaPrecios,StrDescripcionListaPrecios,StrUsuario,DtFecha")] ListasPrecios listasPrecios) {
            if (ModelState.IsValid) {
                _context.Add(listasPrecios);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(listasPrecios);
        }

        /**
         * GET: ListasPrecios/Edit/5
         *
         */
        public async Task<IActionResult> Edit(long? id) {
            if (id == null || _context.ListasPrecios == null) {
                return NotFound();
            }

            var listasPrecios = await _context.ListasPrecios.FindAsync(id);
            if (listasPrecios == null) {
                return NotFound();
            }
            return View(listasPrecios);
        }

        /**
         * POST: ListasPrecios/Edit/5
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IntIdListaPrecio,StrNombreListaPrecios,StrDescripcionListaPrecios,StrUsuario,DtFecha")] ListasPrecios listasPrecios) {
            if (id != listasPrecios.IntIdListaPrecio) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(listasPrecios);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) {
                    if (!ListasPreciosExists(listasPrecios.IntIdListaPrecio)) {
                        return NotFound();
                    }
                    else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(listasPrecios);
        }

        /**
         * GET: ListasPrecios/Delete/5
         *
         */
        public async Task<IActionResult> Delete(long? id) {
            if (id == null || _context.ListasPrecios == null) {
                return NotFound();
            }

            var listasPrecios = await _context.ListasPrecios
                .FirstOrDefaultAsync(m => m.IntIdListaPrecio == id);
            if (listasPrecios == null) {
                return NotFound();
            }

            return View(listasPrecios);
        }

        /**
         * POST: ListasPrecios/Delete/5
         *
         */
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id) {
            if (_context.ListasPrecios == null) {
                return Problem("Entity set 'AlmacenContext.ListasPrecios'  is null.");
            }
            var listasPrecios = await _context.ListasPrecios.FindAsync(id);
            if (listasPrecios != null) {
                _context.ListasPrecios.Remove(listasPrecios);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /**
         * TODO: Description of method {@code ListasPreciosExists}.
         *
         */
        private bool ListasPreciosExists(long? id) {
            return _context.ListasPrecios.Any(e => e.IntIdListaPrecio == id);
        }
    }
}
