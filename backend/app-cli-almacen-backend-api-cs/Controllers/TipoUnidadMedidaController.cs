/*
 * @overview        {TipoUnidadMedidaController}
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
     * TODO: Description of {@code TipoUnidadMedidaController}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class TipoUnidadMedidaController : Controller {
        private readonly AlmacenContext _context;

        /**
         * TODO: Description of method {@code TipoUnidadMedidaController}.
         *
         */
        public TipoUnidadMedidaController(AlmacenContext context) {
            _context = context;
        }

        /**
         * GET: TipoUnidadMedida
         *
         */
        public async Task<IActionResult> Index() {
            return View(await _context.TipoUnidadMedida.ToListAsync());
        }

        /**
         * GET: TipoUnidadMedida/Details/5
         *
         */
        public async Task<IActionResult> Details(long? id) {
            if (id == null || _context.TipoUnidadMedida == null) {
                return NotFound();
            }

            var tipoUnidadMedida = await _context.TipoUnidadMedida
                .FirstOrDefaultAsync(m => m.IntIdTipoUnidadMedida == id);
            if (tipoUnidadMedida == null) {
                return NotFound();
            }

            return View(tipoUnidadMedida);
        }

        /**
         * GET: TipoUnidadMedida/Create
         *
         */
        public IActionResult Create() {
            return View();
        }

        /**
         * POST: TipoUnidadMedida/Create
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntIdTipoUnidadMedida,StrNombre,StrUsuario,DtFecha")] TipoUnidadMedida tipoUnidadMedida) {
            if (ModelState.IsValid) {
                _context.Add(tipoUnidadMedida);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoUnidadMedida);
        }

        /**
         * GET: TipoUnidadMedida/Edit/5
         *
         */
        public async Task<IActionResult> Edit(long? id) {
            if (id == null || _context.TipoUnidadMedida == null) {
                return NotFound();
            }

            var tipoUnidadMedida = await _context.TipoUnidadMedida.FindAsync(id);
            if (tipoUnidadMedida == null) {
                return NotFound();
            }
            return View(tipoUnidadMedida);
        }

        /**
         * POST: TipoUnidadMedida/Edit/5
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IntIdTipoUnidadMedida,StrNombre,StrUsuario,DtFecha")] TipoUnidadMedida tipoUnidadMedida) {
            if (id != tipoUnidadMedida.IntIdTipoUnidadMedida) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(tipoUnidadMedida);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) {
                    if (!TipoUnidadMedidaExists(tipoUnidadMedida.IntIdTipoUnidadMedida)) {
                        return NotFound();
                    }
                    else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tipoUnidadMedida);
        }

        /**
         * GET: TipoUnidadMedida/Delete/5
         *
         */
        public async Task<IActionResult> Delete(long? id) {
            if (id == null || _context.TipoUnidadMedida == null) {
                return NotFound();
            }

            var tipoUnidadMedida = await _context.TipoUnidadMedida
                .FirstOrDefaultAsync(m => m.IntIdTipoUnidadMedida == id);
            if (tipoUnidadMedida == null) {
                return NotFound();
            }

            return View(tipoUnidadMedida);
        }

        /**
         * POST: TipoUnidadMedida/Delete/5
         *
         */
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id) {
            if (_context.TipoUnidadMedida == null) {
                return Problem("Entity set 'AlmacenContext.TipoUnidadMedida'  is null.");
            }
            var tipoUnidadMedida = await _context.TipoUnidadMedida.FindAsync(id);
            if (tipoUnidadMedida != null) {
                _context.TipoUnidadMedida.Remove(tipoUnidadMedida);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /**
         * TODO: Description of method {@code TipoUnidadMedidaExists}.
         *
         */
        private bool TipoUnidadMedidaExists(long? id) {
            return _context.TipoUnidadMedida.Any(e => e.IntIdTipoUnidadMedida == id);
        }
    }
}
