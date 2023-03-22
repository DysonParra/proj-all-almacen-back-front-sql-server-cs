/*
 * @fileoverview    {TiposDocumentosController}
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
    public class TiposDocumentosController : Controller
    {
        private readonly AlmacenContext _context;

        public TiposDocumentosController(AlmacenContext context)
        {
            _context = context;
        }

        // GET: TiposDocumentos
        public async Task<IActionResult> Index()
        {
            return View(await _context.TiposDocumentos.ToListAsync());
        }

        // GET: TiposDocumentos/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.TiposDocumentos == null)
            {
                return NotFound();
            }

            var tiposDocumentos = await _context.TiposDocumentos
                .FirstOrDefaultAsync(m => m.IntIdTipoDocumento == id);
            if (tiposDocumentos == null)
            {
                return NotFound();
            }

            return View(tiposDocumentos);
        }

        // GET: TiposDocumentos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TiposDocumentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntIdTipoDocumento,StrDescripcionTipoDocumento,BitActivo,StrUsuario,DtFecha,IntIdEstadoRemision,IntIdTipoMovimiento")] TiposDocumentos tiposDocumentos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tiposDocumentos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tiposDocumentos);
        }

        // GET: TiposDocumentos/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.TiposDocumentos == null)
            {
                return NotFound();
            }

            var tiposDocumentos = await _context.TiposDocumentos.FindAsync(id);
            if (tiposDocumentos == null)
            {
                return NotFound();
            }
            return View(tiposDocumentos);
        }

        // POST: TiposDocumentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IntIdTipoDocumento,StrDescripcionTipoDocumento,BitActivo,StrUsuario,DtFecha,IntIdEstadoRemision,IntIdTipoMovimiento")] TiposDocumentos tiposDocumentos)
        {
            if (id != tiposDocumentos.IntIdTipoDocumento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tiposDocumentos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TiposDocumentosExists(tiposDocumentos.IntIdTipoDocumento))
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
            return View(tiposDocumentos);
        }

        // GET: TiposDocumentos/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.TiposDocumentos == null)
            {
                return NotFound();
            }

            var tiposDocumentos = await _context.TiposDocumentos
                .FirstOrDefaultAsync(m => m.IntIdTipoDocumento == id);
            if (tiposDocumentos == null)
            {
                return NotFound();
            }

            return View(tiposDocumentos);
        }

        // POST: TiposDocumentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            if (_context.TiposDocumentos == null)
            {
                return Problem("Entity set 'AlmacenContext.TiposDocumentos'  is null.");
            }
            var tiposDocumentos = await _context.TiposDocumentos.FindAsync(id);
            if (tiposDocumentos != null)
            {
                _context.TiposDocumentos.Remove(tiposDocumentos);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TiposDocumentosExists(long? id)
        {
            return _context.TiposDocumentos.Any(e => e.IntIdTipoDocumento == id);
        }
    }
}
