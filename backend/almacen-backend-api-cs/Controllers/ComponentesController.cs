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
    public class ComponentesController : Controller
    {
        private readonly AlmacenContext _context;

        public ComponentesController(AlmacenContext context)
        {
            _context = context;
        }

        // GET: Componentes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Componentes.ToListAsync());
        }

        // GET: Componentes/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Componentes == null)
            {
                return NotFound();
            }

            var componentes = await _context.Componentes
                .FirstOrDefaultAsync(m => m.IntIdComponente == id);
            if (componentes == null)
            {
                return NotFound();
            }

            return View(componentes);
        }

        // GET: Componentes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Componentes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntIdComponente,IntIdAlmacen,DecCantidadBase,DecCantidadRequerida,DecCantidadAdicional,DecCantidadConsumida,DtFechaEstimada,DtFechaEfectiva,DtFechaInicio,DtFechaFinal,IntIdEstadoComponente,StrUsuario,DtFecha,StrCodigoMaterial,StrNumeroOrden,IntIdUnidadMedida")] Componentes componentes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(componentes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(componentes);
        }

        // GET: Componentes/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Componentes == null)
            {
                return NotFound();
            }

            var componentes = await _context.Componentes.FindAsync(id);
            if (componentes == null)
            {
                return NotFound();
            }
            return View(componentes);
        }

        // POST: Componentes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IntIdComponente,IntIdAlmacen,DecCantidadBase,DecCantidadRequerida,DecCantidadAdicional,DecCantidadConsumida,DtFechaEstimada,DtFechaEfectiva,DtFechaInicio,DtFechaFinal,IntIdEstadoComponente,StrUsuario,DtFecha,StrCodigoMaterial,StrNumeroOrden,IntIdUnidadMedida")] Componentes componentes)
        {
            if (id != componentes.IntIdComponente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(componentes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComponentesExists(componentes.IntIdComponente))
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
            return View(componentes);
        }

        // GET: Componentes/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Componentes == null)
            {
                return NotFound();
            }

            var componentes = await _context.Componentes
                .FirstOrDefaultAsync(m => m.IntIdComponente == id);
            if (componentes == null)
            {
                return NotFound();
            }

            return View(componentes);
        }

        // POST: Componentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            if (_context.Componentes == null)
            {
                return Problem("Entity set 'AlmacenContext.Componentes'  is null.");
            }
            var componentes = await _context.Componentes.FindAsync(id);
            if (componentes != null)
            {
                _context.Componentes.Remove(componentes);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComponentesExists(long? id)
        {
            return _context.Componentes.Any(e => e.IntIdComponente == id);
        }
    }
}
