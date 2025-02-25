/*
 * @fileoverview    {RemisionesController}
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
     * TODO: Description of {@code RemisionesController}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class RemisionesController : Controller {
        private readonly AlmacenContext _context;

        public RemisionesController(AlmacenContext context) {
            _context = context;
        }

        // GET: Remisiones
        public async Task<IActionResult> Index() {
            return View(await _context.Remisiones.ToListAsync());
        }

        // GET: Remisiones/Details/5
        public async Task<IActionResult> Details(long? id) {
            if (id == null || _context.Remisiones == null) {
                return NotFound();
            }

            var remisiones = await _context.Remisiones
                .FirstOrDefaultAsync(m => m.IntIdRemision == id);
            if (remisiones == null) {
                return NotFound();
            }

            return View(remisiones);
        }

        // GET: Remisiones/Create
        public IActionResult Create() {
            return View();
        }

        // POST: Remisiones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntIdRemision,StrNumeroGuia,DtFechaCreacion,DtFechaRecepcion,IntConcecutivoInterno,StrUsuario,DtFecha,IntIdAgenteDestino,IntIdAgenteOrigen,IntIdEstadoRemision")] Remisiones remisiones) {
            if (ModelState.IsValid) {
                _context.Add(remisiones);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(remisiones);
        }

        // GET: Remisiones/Edit/5
        public async Task<IActionResult> Edit(long? id) {
            if (id == null || _context.Remisiones == null) {
                return NotFound();
            }

            var remisiones = await _context.Remisiones.FindAsync(id);
            if (remisiones == null) {
                return NotFound();
            }
            return View(remisiones);
        }

        // POST: Remisiones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IntIdRemision,StrNumeroGuia,DtFechaCreacion,DtFechaRecepcion,IntConcecutivoInterno,StrUsuario,DtFecha,IntIdAgenteDestino,IntIdAgenteOrigen,IntIdEstadoRemision")] Remisiones remisiones) {
            if (id != remisiones.IntIdRemision) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(remisiones);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) {
                    if (!RemisionesExists(remisiones.IntIdRemision)) {
                        return NotFound();
                    }
                    else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(remisiones);
        }

        // GET: Remisiones/Delete/5
        public async Task<IActionResult> Delete(long? id) {
            if (id == null || _context.Remisiones == null) {
                return NotFound();
            }

            var remisiones = await _context.Remisiones
                .FirstOrDefaultAsync(m => m.IntIdRemision == id);
            if (remisiones == null) {
                return NotFound();
            }

            return View(remisiones);
        }

        // POST: Remisiones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id) {
            if (_context.Remisiones == null) {
                return Problem("Entity set 'AlmacenContext.Remisiones'  is null.");
            }
            var remisiones = await _context.Remisiones.FindAsync(id);
            if (remisiones != null) {
                _context.Remisiones.Remove(remisiones);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RemisionesExists(long? id) {
            return _context.Remisiones.Any(e => e.IntIdRemision == id);
        }
    }
}
