/*
 * @fileoverview    {TipoListaMaterialController}
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
    public class TipoListaMaterialController : Controller
    {
        private readonly AlmacenContext _context;

        public TipoListaMaterialController(AlmacenContext context)
        {
            _context = context;
        }

        // GET: TipoListaMaterial
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoListaMaterial.ToListAsync());
        }

        // GET: TipoListaMaterial/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.TipoListaMaterial == null)
            {
                return NotFound();
            }

            var tipoListaMaterial = await _context.TipoListaMaterial
                .FirstOrDefaultAsync(m => m.IntIdTipoListaMaterial == id);
            if (tipoListaMaterial == null)
            {
                return NotFound();
            }

            return View(tipoListaMaterial);
        }

        // GET: TipoListaMaterial/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoListaMaterial/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntIdTipoListaMaterial,StrNombreTipoLista,StrDescripcionLista")] TipoListaMaterial tipoListaMaterial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoListaMaterial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoListaMaterial);
        }

        // GET: TipoListaMaterial/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.TipoListaMaterial == null)
            {
                return NotFound();
            }

            var tipoListaMaterial = await _context.TipoListaMaterial.FindAsync(id);
            if (tipoListaMaterial == null)
            {
                return NotFound();
            }
            return View(tipoListaMaterial);
        }

        // POST: TipoListaMaterial/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IntIdTipoListaMaterial,StrNombreTipoLista,StrDescripcionLista")] TipoListaMaterial tipoListaMaterial)
        {
            if (id != tipoListaMaterial.IntIdTipoListaMaterial)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoListaMaterial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoListaMaterialExists(tipoListaMaterial.IntIdTipoListaMaterial))
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
            return View(tipoListaMaterial);
        }

        // GET: TipoListaMaterial/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.TipoListaMaterial == null)
            {
                return NotFound();
            }

            var tipoListaMaterial = await _context.TipoListaMaterial
                .FirstOrDefaultAsync(m => m.IntIdTipoListaMaterial == id);
            if (tipoListaMaterial == null)
            {
                return NotFound();
            }

            return View(tipoListaMaterial);
        }

        // POST: TipoListaMaterial/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            if (_context.TipoListaMaterial == null)
            {
                return Problem("Entity set 'AlmacenContext.TipoListaMaterial'  is null.");
            }
            var tipoListaMaterial = await _context.TipoListaMaterial.FindAsync(id);
            if (tipoListaMaterial != null)
            {
                _context.TipoListaMaterial.Remove(tipoListaMaterial);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoListaMaterialExists(long? id)
        {
            return _context.TipoListaMaterial.Any(e => e.IntIdTipoListaMaterial == id);
        }
    }
}
