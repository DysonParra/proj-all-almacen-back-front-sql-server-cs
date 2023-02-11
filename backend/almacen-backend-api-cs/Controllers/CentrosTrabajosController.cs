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
    public class CentrosTrabajosController : Controller
    {
        private readonly AlmacenContext _context;

        public CentrosTrabajosController(AlmacenContext context)
        {
            _context = context;
        }

        // GET: CentrosTrabajos
        public async Task<IActionResult> Index()
        {
            return View(await _context.CentrosTrabajos.ToListAsync());
        }

        // GET: CentrosTrabajos/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.CentrosTrabajos == null)
            {
                return NotFound();
            }

            var centrosTrabajos = await _context.CentrosTrabajos
                .FirstOrDefaultAsync(m => m.IntIdCentroDeTrabajo == id);
            if (centrosTrabajos == null)
            {
                return NotFound();
            }

            return View(centrosTrabajos);
        }

        // GET: CentrosTrabajos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CentrosTrabajos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntIdCentroDeTrabajo,IntIdInterlocutorComercial,IntIdCategoriaCentro,DecCosto,IntIdBodega,IntIdMetodoCosteo")] CentrosTrabajos centrosTrabajos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(centrosTrabajos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(centrosTrabajos);
        }

        // GET: CentrosTrabajos/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.CentrosTrabajos == null)
            {
                return NotFound();
            }

            var centrosTrabajos = await _context.CentrosTrabajos.FindAsync(id);
            if (centrosTrabajos == null)
            {
                return NotFound();
            }
            return View(centrosTrabajos);
        }

        // POST: CentrosTrabajos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IntIdCentroDeTrabajo,IntIdInterlocutorComercial,IntIdCategoriaCentro,DecCosto,IntIdBodega,IntIdMetodoCosteo")] CentrosTrabajos centrosTrabajos)
        {
            if (id != centrosTrabajos.IntIdCentroDeTrabajo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(centrosTrabajos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CentrosTrabajosExists(centrosTrabajos.IntIdCentroDeTrabajo))
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
            return View(centrosTrabajos);
        }

        // GET: CentrosTrabajos/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.CentrosTrabajos == null)
            {
                return NotFound();
            }

            var centrosTrabajos = await _context.CentrosTrabajos
                .FirstOrDefaultAsync(m => m.IntIdCentroDeTrabajo == id);
            if (centrosTrabajos == null)
            {
                return NotFound();
            }

            return View(centrosTrabajos);
        }

        // POST: CentrosTrabajos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            if (_context.CentrosTrabajos == null)
            {
                return Problem("Entity set 'AlmacenContext.CentrosTrabajos'  is null.");
            }
            var centrosTrabajos = await _context.CentrosTrabajos.FindAsync(id);
            if (centrosTrabajos != null)
            {
                _context.CentrosTrabajos.Remove(centrosTrabajos);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CentrosTrabajosExists(long? id)
        {
            return _context.CentrosTrabajos.Any(e => e.IntIdCentroDeTrabajo == id);
        }
    }
}
