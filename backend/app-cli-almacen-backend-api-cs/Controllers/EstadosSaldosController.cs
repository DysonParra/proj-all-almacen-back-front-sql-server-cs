/*
 * @overview        {EstadosSaldosController}
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
     * TODO: Description of {@code EstadosSaldosController}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class EstadosSaldosController : Controller {
        private readonly AlmacenContext _context;

        /**
         * TODO: Description of method {@code EstadosSaldosController}.
         *
         */
        public EstadosSaldosController(AlmacenContext context) {
            _context = context;
        }

        /**
         * GET: EstadosSaldos
         *
         */
        public async Task<IActionResult> Index() {
            return View(await _context.EstadosSaldos.ToListAsync());
        }

        /**
         * GET: EstadosSaldos/Details/5
         *
         */
        public async Task<IActionResult> Details(long? id) {
            if (id == null || _context.EstadosSaldos == null) {
                return NotFound();
            }

            var estadosSaldos = await _context.EstadosSaldos
                .FirstOrDefaultAsync(m => m.IntIdEstadoSaldo == id);
            if (estadosSaldos == null) {
                return NotFound();
            }

            return View(estadosSaldos);
        }

        /**
         * GET: EstadosSaldos/Create
         *
         */
        public IActionResult Create() {
            return View();
        }

        /**
         * POST: EstadosSaldos/Create
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntIdEstadoSaldo,StrDescripcionEstadoSaldo,StrCodigoColor,BitEstaEnReposicion,StrUsuario,DtFecha")] EstadosSaldos estadosSaldos) {
            if (ModelState.IsValid) {
                _context.Add(estadosSaldos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estadosSaldos);
        }

        /**
         * GET: EstadosSaldos/Edit/5
         *
         */
        public async Task<IActionResult> Edit(long? id) {
            if (id == null || _context.EstadosSaldos == null) {
                return NotFound();
            }

            var estadosSaldos = await _context.EstadosSaldos.FindAsync(id);
            if (estadosSaldos == null) {
                return NotFound();
            }
            return View(estadosSaldos);
        }

        /**
         * POST: EstadosSaldos/Edit/5
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IntIdEstadoSaldo,StrDescripcionEstadoSaldo,StrCodigoColor,BitEstaEnReposicion,StrUsuario,DtFecha")] EstadosSaldos estadosSaldos) {
            if (id != estadosSaldos.IntIdEstadoSaldo) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(estadosSaldos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) {
                    if (!EstadosSaldosExists(estadosSaldos.IntIdEstadoSaldo)) {
                        return NotFound();
                    }
                    else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(estadosSaldos);
        }

        /**
         * GET: EstadosSaldos/Delete/5
         *
         */
        public async Task<IActionResult> Delete(long? id) {
            if (id == null || _context.EstadosSaldos == null) {
                return NotFound();
            }

            var estadosSaldos = await _context.EstadosSaldos
                .FirstOrDefaultAsync(m => m.IntIdEstadoSaldo == id);
            if (estadosSaldos == null) {
                return NotFound();
            }

            return View(estadosSaldos);
        }

        /**
         * POST: EstadosSaldos/Delete/5
         *
         */
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id) {
            if (_context.EstadosSaldos == null) {
                return Problem("Entity set 'AlmacenContext.EstadosSaldos'  is null.");
            }
            var estadosSaldos = await _context.EstadosSaldos.FindAsync(id);
            if (estadosSaldos != null) {
                _context.EstadosSaldos.Remove(estadosSaldos);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /**
         * TODO: Description of method {@code EstadosSaldosExists}.
         *
         */
        private bool EstadosSaldosExists(long? id) {
            return _context.EstadosSaldos.Any(e => e.IntIdEstadoSaldo == id);
        }
    }
}
