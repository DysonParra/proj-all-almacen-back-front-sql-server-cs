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
    public class InterlocutoresCondicionPagoController : Controller
    {
        private readonly AlmacenContext _context;

        public InterlocutoresCondicionPagoController(AlmacenContext context)
        {
            _context = context;
        }

        // GET: InterlocutoresCondicionPago
        public async Task<IActionResult> Index()
        {
            return View(await _context.InterlocutoresCondicionPago.ToListAsync());
        }

        // GET: InterlocutoresCondicionPago/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.InterlocutoresCondicionPago == null)
            {
                return NotFound();
            }

            var interlocutoresCondicionPago = await _context.InterlocutoresCondicionPago
                .FirstOrDefaultAsync(m => m.IntIdInterlocutorCondicionPago == id);
            if (interlocutoresCondicionPago == null)
            {
                return NotFound();
            }

            return View(interlocutoresCondicionPago);
        }

        // GET: InterlocutoresCondicionPago/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InterlocutoresCondicionPago/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntIdInterlocutorCondicionPago,StrNombreCondicion,FltInteresMora,FltDescuentoTotal,DecCupoCredito,StrNumeroCuenta,StrSucursal,StrClaveControl,BitEntregaParcial,StrUsuario,DtFecha,IntIdCondicionPago,IntIdInterlocutor,IntIdListaPrecio")] InterlocutoresCondicionPago interlocutoresCondicionPago)
        {
            if (ModelState.IsValid)
            {
                _context.Add(interlocutoresCondicionPago);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(interlocutoresCondicionPago);
        }

        // GET: InterlocutoresCondicionPago/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.InterlocutoresCondicionPago == null)
            {
                return NotFound();
            }

            var interlocutoresCondicionPago = await _context.InterlocutoresCondicionPago.FindAsync(id);
            if (interlocutoresCondicionPago == null)
            {
                return NotFound();
            }
            return View(interlocutoresCondicionPago);
        }

        // POST: InterlocutoresCondicionPago/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IntIdInterlocutorCondicionPago,StrNombreCondicion,FltInteresMora,FltDescuentoTotal,DecCupoCredito,StrNumeroCuenta,StrSucursal,StrClaveControl,BitEntregaParcial,StrUsuario,DtFecha,IntIdCondicionPago,IntIdInterlocutor,IntIdListaPrecio")] InterlocutoresCondicionPago interlocutoresCondicionPago)
        {
            if (id != interlocutoresCondicionPago.IntIdInterlocutorCondicionPago)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(interlocutoresCondicionPago);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InterlocutoresCondicionPagoExists(interlocutoresCondicionPago.IntIdInterlocutorCondicionPago))
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
            return View(interlocutoresCondicionPago);
        }

        // GET: InterlocutoresCondicionPago/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.InterlocutoresCondicionPago == null)
            {
                return NotFound();
            }

            var interlocutoresCondicionPago = await _context.InterlocutoresCondicionPago
                .FirstOrDefaultAsync(m => m.IntIdInterlocutorCondicionPago == id);
            if (interlocutoresCondicionPago == null)
            {
                return NotFound();
            }

            return View(interlocutoresCondicionPago);
        }

        // POST: InterlocutoresCondicionPago/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            if (_context.InterlocutoresCondicionPago == null)
            {
                return Problem("Entity set 'AlmacenContext.InterlocutoresCondicionPago'  is null.");
            }
            var interlocutoresCondicionPago = await _context.InterlocutoresCondicionPago.FindAsync(id);
            if (interlocutoresCondicionPago != null)
            {
                _context.InterlocutoresCondicionPago.Remove(interlocutoresCondicionPago);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InterlocutoresCondicionPagoExists(long? id)
        {
            return _context.InterlocutoresCondicionPago.Any(e => e.IntIdInterlocutorCondicionPago == id);
        }
    }
}
