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
  public class BarController : Controller
  {
    private readonly TocatuContext _context;

    public BarController(TocatuContext context)
    {
      _context = context;
    }

    // GET: Bar
    public async Task<IActionResult> Index()
    {
      return View();
    }

    public async Task<IActionResult> List()
    {
      return View(await _context.Bar.ToListAsync());
    }

    // GET: Bar/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var bar = await _context.Bar
          .FirstOrDefaultAsync(m => m.UserId == id);
      if (bar == null)
      {
        return NotFound();
      }

      return View(bar);
    }

    // GET: Bar/Create
    public IActionResult Create()
    {
      return View();
    }

    // POST: Bar/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Direccion,Capacidad,UserId,NombreUsuario,Nombre,Apellido,Mail,Password")] Bar bar)
    {
      if (ModelState.IsValid)
      {
        _context.Add(bar);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      return View(bar);
    }

    // GET: Bar/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var bar = await _context.Bar.FindAsync(id);
      if (bar == null)
      {
        return NotFound();
      }
      return View(bar);
    }

    // POST: Bar/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Direccion,Capacidad,UserId,NombreUsuario,Nombre,Apellido,Mail,Password")] Bar bar)
    {
      if (id != bar.UserId)
      {
        return NotFound();
      }

      EventoController e = new EventoController(_context);
      e.ActualizarDatos(bar.Capacidad, bar.Direccion, id);


      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(bar);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!BarExists(bar.UserId))
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
      return View(bar);
    }


    // GET: Bar/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var bar = await _context.Bar
          .FirstOrDefaultAsync(m => m.UserId == id);
      if (bar == null)
      {
        return NotFound();
      }

      return View(bar);
    }

    // POST: Bar/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var bar = await _context.Bar.FindAsync(id);
      //Llamamos a un metodo el cual borra los eventos asociados ya que sin bar no hay evento...
      EventoController e = new EventoController(_context);
      e.BorrarEventosAsociados(id);
      _context.Bar.Remove(bar);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool BarExists(int id)
    {
      return _context.Bar.Any(e => e.UserId == id);
    }
  }
}