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
    public class MaterialesDescripcionesController : Controller
    {
        private readonly AlmacenContext _context;

        public MaterialesDescripcionesController(AlmacenContext context)
        {
            _context = context;
        }

        // GET: MaterialesDescripciones
        public async Task<IActionResult> Index()
        {
            return View(await _context.MaterialesDescripciones.ToListAsync());
        }

        // GET: MaterialesDescripciones/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.MaterialesDescripciones == null)
            {
                return NotFound();
            }

            var materialesDescripciones = await _context.MaterialesDescripciones
                .FirstOrDefaultAsync(m => m.IntIdMaterialDescripcion == id);
            if (materialesDescripciones == null)
            {
                return NotFound();
            }

            return View(materialesDescripciones);
        }

        // GET: MaterialesDescripciones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MaterialesDescripciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntIdMaterialDescripcion,StrCultura,StrDescripcionMaterial,StrUsuario,DtFecha,IntIdMaterial,StrCodigoMaterial")] MaterialesDescripciones materialesDescripciones)
        {
            if (ModelState.IsValid)
            {
                _context.Add(materialesDescripciones);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(materialesDescripciones);
        }

        // GET: MaterialesDescripciones/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.MaterialesDescripciones == null)
            {
                return NotFound();
            }

            var materialesDescripciones = await _context.MaterialesDescripciones.FindAsync(id);
            if (materialesDescripciones == null)
            {
                return NotFound();
            }
            return View(materialesDescripciones);
        }

        // POST: MaterialesDescripciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IntIdMaterialDescripcion,StrCultura,StrDescripcionMaterial,StrUsuario,DtFecha,IntIdMaterial,StrCodigoMaterial")] MaterialesDescripciones materialesDescripciones)
        {
            if (id != materialesDescripciones.IntIdMaterialDescripcion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(materialesDescripciones);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaterialesDescripcionesExists(materialesDescripciones.IntIdMaterialDescripcion))
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
            return View(materialesDescripciones);
        }

        // GET: MaterialesDescripciones/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.MaterialesDescripciones == null)
            {
                return NotFound();
            }

            var materialesDescripciones = await _context.MaterialesDescripciones
                .FirstOrDefaultAsync(m => m.IntIdMaterialDescripcion == id);
            if (materialesDescripciones == null)
            {
                return NotFound();
            }

            return View(materialesDescripciones);
        }

        // POST: MaterialesDescripciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            if (_context.MaterialesDescripciones == null)
            {
                return Problem("Entity set 'AlmacenContext.MaterialesDescripciones'  is null.");
            }
            var materialesDescripciones = await _context.MaterialesDescripciones.FindAsync(id);
            if (materialesDescripciones != null)
            {
                _context.MaterialesDescripciones.Remove(materialesDescripciones);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MaterialesDescripcionesExists(long? id)
        {
            return _context.MaterialesDescripciones.Any(e => e.IntIdMaterialDescripcion == id);
        }
    }
}
