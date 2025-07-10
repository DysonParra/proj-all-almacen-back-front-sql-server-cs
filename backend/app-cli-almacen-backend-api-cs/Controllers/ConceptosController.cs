/*
 * @overview        {ConceptosController}
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
     * TODO: Description of {@code ConceptosController}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class ConceptosController : Controller {
        private readonly AlmacenContext _context;

        /**
         * TODO: Description of method {@code ConceptosController}.
         *
         */
        public ConceptosController(AlmacenContext context) {
            _context = context;
        }

        /**
         * GET: Conceptos
         *
         */
        public async Task<IActionResult> Index() {
            return View(await _context.Conceptos.ToListAsync());
        }

        /**
         * GET: Conceptos/Details/5
         *
         */
        public async Task<IActionResult> Details(long? id) {
            if (id == null || _context.Conceptos == null) {
                return NotFound();
            }

            var conceptos = await _context.Conceptos
                .FirstOrDefaultAsync(m => m.IntIdConcepto == id);
            if (conceptos == null) {
                return NotFound();
            }

            return View(conceptos);
        }

        /**
         * GET: Conceptos/Create
         *
         */
        public IActionResult Create() {
            return View();
        }

        /**
         * POST: Conceptos/Create
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntIdConcepto,StrDescripcionConcepto,BitReposicion,BitActivo,StrUsuario,DtFecha")] Conceptos conceptos) {
            if (ModelState.IsValid) {
                _context.Add(conceptos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(conceptos);
        }

        /**
         * GET: Conceptos/Edit/5
         *
         */
        public async Task<IActionResult> Edit(long? id) {
            if (id == null || _context.Conceptos == null) {
                return NotFound();
            }

            var conceptos = await _context.Conceptos.FindAsync(id);
            if (conceptos == null) {
                return NotFound();
            }
            return View(conceptos);
        }

        /**
         * POST: Conceptos/Edit/5
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IntIdConcepto,StrDescripcionConcepto,BitReposicion,BitActivo,StrUsuario,DtFecha")] Conceptos conceptos) {
            if (id != conceptos.IntIdConcepto) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(conceptos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) {
                    if (!ConceptosExists(conceptos.IntIdConcepto)) {
                        return NotFound();
                    }
                    else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(conceptos);
        }

        /**
         * GET: Conceptos/Delete/5
         *
         */
        public async Task<IActionResult> Delete(long? id) {
            if (id == null || _context.Conceptos == null) {
                return NotFound();
            }

            var conceptos = await _context.Conceptos
                .FirstOrDefaultAsync(m => m.IntIdConcepto == id);
            if (conceptos == null) {
                return NotFound();
            }

            return View(conceptos);
        }

        /**
         * POST: Conceptos/Delete/5
         *
         */
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id) {
            if (_context.Conceptos == null) {
                return Problem("Entity set 'AlmacenContext.Conceptos'  is null.");
            }
            var conceptos = await _context.Conceptos.FindAsync(id);
            if (conceptos != null) {
                _context.Conceptos.Remove(conceptos);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /**
         * TODO: Description of method {@code ConceptosExists}.
         *
         */
        private bool ConceptosExists(long? id) {
            return _context.Conceptos.Any(e => e.IntIdConcepto == id);
        }
    }
}
