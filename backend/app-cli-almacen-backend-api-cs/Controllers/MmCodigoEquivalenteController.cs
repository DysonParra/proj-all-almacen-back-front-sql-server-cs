/*
 * @overview        {MmCodigoEquivalenteController}
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
     * TODO: Description of {@code MmCodigoEquivalenteController}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class MmCodigoEquivalenteController : Controller {
        private readonly AlmacenContext _context;

        /**
         * TODO: Description of method {@code MmCodigoEquivalenteController}.
         *
         */
        public MmCodigoEquivalenteController(AlmacenContext context) {
            _context = context;
        }

        /**
         * GET: MmCodigoEquivalente
         *
         */
        public async Task<IActionResult> Index() {
            return View(await _context.MmCodigoEquivalente.ToListAsync());
        }

        /**
         * GET: MmCodigoEquivalente/Details/5
         *
         */
        public async Task<IActionResult> Details(long? id) {
            if (id == null || _context.MmCodigoEquivalente == null) {
                return NotFound();
            }

            var mmCodigoEquivalente = await _context.MmCodigoEquivalente
                .FirstOrDefaultAsync(m => m.IntIdMmCodigoEquivalente == id);
            if (mmCodigoEquivalente == null) {
                return NotFound();
            }

            return View(mmCodigoEquivalente);
        }

        /**
         * GET: MmCodigoEquivalente/Create
         *
         */
        public IActionResult Create() {
            return View();
        }

        /**
         * POST: MmCodigoEquivalente/Create
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntIdMmCodigoEquivalente,StrTipoCodigoEquivalente,StrValorCodigoEquivalente,StrUsuario,DtFecha,IntIdMaterial,StrCodigoMaterial")] MmCodigoEquivalente mmCodigoEquivalente) {
            if (ModelState.IsValid) {
                _context.Add(mmCodigoEquivalente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mmCodigoEquivalente);
        }

        /**
         * GET: MmCodigoEquivalente/Edit/5
         *
         */
        public async Task<IActionResult> Edit(long? id) {
            if (id == null || _context.MmCodigoEquivalente == null) {
                return NotFound();
            }

            var mmCodigoEquivalente = await _context.MmCodigoEquivalente.FindAsync(id);
            if (mmCodigoEquivalente == null) {
                return NotFound();
            }
            return View(mmCodigoEquivalente);
        }

        /**
         * POST: MmCodigoEquivalente/Edit/5
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IntIdMmCodigoEquivalente,StrTipoCodigoEquivalente,StrValorCodigoEquivalente,StrUsuario,DtFecha,IntIdMaterial,StrCodigoMaterial")] MmCodigoEquivalente mmCodigoEquivalente) {
            if (id != mmCodigoEquivalente.IntIdMmCodigoEquivalente) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(mmCodigoEquivalente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) {
                    if (!MmCodigoEquivalenteExists(mmCodigoEquivalente.IntIdMmCodigoEquivalente)) {
                        return NotFound();
                    }
                    else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(mmCodigoEquivalente);
        }

        /**
         * GET: MmCodigoEquivalente/Delete/5
         *
         */
        public async Task<IActionResult> Delete(long? id) {
            if (id == null || _context.MmCodigoEquivalente == null) {
                return NotFound();
            }

            var mmCodigoEquivalente = await _context.MmCodigoEquivalente
                .FirstOrDefaultAsync(m => m.IntIdMmCodigoEquivalente == id);
            if (mmCodigoEquivalente == null) {
                return NotFound();
            }

            return View(mmCodigoEquivalente);
        }

        /**
         * POST: MmCodigoEquivalente/Delete/5
         *
         */
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id) {
            if (_context.MmCodigoEquivalente == null) {
                return Problem("Entity set 'AlmacenContext.MmCodigoEquivalente'  is null.");
            }
            var mmCodigoEquivalente = await _context.MmCodigoEquivalente.FindAsync(id);
            if (mmCodigoEquivalente != null) {
                _context.MmCodigoEquivalente.Remove(mmCodigoEquivalente);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /**
         * TODO: Description of method {@code MmCodigoEquivalenteExists}.
         *
         */
        private bool MmCodigoEquivalenteExists(long? id) {
            return _context.MmCodigoEquivalente.Any(e => e.IntIdMmCodigoEquivalente == id);
        }
    }
}
