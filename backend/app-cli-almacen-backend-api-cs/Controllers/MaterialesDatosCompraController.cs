/*
 * @fileoverview    {MaterialesDatosCompraController}
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
     * TODO: Description of {@code MaterialesDatosCompraController}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class MaterialesDatosCompraController : Controller {
        private readonly AlmacenContext _context;

        /**
         * TODO: Description of method {@code MaterialesDatosCompraController}.
         *
         */
        public MaterialesDatosCompraController(AlmacenContext context) {
            _context = context;
        }

        /**
         * GET: MaterialesDatosCompra
         *
         */
        public async Task<IActionResult> Index() {
            return View(await _context.MaterialesDatosCompra.ToListAsync());
        }

        /**
         * GET: MaterialesDatosCompra/Details/5
         *
         */
        public async Task<IActionResult> Details(long? id) {
            if (id == null || _context.MaterialesDatosCompra == null) {
                return NotFound();
            }

            var materialesDatosCompra = await _context.MaterialesDatosCompra
                .FirstOrDefaultAsync(m => m.IntIdMaterialDatoCompra == id);
            if (materialesDatosCompra == null) {
                return NotFound();
            }

            return View(materialesDatosCompra);
        }

        /**
         * GET: MaterialesDatosCompra/Create
         *
         */
        public IActionResult Create() {
            return View();
        }

        /**
         * POST: MaterialesDatosCompra/Create
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntIdMaterialDatoCompra,StrCodigoMaterialCompra,BitAutomaticPurchase,BitGestionLotes,DecToleranciaEntregaInferior,DecToleranciaEntregaSuperior,IntDiasEntrega,BitRequiereInspeccion,StrUsuario,DtFecha,IntIdMaterial,IntIdInterlocutor,StrCodigoMaterial,IntIdUnidadMedidaBase,IntIdUnidadMedidaCompra")] MaterialesDatosCompra materialesDatosCompra) {
            if (ModelState.IsValid) {
                _context.Add(materialesDatosCompra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(materialesDatosCompra);
        }

        /**
         * GET: MaterialesDatosCompra/Edit/5
         *
         */
        public async Task<IActionResult> Edit(long? id) {
            if (id == null || _context.MaterialesDatosCompra == null) {
                return NotFound();
            }

            var materialesDatosCompra = await _context.MaterialesDatosCompra.FindAsync(id);
            if (materialesDatosCompra == null) {
                return NotFound();
            }
            return View(materialesDatosCompra);
        }

        /**
         * POST: MaterialesDatosCompra/Edit/5
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IntIdMaterialDatoCompra,StrCodigoMaterialCompra,BitAutomaticPurchase,BitGestionLotes,DecToleranciaEntregaInferior,DecToleranciaEntregaSuperior,IntDiasEntrega,BitRequiereInspeccion,StrUsuario,DtFecha,IntIdMaterial,IntIdInterlocutor,StrCodigoMaterial,IntIdUnidadMedidaBase,IntIdUnidadMedidaCompra")] MaterialesDatosCompra materialesDatosCompra) {
            if (id != materialesDatosCompra.IntIdMaterialDatoCompra) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(materialesDatosCompra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) {
                    if (!MaterialesDatosCompraExists(materialesDatosCompra.IntIdMaterialDatoCompra)) {
                        return NotFound();
                    }
                    else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(materialesDatosCompra);
        }

        /**
         * GET: MaterialesDatosCompra/Delete/5
         *
         */
        public async Task<IActionResult> Delete(long? id) {
            if (id == null || _context.MaterialesDatosCompra == null) {
                return NotFound();
            }

            var materialesDatosCompra = await _context.MaterialesDatosCompra
                .FirstOrDefaultAsync(m => m.IntIdMaterialDatoCompra == id);
            if (materialesDatosCompra == null) {
                return NotFound();
            }

            return View(materialesDatosCompra);
        }

        /**
         * POST: MaterialesDatosCompra/Delete/5
         *
         */
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id) {
            if (_context.MaterialesDatosCompra == null) {
                return Problem("Entity set 'AlmacenContext.MaterialesDatosCompra'  is null.");
            }
            var materialesDatosCompra = await _context.MaterialesDatosCompra.FindAsync(id);
            if (materialesDatosCompra != null) {
                _context.MaterialesDatosCompra.Remove(materialesDatosCompra);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /**
         * TODO: Description of method {@code MaterialesDatosCompraExists}.
         *
         */
        private bool MaterialesDatosCompraExists(long? id) {
            return _context.MaterialesDatosCompra.Any(e => e.IntIdMaterialDatoCompra == id);
        }
    }
}
