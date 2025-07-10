/*
 * @overview        {TipoInterlocutorComercialController}
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
     * TODO: Description of {@code TipoInterlocutorComercialController}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class TipoInterlocutorComercialController : Controller {
        private readonly AlmacenContext _context;

        /**
         * TODO: Description of method {@code TipoInterlocutorComercialController}.
         *
         */
        public TipoInterlocutorComercialController(AlmacenContext context) {
            _context = context;
        }

        /**
         * GET: TipoInterlocutorComercial
         *
         */
        public async Task<IActionResult> Index() {
            return View(await _context.TipoInterlocutorComercial.ToListAsync());
        }

        /**
         * GET: TipoInterlocutorComercial/Details/5
         *
         */
        public async Task<IActionResult> Details(long? id) {
            if (id == null || _context.TipoInterlocutorComercial == null) {
                return NotFound();
            }

            var tipoInterlocutorComercial = await _context.TipoInterlocutorComercial
                .FirstOrDefaultAsync(m => m.IntIdTipoInterlocutorComercial == id);
            if (tipoInterlocutorComercial == null) {
                return NotFound();
            }

            return View(tipoInterlocutorComercial);
        }

        /**
         * GET: TipoInterlocutorComercial/Create
         *
         */
        public IActionResult Create() {
            return View();
        }

        /**
         * POST: TipoInterlocutorComercial/Create
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntIdTipoInterlocutorComercial,StrTipoInterlocutor,StrDescripcionTipoInterlocutor,StrUsuario,DtFecha")] TipoInterlocutorComercial tipoInterlocutorComercial) {
            if (ModelState.IsValid) {
                _context.Add(tipoInterlocutorComercial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoInterlocutorComercial);
        }

        /**
         * GET: TipoInterlocutorComercial/Edit/5
         *
         */
        public async Task<IActionResult> Edit(long? id) {
            if (id == null || _context.TipoInterlocutorComercial == null) {
                return NotFound();
            }

            var tipoInterlocutorComercial = await _context.TipoInterlocutorComercial.FindAsync(id);
            if (tipoInterlocutorComercial == null) {
                return NotFound();
            }
            return View(tipoInterlocutorComercial);
        }

        /**
         * POST: TipoInterlocutorComercial/Edit/5
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IntIdTipoInterlocutorComercial,StrTipoInterlocutor,StrDescripcionTipoInterlocutor,StrUsuario,DtFecha")] TipoInterlocutorComercial tipoInterlocutorComercial) {
            if (id != tipoInterlocutorComercial.IntIdTipoInterlocutorComercial) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(tipoInterlocutorComercial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) {
                    if (!TipoInterlocutorComercialExists(tipoInterlocutorComercial.IntIdTipoInterlocutorComercial)) {
                        return NotFound();
                    }
                    else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tipoInterlocutorComercial);
        }

        /**
         * GET: TipoInterlocutorComercial/Delete/5
         *
         */
        public async Task<IActionResult> Delete(long? id) {
            if (id == null || _context.TipoInterlocutorComercial == null) {
                return NotFound();
            }

            var tipoInterlocutorComercial = await _context.TipoInterlocutorComercial
                .FirstOrDefaultAsync(m => m.IntIdTipoInterlocutorComercial == id);
            if (tipoInterlocutorComercial == null) {
                return NotFound();
            }

            return View(tipoInterlocutorComercial);
        }

        /**
         * POST: TipoInterlocutorComercial/Delete/5
         *
         */
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id) {
            if (_context.TipoInterlocutorComercial == null) {
                return Problem("Entity set 'AlmacenContext.TipoInterlocutorComercial'  is null.");
            }
            var tipoInterlocutorComercial = await _context.TipoInterlocutorComercial.FindAsync(id);
            if (tipoInterlocutorComercial != null) {
                _context.TipoInterlocutorComercial.Remove(tipoInterlocutorComercial);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /**
         * TODO: Description of method {@code TipoInterlocutorComercialExists}.
         *
         */
        private bool TipoInterlocutorComercialExists(long? id) {
            return _context.TipoInterlocutorComercial.Any(e => e.IntIdTipoInterlocutorComercial == id);
        }
    }
}
