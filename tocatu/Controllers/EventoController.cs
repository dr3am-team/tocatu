using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using tocatu.Context;
using tocatu.Models;

namespace tocatu.Controllers
{
    public class EventoController : Controller
    {
        private readonly TocatuContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public EventoController(TocatuContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }
        // GET: Evento
        public async Task<IActionResult> List()
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
            ObtenerListaDeBares();
            return View();
        }

        // POST: Evento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventId,Nombre,Descripcion,PrecioEntrada,Dia,Hora,BarId,Title,ImageFile")] Evento evento)
        {

            var fecha = evento.Dia.Split("-");
            DateTime _fecha = new DateTime(int.Parse(fecha[0]), int.Parse(fecha[1]), int.Parse(fecha[2]));
            evento.Fecha = _fecha;

            string wwwRootPath = _hostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(evento.ImageFile.FileName);
            string extension = Path.GetExtension(evento.ImageFile.FileName);
            evento.ImageName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            string path = Path.Combine(wwwRootPath + "/images/", fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await evento.ImageFile.CopyToAsync(fileStream);
            }


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
            ObtenerListaDeBandas();
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
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("EventId,Nombre,Descripcion,PrecioEntrada,Dia,Hora,Capacidad,Direccion,BarId")] Evento evento)
        //{
        //  if (id != evento.EventId)
        //  {
        //    return NotFound();
        //  }

        //  if (ModelState.IsValid)
        //  {
        //    try
        //    {
        //      _context.Update(evento);
        //      await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //      if (!EventoExists(evento.EventId))
        //      {
        //        return NotFound();
        //      }
        //      else
        //      {
        //        throw;
        //      }
        //    }
        //    return RedirectToAction(nameof(Index));
        //  }
        //  return View(evento);
        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventId,Nombre,Descripcion,PrecioEntrada,Dia,Hora, BarId, BandaId")] Evento evento)
        {
            if (id != evento.EventId)
            {
                return NotFound();
            }
            //establezco los datos de la banda en el evento
            var Banda = from banda in _context.Usuarios
                        where (banda.UserId == evento.BandaId)
                        select banda;
            var banda1 = (Banda)Banda.FirstOrDefault();
            evento.NombreBanda = banda1.Nombre;
            evento.EstiloBanda = banda1.Estilo;
            //establezco los datos del bar en el evento para que no se pierdan al editar
            var Bar = from bar in _context.Usuarios
                      where (bar.UserId == evento.BarId)
                      select bar;

            var Bar1 = (Bar)Bar.FirstOrDefault();
            evento.Capacidad = Bar1.Capacidad;
            evento.Direccion = Bar1.Direccion;



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

            //borrar de wwwroot/images
            var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "images", evento.ImageName);
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);

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
        public void ObtenerListaDeBares()
        {
            //establecemos los bares en el viewbag para que aparezcan en el desplegable
            var Usuarios = _context.Usuarios.ToList();

            var Bares = from usuario in Usuarios
                        where usuario is Bar
                        select usuario;


            ViewBag.Bar = new SelectList(Bares, "UserId", "Nombre");

        }
        public void ObtenerListaDeBandas()
        {
            //establecemos los bandas en el viewbag para que aparezcan en el desplegable
            var Usuarios = _context.Usuarios.ToList();

            var Bandas = from usuario in Usuarios
                         where usuario is Banda
                         select usuario;


            ViewBag.Banda = new SelectList(Bandas, "UserId", "Nombre");

        }
        public void ActualizarDatos(int capacidad, string direccion, int id)
        {
            //buscar al evento del id
            var Evento = from evento in _context.Eventos
                         where (evento.BarId == id)
                         select evento;
            //este if revisa si hay algun evento asociado al id de bar que llega por parametro
            if (Evento.FirstOrDefault() != null)
            {
                foreach (Evento e in Evento)
                {
                    e.Capacidad = capacidad;
                    e.Direccion = direccion;

                }



                var Evento1 = Evento.FirstOrDefault();
                Evento1.Capacidad = capacidad;
                Evento1.Direccion = direccion;
            }
        }
        public void ActualizarDatos(string estilo, string nombre, int id)
        {
            //buscar al evento del id
            var Evento = from evento in _context.Eventos
                         where (evento.BandaId == id)
                         select evento;

            foreach (Evento e in Evento)
            {
                e.EstiloBanda = estilo;
                e.NombreBanda = nombre;

            }
            //var Evento1 = Evento.FirstOrDefault();
            //Evento1.EstiloBanda = estilo;
            //Evento1.NombreBanda = nombre;
        }
        public void BorrarEventosAsociados(int id)
        {
            var Evento = from evento in _context.Eventos
                         where (evento.BarId == id)
                         select evento;

            foreach (Evento e in Evento)
            {
                DeleteConfirmed(e.EventId);
                // e.BarId = null;

            }
        }
        public void BorrarIdBanda(int id)
        {
            var Evento = from evento in _context.Eventos
                         where (evento.BandaId == id)
                         select evento;

            foreach (Evento e in Evento)
            {
                e.BandaId = null;

            }
        }

        public void EstablecerDatosDeBandaVacios(int id)
        {
            var Evento = from evento in _context.Eventos
                         where (evento.BandaId == id)
                         select evento;

            foreach (Evento e in Evento)
            {
                e.NombreBanda = "";
                e.EstiloBanda = "";

            }
        }
    }
}