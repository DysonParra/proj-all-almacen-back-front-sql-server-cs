/*
 * @fileoverview    {MovimientosDetallesController}
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

namespace Almacen.Controllers
{
    public class MovimientosDetallesController : Controller
    {
        private readonly AlmacenContext _context;

        public MovimientosDetallesController(AlmacenContext context)
        {
            _context = context;
        }

        // GET: MovimientosDetalles
        public async Task<IActionResult> Index()
        {
            return View(await _context.MovimientosDetalles.ToListAsync());
        }

        // GET: MovimientosDetalles/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.MovimientosDetalles == null)
            {
                return NotFound();
            }

            var movimientosDetalles = await _context.MovimientosDetalles
                .FirstOrDefaultAsync(m => m.IntIdMovimientoDetalle == id);
            if (movimientosDetalles == null)
            {
                return NotFound();
            }

            return View(movimientosDetalles);
        }

        // GET: MovimientosDetalles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MovimientosDetalles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntIdMovimientoDetalle,DecValorUnitario,DecSobreCosto,DecCantidad,StrUsuario,DtFecha,IntIdEstadoSaldo,StrCodigoProducto,StrNumeroDocumento")] MovimientosDetalles movimientosDetalles)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movimientosDetalles);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movimientosDetalles);
        }

        // GET: MovimientosDetalles/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.MovimientosDetalles == null)
            {
                return NotFound();
            }

            var movimientosDetalles = await _context.MovimientosDetalles.FindAsync(id);
            if (movimientosDetalles == null)
            {
                return NotFound();
            }
            return View(movimientosDetalles);
        }

        // POST: MovimientosDetalles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IntIdMovimientoDetalle,DecValorUnitario,DecSobreCosto,DecCantidad,StrUsuario,DtFecha,IntIdEstadoSaldo,StrCodigoProducto,StrNumeroDocumento")] MovimientosDetalles movimientosDetalles)
        {
            if (id != movimientosDetalles.IntIdMovimientoDetalle)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movimientosDetalles);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovimientosDetallesExists(movimientosDetalles.IntIdMovimientoDetalle))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movimientosDetalles);
        }

        // GET: MovimientosDetalles/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.MovimientosDetalles == null)
            {
                return NotFound();
            }

            var movimientosDetalles = await _context.MovimientosDetalles
                .FirstOrDefaultAsync(m => m.IntIdMovimientoDetalle == id);
            if (movimientosDetalles == null)
            {
                return NotFound();
            }

            return View(movimientosDetalles);
        }

        // POST: MovimientosDetalles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            if (_context.MovimientosDetalles == null)
            {
                return Problem("Entity set 'AlmacenContext.MovimientosDetalles'  is null.");
            }
            var movimientosDetalles = await _context.MovimientosDetalles.FindAsync(id);
            if (movimientosDetalles != null)
            {
                _context.MovimientosDetalles.Remove(movimientosDetalles);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovimientosDetallesExists(long? id)
        {
            return _context.MovimientosDetalles.Any(e => e.IntIdMovimientoDetalle == id);
        }
    }
}
