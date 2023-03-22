/*
 * @fileoverview    {TiposMovimientosController}
 *
 * @version         2.0
 *
 * @author          Dyson Arley Parra Tilano <dysontilano@gmail.com>
 *
 * @copyright       Dyson Parra
 * @see             github.com/DysonParra
 *
 * History
 * @version 1.0     Implementación realizada.
 * @version 2.0     Documentación agregada.
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
    public class TiposMovimientosController : Controller
    {
        private readonly AlmacenContext _context;

        public TiposMovimientosController(AlmacenContext context)
        {
            _context = context;
        }

        // GET: TiposMovimientos
        public async Task<IActionResult> Index()
        {
            return View(await _context.TiposMovimientos.ToListAsync());
        }

        // GET: TiposMovimientos/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.TiposMovimientos == null)
            {
                return NotFound();
            }

            var tiposMovimientos = await _context.TiposMovimientos
                .FirstOrDefaultAsync(m => m.IntIdTipoMovimiento == id);
            if (tiposMovimientos == null)
            {
                return NotFound();
            }

            return View(tiposMovimientos);
        }

        // GET: TiposMovimientos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TiposMovimientos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntIdTipoMovimiento,StrDescripcionTipoMovimiento,BitSigno,StrUsuario,DtFecha")] TiposMovimientos tiposMovimientos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tiposMovimientos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tiposMovimientos);
        }

        // GET: TiposMovimientos/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.TiposMovimientos == null)
            {
                return NotFound();
            }

            var tiposMovimientos = await _context.TiposMovimientos.FindAsync(id);
            if (tiposMovimientos == null)
            {
                return NotFound();
            }
            return View(tiposMovimientos);
        }

        // POST: TiposMovimientos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IntIdTipoMovimiento,StrDescripcionTipoMovimiento,BitSigno,StrUsuario,DtFecha")] TiposMovimientos tiposMovimientos)
        {
            if (id != tiposMovimientos.IntIdTipoMovimiento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tiposMovimientos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TiposMovimientosExists(tiposMovimientos.IntIdTipoMovimiento))
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
            return View(tiposMovimientos);
        }

        // GET: TiposMovimientos/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.TiposMovimientos == null)
            {
                return NotFound();
            }

            var tiposMovimientos = await _context.TiposMovimientos
                .FirstOrDefaultAsync(m => m.IntIdTipoMovimiento == id);
            if (tiposMovimientos == null)
            {
                return NotFound();
            }

            return View(tiposMovimientos);
        }

        // POST: TiposMovimientos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            if (_context.TiposMovimientos == null)
            {
                return Problem("Entity set 'AlmacenContext.TiposMovimientos'  is null.");
            }
            var tiposMovimientos = await _context.TiposMovimientos.FindAsync(id);
            if (tiposMovimientos != null)
            {
                _context.TiposMovimientos.Remove(tiposMovimientos);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TiposMovimientosExists(long? id)
        {
            return _context.TiposMovimientos.Any(e => e.IntIdTipoMovimiento == id);
        }
    }
}
