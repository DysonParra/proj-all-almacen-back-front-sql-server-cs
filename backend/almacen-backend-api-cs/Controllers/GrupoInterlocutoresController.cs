/*
 * @fileoverview    {GrupoInterlocutoresController}
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
    public class GrupoInterlocutoresController : Controller
    {
        private readonly AlmacenContext _context;

        public GrupoInterlocutoresController(AlmacenContext context)
        {
            _context = context;
        }

        // GET: GrupoInterlocutores
        public async Task<IActionResult> Index()
        {
            return View(await _context.GrupoInterlocutores.ToListAsync());
        }

        // GET: GrupoInterlocutores/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.GrupoInterlocutores == null)
            {
                return NotFound();
            }

            var grupoInterlocutores = await _context.GrupoInterlocutores
                .FirstOrDefaultAsync(m => m.IntIdGrupoInterlocutor == id);
            if (grupoInterlocutores == null)
            {
                return NotFound();
            }

            return View(grupoInterlocutores);
        }

        // GET: GrupoInterlocutores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GrupoInterlocutores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntIdGrupoInterlocutor,StrNombreGrupo,StrDescripcion,StrCuentaContable,StrUsuario,DtFecha,IntIdListaPrecio")] GrupoInterlocutores grupoInterlocutores)
        {
            if (ModelState.IsValid)
            {
                _context.Add(grupoInterlocutores);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(grupoInterlocutores);
        }

        // GET: GrupoInterlocutores/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.GrupoInterlocutores == null)
            {
                return NotFound();
            }

            var grupoInterlocutores = await _context.GrupoInterlocutores.FindAsync(id);
            if (grupoInterlocutores == null)
            {
                return NotFound();
            }
            return View(grupoInterlocutores);
        }

        // POST: GrupoInterlocutores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IntIdGrupoInterlocutor,StrNombreGrupo,StrDescripcion,StrCuentaContable,StrUsuario,DtFecha,IntIdListaPrecio")] GrupoInterlocutores grupoInterlocutores)
        {
            if (id != grupoInterlocutores.IntIdGrupoInterlocutor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(grupoInterlocutores);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GrupoInterlocutoresExists(grupoInterlocutores.IntIdGrupoInterlocutor))
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
            return View(grupoInterlocutores);
        }

        // GET: GrupoInterlocutores/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.GrupoInterlocutores == null)
            {
                return NotFound();
            }

            var grupoInterlocutores = await _context.GrupoInterlocutores
                .FirstOrDefaultAsync(m => m.IntIdGrupoInterlocutor == id);
            if (grupoInterlocutores == null)
            {
                return NotFound();
            }

            return View(grupoInterlocutores);
        }

        // POST: GrupoInterlocutores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            if (_context.GrupoInterlocutores == null)
            {
                return Problem("Entity set 'AlmacenContext.GrupoInterlocutores'  is null.");
            }
            var grupoInterlocutores = await _context.GrupoInterlocutores.FindAsync(id);
            if (grupoInterlocutores != null)
            {
                _context.GrupoInterlocutores.Remove(grupoInterlocutores);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GrupoInterlocutoresExists(long? id)
        {
            return _context.GrupoInterlocutores.Any(e => e.IntIdGrupoInterlocutor == id);
        }
    }
}
