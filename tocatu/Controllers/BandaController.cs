using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using tocatu.Context;
using tocatu.Models;

namespace tocatu.Controllers
{
    public class BandaController : Controller
    {
        private readonly TocatuContext _context;

        public BandaController(TocatuContext context)
        {
            _context = context;
        }

        // GET: Banda
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bandas.ToListAsync());
        }

        // GET: Banda/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var banda = await _context.Bandas
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (banda == null)
            {
                return NotFound();
            }

            return View(banda);
        }

        // GET: Banda/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Banda/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Estilo,UserId,NombreUsuario,Nombre,Apellido,Mail,Password")] Banda banda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(banda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(banda);
        }

        // GET: Banda/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var banda = await _context.Bandas.FindAsync(id);
            if (banda == null)
            {
                return NotFound();
            }
            return View(banda);
        }

        // POST: Banda/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Estilo,UserId,NombreUsuario,Nombre,Apellido,Mail,Password")] Banda banda)
        {
            if (id != banda.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(banda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BandaExists(banda.UserId))
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
            return View(banda);
        }

        // GET: Banda/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var banda = await _context.Bandas
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (banda == null)
            {
                return NotFound();
            }

            return View(banda);
        }

        // POST: Banda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var banda = await _context.Bandas.FindAsync(id);
            _context.Bandas.Remove(banda);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BandaExists(int id)
        {
            return _context.Bandas.Any(e => e.UserId == id);
        }
    }
}
