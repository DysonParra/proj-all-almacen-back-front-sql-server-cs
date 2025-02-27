/*
 * @fileoverview    {LocalizacionesController}
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
     * TODO: Description of {@code LocalizacionesController}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class LocalizacionesController : Controller {
        private readonly AlmacenContext _context;

        /**
         * TODO: Description of method {@code LocalizacionesController}.
         *
         */
        public LocalizacionesController(AlmacenContext context) {
            _context = context;
        }

        /**
         * GET: Localizaciones
         *
         */
        public async Task<IActionResult> Index() {
            return View(await _context.Localizaciones.ToListAsync());
        }

        /**
         * GET: Localizaciones/Details/5
         *
         */
        public async Task<IActionResult> Details(long? id) {
            if (id == null || _context.Localizaciones == null) {
                return NotFound();
            }

            var localizaciones = await _context.Localizaciones
                .FirstOrDefaultAsync(m => m.IntIdLocalizacion == id);
            if (localizaciones == null) {
                return NotFound();
            }

            return View(localizaciones);
        }

        /**
         * GET: Localizaciones/Create
         *
         */
        public IActionResult Create() {
            return View();
        }

        /**
         * POST: Localizaciones/Create
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntIdLocalizacion,StrNombreLocalizacion,StrDireccion,StrCodigoPostal,StrPoBox,StrCiudad,StrPais,StrRegion,StrTelefono,StrCelular,StrFax,StrEmail,StrUsuario,DtFecha,IntIdInterlocutor,IntIdBodega")] Localizaciones localizaciones) {
            if (ModelState.IsValid) {
                _context.Add(localizaciones);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(localizaciones);
        }

        /**
         * GET: Localizaciones/Edit/5
         *
         */
        public async Task<IActionResult> Edit(long? id) {
            if (id == null || _context.Localizaciones == null) {
                return NotFound();
            }

            var localizaciones = await _context.Localizaciones.FindAsync(id);
            if (localizaciones == null) {
                return NotFound();
            }
            return View(localizaciones);
        }

        /**
         * POST: Localizaciones/Edit/5
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IntIdLocalizacion,StrNombreLocalizacion,StrDireccion,StrCodigoPostal,StrPoBox,StrCiudad,StrPais,StrRegion,StrTelefono,StrCelular,StrFax,StrEmail,StrUsuario,DtFecha,IntIdInterlocutor,IntIdBodega")] Localizaciones localizaciones) {
            if (id != localizaciones.IntIdLocalizacion) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(localizaciones);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) {
                    if (!LocalizacionesExists(localizaciones.IntIdLocalizacion)) {
                        return NotFound();
                    }
                    else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(localizaciones);
        }

        /**
         * GET: Localizaciones/Delete/5
         *
         */
        public async Task<IActionResult> Delete(long? id) {
            if (id == null || _context.Localizaciones == null) {
                return NotFound();
            }

            var localizaciones = await _context.Localizaciones
                .FirstOrDefaultAsync(m => m.IntIdLocalizacion == id);
            if (localizaciones == null) {
                return NotFound();
            }

            return View(localizaciones);
        }

        /**
         * POST: Localizaciones/Delete/5
         *
         */
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id) {
            if (_context.Localizaciones == null) {
                return Problem("Entity set 'AlmacenContext.Localizaciones'  is null.");
            }
            var localizaciones = await _context.Localizaciones.FindAsync(id);
            if (localizaciones != null) {
                _context.Localizaciones.Remove(localizaciones);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /**
         * TODO: Description of method {@code LocalizacionesExists}.
         *
         */
        private bool LocalizacionesExists(long? id) {
            return _context.Localizaciones.Any(e => e.IntIdLocalizacion == id);
        }
    }
}
