/*
 * @overview        {UnidadMedidaController}
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
     * TODO: Description of {@code UnidadMedidaController}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class UnidadMedidaController : Controller {
        private readonly AlmacenContext _context;

        /**
         * TODO: Description of method {@code UnidadMedidaController}.
         *
         */
        public UnidadMedidaController(AlmacenContext context) {
            _context = context;
        }

        /**
         * GET: UnidadMedida
         *
         */
        public async Task<IActionResult> Index() {
            return View(await _context.UnidadMedida.ToListAsync());
        }

        /**
         * GET: UnidadMedida/Details/5
         *
         */
        public async Task<IActionResult> Details(long? id) {
            if (id == null || _context.UnidadMedida == null) {
                return NotFound();
            }

            var unidadMedida = await _context.UnidadMedida
                .FirstOrDefaultAsync(m => m.IntIdUnidadMedida == id);
            if (unidadMedida == null) {
                return NotFound();
            }

            return View(unidadMedida);
        }

        /**
         * GET: UnidadMedida/Create
         *
         */
        public IActionResult Create() {
            return View();
        }

        /**
         * POST: UnidadMedida/Create
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntIdUnidadMedida,StrNombre,StrSimbolo,FltFactor,FltPrecision,FltConversion,IntDecimales,BitActivo,StrUsuario,DtFecha,IntIdTipoUnidadMedida")] UnidadMedida unidadMedida) {
            if (ModelState.IsValid) {
                _context.Add(unidadMedida);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(unidadMedida);
        }

        /**
         * GET: UnidadMedida/Edit/5
         *
         */
        public async Task<IActionResult> Edit(long? id) {
            if (id == null || _context.UnidadMedida == null) {
                return NotFound();
            }

            var unidadMedida = await _context.UnidadMedida.FindAsync(id);
            if (unidadMedida == null) {
                return NotFound();
            }
            return View(unidadMedida);
        }

        /**
         * POST: UnidadMedida/Edit/5
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IntIdUnidadMedida,StrNombre,StrSimbolo,FltFactor,FltPrecision,FltConversion,IntDecimales,BitActivo,StrUsuario,DtFecha,IntIdTipoUnidadMedida")] UnidadMedida unidadMedida) {
            if (id != unidadMedida.IntIdUnidadMedida) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(unidadMedida);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) {
                    if (!UnidadMedidaExists(unidadMedida.IntIdUnidadMedida)) {
                        return NotFound();
                    }
                    else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(unidadMedida);
        }

        /**
         * GET: UnidadMedida/Delete/5
         *
         */
        public async Task<IActionResult> Delete(long? id) {
            if (id == null || _context.UnidadMedida == null) {
                return NotFound();
            }

            var unidadMedida = await _context.UnidadMedida
                .FirstOrDefaultAsync(m => m.IntIdUnidadMedida == id);
            if (unidadMedida == null) {
                return NotFound();
            }

            return View(unidadMedida);
        }

        /**
         * POST: UnidadMedida/Delete/5
         *
         */
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id) {
            if (_context.UnidadMedida == null) {
                return Problem("Entity set 'AlmacenContext.UnidadMedida'  is null.");
            }
            var unidadMedida = await _context.UnidadMedida.FindAsync(id);
            if (unidadMedida != null) {
                _context.UnidadMedida.Remove(unidadMedida);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /**
         * TODO: Description of method {@code UnidadMedidaExists}.
         *
         */
        private bool UnidadMedidaExists(long? id) {
            return _context.UnidadMedida.Any(e => e.IntIdUnidadMedida == id);
        }
    }
}
