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
    public class AgentesController : Controller
    {
        private readonly AlmacenContext _context;

        public AgentesController(AlmacenContext context)
        {
            _context = context;
        }

        // GET: Agentes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Agentes.ToListAsync());
        }

        // GET: Agentes/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Agentes == null)
            {
                return NotFound();
            }

            var agentes = await _context.Agentes
                .FirstOrDefaultAsync(m => m.IntIdAgente == id);
            if (agentes == null)
            {
                return NotFound();
            }

            return View(agentes);
        }

        // GET: Agentes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Agentes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntIdAgente,IntIdEntidad,IntIdAlmacen,StrObservaciones,StrUsuario,DtFecha,IntIdSociedad,IntIdTipoAgente")] Agentes agentes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(agentes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(agentes);
        }

        // GET: Agentes/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Agentes == null)
            {
                return NotFound();
            }

            var agentes = await _context.Agentes.FindAsync(id);
            if (agentes == null)
            {
                return NotFound();
            }
            return View(agentes);
        }

        // POST: Agentes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IntIdAgente,IntIdEntidad,IntIdAlmacen,StrObservaciones,StrUsuario,DtFecha,IntIdSociedad,IntIdTipoAgente")] Agentes agentes)
        {
            if (id != agentes.IntIdAgente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(agentes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgentesExists(agentes.IntIdAgente))
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
            return View(agentes);
        }

        // GET: Agentes/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Agentes == null)
            {
                return NotFound();
            }

            var agentes = await _context.Agentes
                .FirstOrDefaultAsync(m => m.IntIdAgente == id);
            if (agentes == null)
            {
                return NotFound();
            }

            return View(agentes);
        }

        // POST: Agentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            if (_context.Agentes == null)
            {
                return Problem("Entity set 'AlmacenContext.Agentes'  is null.");
            }
            var agentes = await _context.Agentes.FindAsync(id);
            if (agentes != null)
            {
                _context.Agentes.Remove(agentes);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AgentesExists(long? id)
        {
            return _context.Agentes.Any(e => e.IntIdAgente == id);
        }
    }
}
