/*
 * @fileoverview    {MmTmcCaracteristicaController}
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
    public class MmTmcCaracteristicaController : Controller
    {
        private readonly AlmacenContext _context;

        public MmTmcCaracteristicaController(AlmacenContext context)
        {
            _context = context;
        }

        // GET: MmTmcCaracteristica
        public async Task<IActionResult> Index()
        {
            return View(await _context.MmTmcCaracteristica.ToListAsync());
        }

        // GET: MmTmcCaracteristica/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.MmTmcCaracteristica == null)
            {
                return NotFound();
            }

            var mmTmcCaracteristica = await _context.MmTmcCaracteristica
                .FirstOrDefaultAsync(m => m.IntIdMmTmcCaracteristica == id);
            if (mmTmcCaracteristica == null)
            {
                return NotFound();
            }

            return View(mmTmcCaracteristica);
        }

        // GET: MmTmcCaracteristica/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MmTmcCaracteristica/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntIdMmTmcCaracteristica,IntIdTipoMaterialCaracteristica,StrTipoMaterial,StrDescripcionTipoMaterialCaracteristica,IntTipoDato,StrReglaValidacion,BitVisibleDetalle,IntOrdenDetall,StrUsuario,DtFecha,IntIdTipoMaterial")] MmTmcCaracteristica mmTmcCaracteristica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mmTmcCaracteristica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mmTmcCaracteristica);
        }

        // GET: MmTmcCaracteristica/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.MmTmcCaracteristica == null)
            {
                return NotFound();
            }

            var mmTmcCaracteristica = await _context.MmTmcCaracteristica.FindAsync(id);
            if (mmTmcCaracteristica == null)
            {
                return NotFound();
            }
            return View(mmTmcCaracteristica);
        }

        // POST: MmTmcCaracteristica/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IntIdMmTmcCaracteristica,IntIdTipoMaterialCaracteristica,StrTipoMaterial,StrDescripcionTipoMaterialCaracteristica,IntTipoDato,StrReglaValidacion,BitVisibleDetalle,IntOrdenDetall,StrUsuario,DtFecha,IntIdTipoMaterial")] MmTmcCaracteristica mmTmcCaracteristica)
        {
            if (id != mmTmcCaracteristica.IntIdMmTmcCaracteristica)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mmTmcCaracteristica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MmTmcCaracteristicaExists(mmTmcCaracteristica.IntIdMmTmcCaracteristica))
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
            return View(mmTmcCaracteristica);
        }

        // GET: MmTmcCaracteristica/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.MmTmcCaracteristica == null)
            {
                return NotFound();
            }

            var mmTmcCaracteristica = await _context.MmTmcCaracteristica
                .FirstOrDefaultAsync(m => m.IntIdMmTmcCaracteristica == id);
            if (mmTmcCaracteristica == null)
            {
                return NotFound();
            }

            return View(mmTmcCaracteristica);
        }

        // POST: MmTmcCaracteristica/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            if (_context.MmTmcCaracteristica == null)
            {
                return Problem("Entity set 'AlmacenContext.MmTmcCaracteristica'  is null.");
            }
            var mmTmcCaracteristica = await _context.MmTmcCaracteristica.FindAsync(id);
            if (mmTmcCaracteristica != null)
            {
                _context.MmTmcCaracteristica.Remove(mmTmcCaracteristica);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MmTmcCaracteristicaExists(long? id)
        {
            return _context.MmTmcCaracteristica.Any(e => e.IntIdMmTmcCaracteristica == id);
        }
    }
}
