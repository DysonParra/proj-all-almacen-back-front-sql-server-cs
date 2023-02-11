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
    public class MaterialesController : Controller
    {
        private readonly AlmacenContext _context;

        public MaterialesController(AlmacenContext context)
        {
            _context = context;
        }

        // GET: Materiales
        public async Task<IActionResult> Index()
        {
            return View(await _context.Materiales.ToListAsync());
        }

        // GET: Materiales/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Materiales == null)
            {
                return NotFound();
            }

            var materiales = await _context.Materiales
                .FirstOrDefaultAsync(m => m.IntIdMaterial == id);
            if (materiales == null)
            {
                return NotFound();
            }

            return View(materiales);
        }

        // GET: Materiales/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Materiales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntIdMaterial,StrCodigoMaterial,StrReferencia,BitGeneraRecibo,BitVentaApartado,BitPermiteDevolucion,StrSimbolo,FltValorUnitario,FltCosto,BitConsumible,BitProducible,BitComprable,BitVendible,BitActivo,StrUsuario,DtFecha,IntIdTiposMateriales")] Materiales materiales)
        {
            if (ModelState.IsValid)
            {
                _context.Add(materiales);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(materiales);
        }

        // GET: Materiales/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Materiales == null)
            {
                return NotFound();
            }

            var materiales = await _context.Materiales.FindAsync(id);
            if (materiales == null)
            {
                return NotFound();
            }
            return View(materiales);
        }

        // POST: Materiales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IntIdMaterial,StrCodigoMaterial,StrReferencia,BitGeneraRecibo,BitVentaApartado,BitPermiteDevolucion,StrSimbolo,FltValorUnitario,FltCosto,BitConsumible,BitProducible,BitComprable,BitVendible,BitActivo,StrUsuario,DtFecha,IntIdTiposMateriales")] Materiales materiales)
        {
            if (id != materiales.IntIdMaterial)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(materiales);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaterialesExists(materiales.IntIdMaterial))
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
            return View(materiales);
        }

        // GET: Materiales/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Materiales == null)
            {
                return NotFound();
            }

            var materiales = await _context.Materiales
                .FirstOrDefaultAsync(m => m.IntIdMaterial == id);
            if (materiales == null)
            {
                return NotFound();
            }

            return View(materiales);
        }

        // POST: Materiales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            if (_context.Materiales == null)
            {
                return Problem("Entity set 'AlmacenContext.Materiales'  is null.");
            }
            var materiales = await _context.Materiales.FindAsync(id);
            if (materiales != null)
            {
                _context.Materiales.Remove(materiales);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MaterialesExists(long? id)
        {
            return _context.Materiales.Any(e => e.IntIdMaterial == id);
        }
    }
}
