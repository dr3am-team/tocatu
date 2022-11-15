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
  public class EventoController : Controller
  {
    private readonly TocatuContext _context;

    public EventoController(TocatuContext context)
    {
      _context = context;
    }

    // GET: Evento
    public async Task<IActionResult> Index()
    {
      return View(await _context.Eventos.ToListAsync());
    }



    // GET: Evento/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var evento = await _context.Eventos
          .FirstOrDefaultAsync(m => m.EventId == id);
      if (evento == null)
      {
        return NotFound();
      }

      return View(evento);
    }

    // GET: Evento/Create
    public IActionResult Create()
    {
      ObtenerListaDeBandas();
      return View();
    }

    // POST: Evento/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("EventId,Nombre,Descripcion,PrecioEntrada,Dia,Hora, BarId")] Evento evento)
    {

      var fecha = evento.Dia.Split("-");
      DateTime _fecha = new DateTime(int.Parse(fecha[0]), int.Parse(fecha[1]), int.Parse(fecha[2]));
      evento.Fecha = _fecha;
      



      var Bar = from bar in _context.Usuarios
                where (bar.UserId == evento.BarId)
                select bar;
      var bar1 = (Bar)Bar.FirstOrDefault();
      evento.Capacidad = bar1.Capacidad;
      evento.Direccion = bar1.Direccion;



      if (ModelState.IsValid)
      {
        _context.Add(evento);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      return View(evento);
    }

    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public async Task<IActionResult> Create([Bind("EventId,Nombre,Descripcion,PrecioEntrada,Dia,Hora,Capacidad,Direccion,BarId")] Evento evento)
    //{


    //    if (ModelState.IsValid)
    //    {
    //        _context.Add(evento);
    //        await _context.SaveChangesAsync();
    //        return RedirectToAction(nameof(Index));
    //    }
    //    return View(evento);
    //}


    // GET: Evento/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var evento = await _context.Eventos.FindAsync(id);
      if (evento == null)
      {
        return NotFound();
      }
      return View(evento);
    }

    // POST: Evento/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("EventId,Nombre,Descripcion,PrecioEntrada,Dia,Hora,Capacidad,Direccion,BarId")] Evento evento)
    {
      if (id != evento.EventId)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(evento);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!EventoExists(evento.EventId))
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
      return View(evento);
    }

    // GET: Evento/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var evento = await _context.Eventos
          .FirstOrDefaultAsync(m => m.EventId == id);
      if (evento == null)
      {
        return NotFound();
      }

      return View(evento);
    }

    // POST: Evento/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var evento = await _context.Eventos.FindAsync(id);
      _context.Eventos.Remove(evento);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool EventoExists(int id)
    {
      return _context.Eventos.Any(e => e.EventId == id);
    }

    /* private void PopulateBaresDropDownList(int? selectedBar = null)
     {
         var bares = _context.PopulateBaresDropDownList();
         ViewBag.UserId = new SelectList(bares.AsNoTracking(), "UserId", "UserNombre", selectedBar);
     }*/
    public void ObtenerListaDeBandas()
    {
      var Usuarios = _context.Usuarios.ToList();

      var Bares = from usuario in Usuarios
                  where usuario is Bar
                  select usuario;


      ViewBag.Bar = new SelectList(Bares, "UserId", "Nombre");

    }
  }
}
