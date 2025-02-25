/*
 * @fileoverview    {ConsecutivosController}
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
     * TODO: Description of {@code ConsecutivosController}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class ConsecutivosController : Controller {
        private readonly AlmacenContext _context;

        public ConsecutivosController(AlmacenContext context) {
            _context = context;
        }

        // GET: Consecutivos
        public async Task<IActionResult> Index() {
            return View(await _context.Consecutivos.ToListAsync());
        }

        // GET: Consecutivos/Details/5
        public async Task<IActionResult> Details(long? id) {
            if (id == null || _context.Consecutivos == null) {
                return NotFound();
            }

            var consecutivos = await _context.Consecutivos
                .FirstOrDefaultAsync(m => m.IntIdConsecutivo == id);
            if (consecutivos == null) {
                return NotFound();
            }

            return View(consecutivos);
        }

        // GET: Consecutivos/Create
        public IActionResult Create() {
            return View();
        }

        // POST: Consecutivos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntIdConsecutivo,StrResolucion,IntValorInicial,IntValorFinal,IntIncremento,IntValorActual,StrCaracterLlenado,DtFechaInicial,DtFechaFinal,StrSufijo,StrPrefijo,BitHabilitado,StrUsuario,DtFecha,IntIdTipoDocumento")] Consecutivos consecutivos) {
            if (ModelState.IsValid) {
                _context.Add(consecutivos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(consecutivos);
        }

        // GET: Consecutivos/Edit/5
        public async Task<IActionResult> Edit(long? id) {
            if (id == null || _context.Consecutivos == null) {
                return NotFound();
            }

            var consecutivos = await _context.Consecutivos.FindAsync(id);
            if (consecutivos == null) {
                return NotFound();
            }
            return View(consecutivos);
        }

        // POST: Consecutivos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IntIdConsecutivo,StrResolucion,IntValorInicial,IntValorFinal,IntIncremento,IntValorActual,StrCaracterLlenado,DtFechaInicial,DtFechaFinal,StrSufijo,StrPrefijo,BitHabilitado,StrUsuario,DtFecha,IntIdTipoDocumento")] Consecutivos consecutivos) {
            if (id != consecutivos.IntIdConsecutivo) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(consecutivos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) {
                    if (!ConsecutivosExists(consecutivos.IntIdConsecutivo)) {
                        return NotFound();
                    }
                    else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(consecutivos);
        }

        // GET: Consecutivos/Delete/5
        public async Task<IActionResult> Delete(long? id) {
            if (id == null || _context.Consecutivos == null) {
                return NotFound();
            }

            var consecutivos = await _context.Consecutivos
                .FirstOrDefaultAsync(m => m.IntIdConsecutivo == id);
            if (consecutivos == null) {
                return NotFound();
            }

            return View(consecutivos);
        }

        // POST: Consecutivos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id) {
            if (_context.Consecutivos == null) {
                return Problem("Entity set 'AlmacenContext.Consecutivos'  is null.");
            }
            var consecutivos = await _context.Consecutivos.FindAsync(id);
            if (consecutivos != null) {
                _context.Consecutivos.Remove(consecutivos);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsecutivosExists(long? id) {
            return _context.Consecutivos.Any(e => e.IntIdConsecutivo == id);
        }
    }
}
