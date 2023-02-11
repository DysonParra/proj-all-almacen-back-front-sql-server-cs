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
    public class InterlocutorFinanzasController : Controller
    {
        private readonly AlmacenContext _context;

        public InterlocutorFinanzasController(AlmacenContext context)
        {
            _context = context;
        }

        // GET: InterlocutorFinanzas
        public async Task<IActionResult> Index()
        {
            return View(await _context.InterlocutorFinanzas.ToListAsync());
        }

        // GET: InterlocutorFinanzas/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.InterlocutorFinanzas == null)
            {
                return NotFound();
            }

            var interlocutorFinanzas = await _context.InterlocutorFinanzas
                .FirstOrDefaultAsync(m => m.IntIdInterlocutorFinanzas == id);
            if (interlocutorFinanzas == null)
            {
                return NotFound();
            }

            return View(interlocutorFinanzas);
        }

        // GET: InterlocutorFinanzas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InterlocutorFinanzas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntIdInterlocutorFinanzas,BitImpuesto,BitSujetoRetencion,StrNumeroCertificadoRetencion,DtFechaVencimiento,StrNumeroAfiliacionSeguridad,StrUsuario,DtFecha,IntIdInterlocutor")] InterlocutorFinanzas interlocutorFinanzas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(interlocutorFinanzas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(interlocutorFinanzas);
        }

        // GET: InterlocutorFinanzas/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.InterlocutorFinanzas == null)
            {
                return NotFound();
            }

            var interlocutorFinanzas = await _context.InterlocutorFinanzas.FindAsync(id);
            if (interlocutorFinanzas == null)
            {
                return NotFound();
            }
            return View(interlocutorFinanzas);
        }

        // POST: InterlocutorFinanzas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IntIdInterlocutorFinanzas,BitImpuesto,BitSujetoRetencion,StrNumeroCertificadoRetencion,DtFechaVencimiento,StrNumeroAfiliacionSeguridad,StrUsuario,DtFecha,IntIdInterlocutor")] InterlocutorFinanzas interlocutorFinanzas)
        {
            if (id != interlocutorFinanzas.IntIdInterlocutorFinanzas)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(interlocutorFinanzas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InterlocutorFinanzasExists(interlocutorFinanzas.IntIdInterlocutorFinanzas))
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
            return View(interlocutorFinanzas);
        }

        // GET: InterlocutorFinanzas/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.InterlocutorFinanzas == null)
            {
                return NotFound();
            }

            var interlocutorFinanzas = await _context.InterlocutorFinanzas
                .FirstOrDefaultAsync(m => m.IntIdInterlocutorFinanzas == id);
            if (interlocutorFinanzas == null)
            {
                return NotFound();
            }

            return View(interlocutorFinanzas);
        }

        // POST: InterlocutorFinanzas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            if (_context.InterlocutorFinanzas == null)
            {
                return Problem("Entity set 'AlmacenContext.InterlocutorFinanzas'  is null.");
            }
            var interlocutorFinanzas = await _context.InterlocutorFinanzas.FindAsync(id);
            if (interlocutorFinanzas != null)
            {
                _context.InterlocutorFinanzas.Remove(interlocutorFinanzas);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InterlocutorFinanzasExists(long? id)
        {
            return _context.InterlocutorFinanzas.Any(e => e.IntIdInterlocutorFinanzas == id);
        }
    }
}
