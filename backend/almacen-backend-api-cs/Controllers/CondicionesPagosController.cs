/*
 * @fileoverview    {CondicionesPagosController}
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
    public class CondicionesPagosController : Controller
    {
        private readonly AlmacenContext _context;

        public CondicionesPagosController(AlmacenContext context)
        {
            _context = context;
        }

        // GET: CondicionesPagos
        public async Task<IActionResult> Index()
        {
            return View(await _context.CondicionesPagos.ToListAsync());
        }

        // GET: CondicionesPagos/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.CondicionesPagos == null)
            {
                return NotFound();
            }

            var condicionesPagos = await _context.CondicionesPagos
                .FirstOrDefaultAsync(m => m.IntIdCondicionPago == id);
            if (condicionesPagos == null)
            {
                return NotFound();
            }

            return View(condicionesPagos);
        }

        // GET: CondicionesPagos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CondicionesPagos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntIdCondicionPago,StrNombreCondicion,StrDescripcion,BitDeudor,BitAcreedor,IntDiiaFijo,IntMesesAdicionales,IntDiasTolerancia,IntNumeroPlazos,FltDescuentoTotal,FltInteresCredito,DecHaberMaximo,StrUsuario,DtFecha")] CondicionesPagos condicionesPagos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(condicionesPagos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(condicionesPagos);
        }

        // GET: CondicionesPagos/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.CondicionesPagos == null)
            {
                return NotFound();
            }

            var condicionesPagos = await _context.CondicionesPagos.FindAsync(id);
            if (condicionesPagos == null)
            {
                return NotFound();
            }
            return View(condicionesPagos);
        }

        // POST: CondicionesPagos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IntIdCondicionPago,StrNombreCondicion,StrDescripcion,BitDeudor,BitAcreedor,IntDiiaFijo,IntMesesAdicionales,IntDiasTolerancia,IntNumeroPlazos,FltDescuentoTotal,FltInteresCredito,DecHaberMaximo,StrUsuario,DtFecha")] CondicionesPagos condicionesPagos)
        {
            if (id != condicionesPagos.IntIdCondicionPago)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(condicionesPagos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CondicionesPagosExists(condicionesPagos.IntIdCondicionPago))
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
            return View(condicionesPagos);
        }

        // GET: CondicionesPagos/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.CondicionesPagos == null)
            {
                return NotFound();
            }

            var condicionesPagos = await _context.CondicionesPagos
                .FirstOrDefaultAsync(m => m.IntIdCondicionPago == id);
            if (condicionesPagos == null)
            {
                return NotFound();
            }

            return View(condicionesPagos);
        }

        // POST: CondicionesPagos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            if (_context.CondicionesPagos == null)
            {
                return Problem("Entity set 'AlmacenContext.CondicionesPagos'  is null.");
            }
            var condicionesPagos = await _context.CondicionesPagos.FindAsync(id);
            if (condicionesPagos != null)
            {
                _context.CondicionesPagos.Remove(condicionesPagos);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CondicionesPagosExists(long? id)
        {
            return _context.CondicionesPagos.Any(e => e.IntIdCondicionPago == id);
        }
    }
}
