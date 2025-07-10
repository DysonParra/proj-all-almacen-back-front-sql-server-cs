/*
 * @overview        {MmTmcdDescripcionesController}
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
     * TODO: Description of {@code MmTmcdDescripcionesController}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class MmTmcdDescripcionesController : Controller {
        private readonly AlmacenContext _context;

        /**
         * TODO: Description of method {@code MmTmcdDescripcionesController}.
         *
         */
        public MmTmcdDescripcionesController(AlmacenContext context) {
            _context = context;
        }

        /**
         * GET: MmTmcdDescripciones
         *
         */
        public async Task<IActionResult> Index() {
            return View(await _context.MmTmcdDescripciones.ToListAsync());
        }

        /**
         * GET: MmTmcdDescripciones/Details/5
         *
         */
        public async Task<IActionResult> Details(long? id) {
            if (id == null || _context.MmTmcdDescripciones == null) {
                return NotFound();
            }

            var mmTmcdDescripciones = await _context.MmTmcdDescripciones
                .FirstOrDefaultAsync(m => m.IntIdMmTmcdDescripciones == id);
            if (mmTmcdDescripciones == null) {
                return NotFound();
            }

            return View(mmTmcdDescripciones);
        }

        /**
         * GET: MmTmcdDescripciones/Create
         *
         */
        public IActionResult Create() {
            return View();
        }

        /**
         * POST: MmTmcdDescripciones/Create
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntIdMmTmcdDescripciones,StrCultura,StrDescripcionMaterial,StrUsuario,DtFecha,IntIdTipoMaterialCaracteristica")] MmTmcdDescripciones mmTmcdDescripciones) {
            if (ModelState.IsValid) {
                _context.Add(mmTmcdDescripciones);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mmTmcdDescripciones);
        }

        /**
         * GET: MmTmcdDescripciones/Edit/5
         *
         */
        public async Task<IActionResult> Edit(long? id) {
            if (id == null || _context.MmTmcdDescripciones == null) {
                return NotFound();
            }

            var mmTmcdDescripciones = await _context.MmTmcdDescripciones.FindAsync(id);
            if (mmTmcdDescripciones == null) {
                return NotFound();
            }
            return View(mmTmcdDescripciones);
        }

        /**
         * POST: MmTmcdDescripciones/Edit/5
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IntIdMmTmcdDescripciones,StrCultura,StrDescripcionMaterial,StrUsuario,DtFecha,IntIdTipoMaterialCaracteristica")] MmTmcdDescripciones mmTmcdDescripciones) {
            if (id != mmTmcdDescripciones.IntIdMmTmcdDescripciones) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(mmTmcdDescripciones);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) {
                    if (!MmTmcdDescripcionesExists(mmTmcdDescripciones.IntIdMmTmcdDescripciones)) {
                        return NotFound();
                    }
                    else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(mmTmcdDescripciones);
        }

        /**
         * GET: MmTmcdDescripciones/Delete/5
         *
         */
        public async Task<IActionResult> Delete(long? id) {
            if (id == null || _context.MmTmcdDescripciones == null) {
                return NotFound();
            }

            var mmTmcdDescripciones = await _context.MmTmcdDescripciones
                .FirstOrDefaultAsync(m => m.IntIdMmTmcdDescripciones == id);
            if (mmTmcdDescripciones == null) {
                return NotFound();
            }

            return View(mmTmcdDescripciones);
        }

        /**
         * POST: MmTmcdDescripciones/Delete/5
         *
         */
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id) {
            if (_context.MmTmcdDescripciones == null) {
                return Problem("Entity set 'AlmacenContext.MmTmcdDescripciones'  is null.");
            }
            var mmTmcdDescripciones = await _context.MmTmcdDescripciones.FindAsync(id);
            if (mmTmcdDescripciones != null) {
                _context.MmTmcdDescripciones.Remove(mmTmcdDescripciones);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /**
         * TODO: Description of method {@code MmTmcdDescripcionesExists}.
         *
         */
        private bool MmTmcdDescripcionesExists(long? id) {
            return _context.MmTmcdDescripciones.Any(e => e.IntIdMmTmcdDescripciones == id);
        }
    }
}
