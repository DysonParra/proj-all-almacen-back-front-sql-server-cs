/*
 * @fileoverview    {TiposDocumentosTiposAgentesController}
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
     * TODO: Description of {@code TiposDocumentosTiposAgentesController}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class TiposDocumentosTiposAgentesController : Controller {
        private readonly AlmacenContext _context;

        public TiposDocumentosTiposAgentesController(AlmacenContext context) {
            _context = context;
        }

        // GET: TiposDocumentosTiposAgentes
        public async Task<IActionResult> Index() {
            return View(await _context.TiposDocumentosTiposAgentes.ToListAsync());
        }

        // GET: TiposDocumentosTiposAgentes/Details/5
        public async Task<IActionResult> Details(long? id) {
            if (id == null || _context.TiposDocumentosTiposAgentes == null) {
                return NotFound();
            }

            var tiposDocumentosTiposAgentes = await _context.TiposDocumentosTiposAgentes
                .FirstOrDefaultAsync(m => m.IntIdTipoDocumentoTipoAgente == id);
            if (tiposDocumentosTiposAgentes == null) {
                return NotFound();
            }

            return View(tiposDocumentosTiposAgentes);
        }

        // GET: TiposDocumentosTiposAgentes/Create
        public IActionResult Create() {
            return View();
        }

        // POST: TiposDocumentosTiposAgentes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntIdTipoDocumentoTipoAgente,BitActivo,StrUsuario,DtFecha,IntIdTipoAgente,IntIdTipoDocumento")] TiposDocumentosTiposAgentes tiposDocumentosTiposAgentes) {
            if (ModelState.IsValid) {
                _context.Add(tiposDocumentosTiposAgentes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tiposDocumentosTiposAgentes);
        }

        // GET: TiposDocumentosTiposAgentes/Edit/5
        public async Task<IActionResult> Edit(long? id) {
            if (id == null || _context.TiposDocumentosTiposAgentes == null) {
                return NotFound();
            }

            var tiposDocumentosTiposAgentes = await _context.TiposDocumentosTiposAgentes.FindAsync(id);
            if (tiposDocumentosTiposAgentes == null) {
                return NotFound();
            }
            return View(tiposDocumentosTiposAgentes);
        }

        // POST: TiposDocumentosTiposAgentes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IntIdTipoDocumentoTipoAgente,BitActivo,StrUsuario,DtFecha,IntIdTipoAgente,IntIdTipoDocumento")] TiposDocumentosTiposAgentes tiposDocumentosTiposAgentes) {
            if (id != tiposDocumentosTiposAgentes.IntIdTipoDocumentoTipoAgente) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(tiposDocumentosTiposAgentes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) {
                    if (!TiposDocumentosTiposAgentesExists(tiposDocumentosTiposAgentes.IntIdTipoDocumentoTipoAgente)) {
                        return NotFound();
                    }
                    else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tiposDocumentosTiposAgentes);
        }

        // GET: TiposDocumentosTiposAgentes/Delete/5
        public async Task<IActionResult> Delete(long? id) {
            if (id == null || _context.TiposDocumentosTiposAgentes == null) {
                return NotFound();
            }

            var tiposDocumentosTiposAgentes = await _context.TiposDocumentosTiposAgentes
                .FirstOrDefaultAsync(m => m.IntIdTipoDocumentoTipoAgente == id);
            if (tiposDocumentosTiposAgentes == null) {
                return NotFound();
            }

            return View(tiposDocumentosTiposAgentes);
        }

        // POST: TiposDocumentosTiposAgentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id) {
            if (_context.TiposDocumentosTiposAgentes == null) {
                return Problem("Entity set 'AlmacenContext.TiposDocumentosTiposAgentes'  is null.");
            }
            var tiposDocumentosTiposAgentes = await _context.TiposDocumentosTiposAgentes.FindAsync(id);
            if (tiposDocumentosTiposAgentes != null) {
                _context.TiposDocumentosTiposAgentes.Remove(tiposDocumentosTiposAgentes);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TiposDocumentosTiposAgentesExists(long? id) {
            return _context.TiposDocumentosTiposAgentes.Any(e => e.IntIdTipoDocumentoTipoAgente == id);
        }
    }
}
