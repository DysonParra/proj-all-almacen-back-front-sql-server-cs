/*
 * @fileoverview    {TiposDocumentosConceptosController}
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
     * TODO: Description of {@code TiposDocumentosConceptosController}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class TiposDocumentosConceptosController : Controller {
        private readonly AlmacenContext _context;

        /**
         * TODO: Description of method {@code TiposDocumentosConceptosController}.
         *
         */
        public TiposDocumentosConceptosController(AlmacenContext context) {
            _context = context;
        }

        /**
         * GET: TiposDocumentosConceptos
         *
         */
        public async Task<IActionResult> Index() {
            return View(await _context.TiposDocumentosConceptos.ToListAsync());
        }

        /**
         * GET: TiposDocumentosConceptos/Details/5
         *
         */
        public async Task<IActionResult> Details(long? id) {
            if (id == null || _context.TiposDocumentosConceptos == null) {
                return NotFound();
            }

            var tiposDocumentosConceptos = await _context.TiposDocumentosConceptos
                .FirstOrDefaultAsync(m => m.IntIdTipoDocumentoConcepto == id);
            if (tiposDocumentosConceptos == null) {
                return NotFound();
            }

            return View(tiposDocumentosConceptos);
        }

        /**
         * GET: TiposDocumentosConceptos/Create
         *
         */
        public IActionResult Create() {
            return View();
        }

        /**
         * POST: TiposDocumentosConceptos/Create
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntIdTipoDocumentoConcepto,BitActivo,StrUsuario,DtFecha,IntIdConcepto,IntIdTipoDocumento")] TiposDocumentosConceptos tiposDocumentosConceptos) {
            if (ModelState.IsValid) {
                _context.Add(tiposDocumentosConceptos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tiposDocumentosConceptos);
        }

        /**
         * GET: TiposDocumentosConceptos/Edit/5
         *
         */
        public async Task<IActionResult> Edit(long? id) {
            if (id == null || _context.TiposDocumentosConceptos == null) {
                return NotFound();
            }

            var tiposDocumentosConceptos = await _context.TiposDocumentosConceptos.FindAsync(id);
            if (tiposDocumentosConceptos == null) {
                return NotFound();
            }
            return View(tiposDocumentosConceptos);
        }

        /**
         * POST: TiposDocumentosConceptos/Edit/5
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IntIdTipoDocumentoConcepto,BitActivo,StrUsuario,DtFecha,IntIdConcepto,IntIdTipoDocumento")] TiposDocumentosConceptos tiposDocumentosConceptos) {
            if (id != tiposDocumentosConceptos.IntIdTipoDocumentoConcepto) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(tiposDocumentosConceptos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) {
                    if (!TiposDocumentosConceptosExists(tiposDocumentosConceptos.IntIdTipoDocumentoConcepto)) {
                        return NotFound();
                    }
                    else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tiposDocumentosConceptos);
        }

        /**
         * GET: TiposDocumentosConceptos/Delete/5
         *
         */
        public async Task<IActionResult> Delete(long? id) {
            if (id == null || _context.TiposDocumentosConceptos == null) {
                return NotFound();
            }

            var tiposDocumentosConceptos = await _context.TiposDocumentosConceptos
                .FirstOrDefaultAsync(m => m.IntIdTipoDocumentoConcepto == id);
            if (tiposDocumentosConceptos == null) {
                return NotFound();
            }

            return View(tiposDocumentosConceptos);
        }

        /**
         * POST: TiposDocumentosConceptos/Delete/5
         *
         */
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id) {
            if (_context.TiposDocumentosConceptos == null) {
                return Problem("Entity set 'AlmacenContext.TiposDocumentosConceptos'  is null.");
            }
            var tiposDocumentosConceptos = await _context.TiposDocumentosConceptos.FindAsync(id);
            if (tiposDocumentosConceptos != null) {
                _context.TiposDocumentosConceptos.Remove(tiposDocumentosConceptos);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /**
         * TODO: Description of method {@code TiposDocumentosConceptosExists}.
         *
         */
        private bool TiposDocumentosConceptosExists(long? id) {
            return _context.TiposDocumentosConceptos.Any(e => e.IntIdTipoDocumentoConcepto == id);
        }
    }
}
