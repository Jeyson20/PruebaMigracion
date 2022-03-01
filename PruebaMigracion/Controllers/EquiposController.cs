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
    public class EquiposController : Controller
    {
        private readonly EquiposPelotaContext _context;

        public EquiposController(EquiposPelotaContext context)
        {
            _context = context;
        }

        // GET: Equipos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Equipos.ToListAsync());
        }

        public async Task<IActionResult> AllPlayers(int id)
        {

            var jugadores = await _context.Jugadores.Where(x => x.Equipo == id).Include(j => j.EquipoJ).Include(j => j.EstadoJ).ToListAsync();
            return View(jugadores);
        }

        // GET: Equipos/Create
        public IActionResult Create()
        {
            List<SelectListItem> paises = new()
            {
                new SelectListItem { Value = "CAN", Text = "CAN" },
                new SelectListItem { Value = "USA", Text = "USA" },
                new SelectListItem { Value = "DOM", Text = "DOM" },
                new SelectListItem { Value = "MEX", Text = "MEX" },
                new SelectListItem { Value = "PAN", Text = "PAN" },
                new SelectListItem { Value = "ESP", Text = "ESP" },
                new SelectListItem { Value = "VEN", Text = "VEN" },
                new SelectListItem { Value = "ECU", Text = "ECU" },
            };
            ViewBag.Pais = paises;
            return View();
        }

        // POST: Equipos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEquipo,Nombre,Pais,Estado,FechaCreacion")] Equipo equipo)
        {
            try
            {
                List<SelectListItem> paises = new()
                {
                    new SelectListItem { Value = "CAN", Text = "CAN" },
                    new SelectListItem { Value = "USA", Text = "USA" },
                    new SelectListItem { Value = "DOM", Text = "DOM" },
                    new SelectListItem { Value = "MEX", Text = "MEX" },
                    new SelectListItem { Value = "PAN", Text = "PAN" },
                    new SelectListItem { Value = "ESP", Text = "ESP" },
                    new SelectListItem { Value = "VEN", Text = "VEN" },
                    new SelectListItem { Value = "ECU", Text = "ECU" },
                };
                ViewBag.Pais = paises;
                if (equipo == null)
                {
                    ModelState.AddModelError("", "El equipo no puede ser nulo!");
                }

                if (ModelState.IsValid)
                {
                    _context.Add(equipo);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", "El equipo no puede ser nulo!" + ex);
            }
           
            return View(equipo);
        }

        // GET: Equipos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            List<SelectListItem> paises = new()
            {
                new SelectListItem { Value = "CAN", Text = "CAN" },
                new SelectListItem { Value = "USA", Text = "USA" },
                new SelectListItem { Value = "DOM", Text = "DOM" },
                new SelectListItem { Value = "MEX", Text = "MEX" },
                new SelectListItem { Value = "PAN", Text = "PAN" },
                new SelectListItem { Value = "ESP", Text = "ESP" },
                new SelectListItem { Value = "VEN", Text = "VEN" },
                new SelectListItem { Value = "ECU", Text = "ECU" },
            };
            ViewBag.Pais = paises;

            var equipo = await _context.Equipos.FindAsync(id);
            if (equipo == null)
            {
                return NotFound();
            }
            return View(equipo);
        }

        // POST: Equipos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEquipo,Nombre,Pais,Estado,FechaCreacion")] Equipo equipo)
        {

            List<SelectListItem> paises = new()
            {
                new SelectListItem { Value = "CAN", Text = "CAN" },
                new SelectListItem { Value = "USA", Text = "USA" },
                new SelectListItem { Value = "DOM", Text = "DOM" },
                new SelectListItem { Value = "MEX", Text = "MEX" },
                new SelectListItem { Value = "PAN", Text = "PAN" },
                new SelectListItem { Value = "ESP", Text = "ESP" },
                new SelectListItem { Value = "VEN", Text = "VEN" },
                new SelectListItem { Value = "ECU", Text = "ECU" },
            };
            ViewBag.Pais = paises;
            if (id != equipo.IdEquipo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equipo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                  
                }
                return RedirectToAction(nameof(Index));
            }
            return View(equipo);
        }

        // GET: Equipos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipo = await _context.Equipos
                .FirstOrDefaultAsync(m => m.IdEquipo == id);
            if (equipo == null)
            {
                return NotFound();
            }

            return View(equipo);
        }

        // POST: Equipos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var equipo = await _context.Equipos.FindAsync(id);
            try
            {
                if (_context.Jugadores.Any(x => x.Equipo == equipo.IdEquipo))
                {
                    ModelState.AddModelError("IdEquipo", "No puede eliminar este Equipo (Existen jugadores de" +
                        "                    este equipo)!");
                    return View(equipo);
                }
                _context.Equipos.Remove(equipo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("IdEquipo", ex.Message);
            }
           return View(equipo);
            
            
        }
    }
}
