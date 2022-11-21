using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
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
        private IWebHostEnvironment _environment;

        public BandaController(TocatuContext context, IWebHostEnvironment enviroment)
        {
            _context = context;
            _environment = enviroment;
        }

        // GET: Banda
        public async Task<IActionResult> Index()
    {
      return View();
    }
    public async Task<IActionResult> List()
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
      EventoController e = new EventoController(_context, _environment);
      e.ActualizarDatos(banda.Estilo, banda.Nombre, id);
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
      //establecemos el valor de BarId del evento en null, ya que sino al borrar el bar se rompe la bd porque el evento esta vinculado al id de bar
      //falta hace que los datos de la banda en el evento vuelvan a estar vacios
      EventoController e = new EventoController(_context, _environment);
      e.BorrarIdBanda(id);
      e.EstablecerDatosDeBandaVacios(id);

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