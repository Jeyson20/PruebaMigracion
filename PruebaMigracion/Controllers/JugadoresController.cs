using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PruebaMigracion.Models;

namespace PruebaMigracion.Controllers
{
    public class JugadoresController : Controller
    {
        private readonly EquiposPelotaContext _context;

        public JugadoresController(EquiposPelotaContext context)
        {
            _context = context;
        }

        // GET: Jugadores
        public async Task<IActionResult> Index()
        {
            var equiposPelotaContext = _context.Jugadores.Include(j => j.EquipoJ).Include(j => j.EstadoJ);
            return View(await equiposPelotaContext.ToListAsync());
        }

        // GET: Jugadores/Create
        public IActionResult Create()
        {
            List<SelectListItem> sexo = new()
            {
                new SelectListItem { Value = "M", Text = "MASCULINO" },
                new SelectListItem { Value = "F", Text = "FEMENINO" },
            };
            ViewBag.Sexo = sexo;
            ViewData["Equipo"] = new SelectList(_context.Equipos, "IdEquipo", "Nombre");
            ViewData["Estado"] = new SelectList(_context.Estados, "IdEstado", "Nombre");
            return View();
        }

        // POST: Jugadores/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdJugador,Nombre,Apellido,FechaNacimiento,Pasaporte,Direccion,Sexo,Equipo,Estado")] Jugador jugador)
        {
            List<SelectListItem> sexo = new()
            {
                new SelectListItem { Value = "M", Text = "MASCULINO" },
                new SelectListItem { Value = "F", Text = "FEMENINO" },
            };
            ViewBag.Sexo = sexo;

            if (_context.Jugadores.Any(x=>x.Pasaporte == jugador.Pasaporte))
            {
                ModelState.AddModelError("Pasaporte", "No puede crear un jugador con el mismo pasaporte de otro");
            }
            if (ModelState.IsValid)
            {
                _context.Add(jugador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Equipo"] = new SelectList(_context.Equipos, "IdEquipo", "Nombre", jugador.Equipo);
            ViewData["Estado"] = new SelectList(_context.Estados, "IdEstado", "Nombre", jugador.Estado);
            return View(jugador);
        }

        // GET: Jugadores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            List<SelectListItem> sexo = new()
            {
                new SelectListItem { Value = "M", Text = "MASCULINO" },
                new SelectListItem { Value = "F", Text = "FEMENINO" },
            };
            ViewBag.Sexo = sexo;
            var jugador = await _context.Jugadores.FindAsync(id);
            if (jugador == null)
            {
                return NotFound();
            }
            ViewData["Equipo"] = new SelectList(_context.Equipos, "IdEquipo", "Nombre", jugador.Equipo);
            ViewData["Estado"] = new SelectList(_context.Estados, "IdEstado", "Nombre", jugador.Estado);
            return View(jugador);
        }

        // POST: Jugadores/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdJugador,Nombre,Apellido,FechaNacimiento,Pasaporte,Direccion,Sexo,Equipo,Estado")] Jugador jugador)
        {
            if (id != jugador.IdJugador)
            {
                return NotFound();
            }

            List<SelectListItem> sexo = new()
            {
                new SelectListItem { Value = "M", Text = "MASCULINO" },
                new SelectListItem { Value = "F", Text = "FEMENINO" },
            };
            ViewBag.Sexo = sexo;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jugador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                   
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Equipo"] = new SelectList(_context.Equipos, "IdEquipo", "Nombre", jugador.Equipo);
            ViewData["Estado"] = new SelectList(_context.Estados, "IdEstado", "Nombre", jugador.Estado);
            return View(jugador);
        }

        // GET: Jugadores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var jugador = await _context.Jugadores
                .Include(j => j.EquipoJ)
                .Include(j => j.EstadoJ)
                .FirstOrDefaultAsync(m => m.IdJugador == id);
            if (jugador == null)
            {
                return NotFound();
            }

            return View(jugador);
        }

        // POST: Jugadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jugador = await _context.Jugadores.FindAsync(id);
            _context.Jugadores.Remove(jugador);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
