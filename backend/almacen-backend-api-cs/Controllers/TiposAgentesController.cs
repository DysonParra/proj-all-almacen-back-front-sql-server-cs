/*
 * @fileoverview    {TiposAgentesController}
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
    public class TiposAgentesController : Controller
    {
        private readonly AlmacenContext _context;

        public TiposAgentesController(AlmacenContext context)
        {
            _context = context;
        }

        // GET: TiposAgentes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TiposAgentes.ToListAsync());
        }

        // GET: TiposAgentes/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.TiposAgentes == null)
            {
                return NotFound();
            }

            var tiposAgentes = await _context.TiposAgentes
                .FirstOrDefaultAsync(m => m.IntIdTipoAgente == id);
            if (tiposAgentes == null)
            {
                return NotFound();
            }

            return View(tiposAgentes);
        }

        // GET: TiposAgentes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TiposAgentes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntIdTipoAgente,StrDescripcionTipoAgente,StrTablaInformacion,BitActivo,StrUsuario,DtFecha")] TiposAgentes tiposAgentes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tiposAgentes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tiposAgentes);
        }

        // GET: TiposAgentes/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.TiposAgentes == null)
            {
                return NotFound();
            }

            var tiposAgentes = await _context.TiposAgentes.FindAsync(id);
            if (tiposAgentes == null)
            {
                return NotFound();
            }
            return View(tiposAgentes);
        }

        // POST: TiposAgentes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IntIdTipoAgente,StrDescripcionTipoAgente,StrTablaInformacion,BitActivo,StrUsuario,DtFecha")] TiposAgentes tiposAgentes)
        {
            if (id != tiposAgentes.IntIdTipoAgente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tiposAgentes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TiposAgentesExists(tiposAgentes.IntIdTipoAgente))
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
            return View(tiposAgentes);
        }

        // GET: TiposAgentes/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.TiposAgentes == null)
            {
                return NotFound();
            }

            var tiposAgentes = await _context.TiposAgentes
                .FirstOrDefaultAsync(m => m.IntIdTipoAgente == id);
            if (tiposAgentes == null)
            {
                return NotFound();
            }

            return View(tiposAgentes);
        }

        // POST: TiposAgentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            if (_context.TiposAgentes == null)
            {
                return Problem("Entity set 'AlmacenContext.TiposAgentes'  is null.");
            }
            var tiposAgentes = await _context.TiposAgentes.FindAsync(id);
            if (tiposAgentes != null)
            {
                _context.TiposAgentes.Remove(tiposAgentes);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TiposAgentesExists(long? id)
        {
            return _context.TiposAgentes.Any(e => e.IntIdTipoAgente == id);
        }
    }
}
