/*
 * @fileoverview    {PlanCompraController}
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
    public class PlanCompraController : Controller
    {
        private readonly AlmacenContext _context;

        public PlanCompraController(AlmacenContext context)
        {
            _context = context;
        }

        // GET: PlanCompra
        public async Task<IActionResult> Index()
        {
            return View(await _context.PlanCompra.ToListAsync());
        }

        // GET: PlanCompra/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.PlanCompra == null)
            {
                return NotFound();
            }

            var planCompra = await _context.PlanCompra
                .FirstOrDefaultAsync(m => m.IntIdPlanCompra == id);
            if (planCompra == null)
            {
                return NotFound();
            }

            return View(planCompra);
        }

        // GET: PlanCompra/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PlanCompra/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntIdPlanCompra,IntCodigoMaterial,StrDescripcion,DblCantidad,IntIdGrupoProveedor,DtFechaExplosion,DtFechaCreacion,DtFechaModificacion,StrUsuario,StrEstado")] PlanCompra planCompra)
        {
            if (ModelState.IsValid)
            {
                _context.Add(planCompra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(planCompra);
        }

        // GET: PlanCompra/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.PlanCompra == null)
            {
                return NotFound();
            }

            var planCompra = await _context.PlanCompra.FindAsync(id);
            if (planCompra == null)
            {
                return NotFound();
            }
            return View(planCompra);
        }

        // POST: PlanCompra/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IntIdPlanCompra,IntCodigoMaterial,StrDescripcion,DblCantidad,IntIdGrupoProveedor,DtFechaExplosion,DtFechaCreacion,DtFechaModificacion,StrUsuario,StrEstado")] PlanCompra planCompra)
        {
            if (id != planCompra.IntIdPlanCompra)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(planCompra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlanCompraExists(planCompra.IntIdPlanCompra))
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
            return View(planCompra);
        }

        // GET: PlanCompra/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.PlanCompra == null)
            {
                return NotFound();
            }

            var planCompra = await _context.PlanCompra
                .FirstOrDefaultAsync(m => m.IntIdPlanCompra == id);
            if (planCompra == null)
            {
                return NotFound();
            }

            return View(planCompra);
        }

        // POST: PlanCompra/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            if (_context.PlanCompra == null)
            {
                return Problem("Entity set 'AlmacenContext.PlanCompra'  is null.");
            }
            var planCompra = await _context.PlanCompra.FindAsync(id);
            if (planCompra != null)
            {
                _context.PlanCompra.Remove(planCompra);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlanCompraExists(long? id)
        {
            return _context.PlanCompra.Any(e => e.IntIdPlanCompra == id);
        }
    }
}
