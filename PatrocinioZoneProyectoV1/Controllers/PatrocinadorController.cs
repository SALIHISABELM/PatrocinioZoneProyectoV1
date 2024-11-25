using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PatrocinioZoneProyectoV1.Context;
using PatrocinioZoneProyectoV1.Models;

namespace PatrocinioZoneProyectoV1.Controllers
{
    public class PatrocinadorController : Controller
    {
        private readonly PatrocinioZoneDataBaseContext _context;

        public PatrocinadorController(PatrocinioZoneDataBaseContext context)
        {
            _context = context;
        }

        // GET: Patrocinador
        public async Task<IActionResult> Index()
        {
            //Esto es para que tome la lista
            return _context.Patrocinadores != null ?
                         View(await _context.Patrocinadores.ToListAsync()) :
                         Problem("Entity set 'PatrocinioZoneDataBaseContext.Patrocinadores'  is null.");

            //Esto es lo que me creó EF
            //return View(await _context.Patrocinadores.ToListAsync());
        }

        // GET: Patrocinador/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            //Esto lo agregamos || _context.Patrocinadores == null
            if (id == null || _context.Patrocinadores == null)
            {
                return NotFound();
            }

            var patrocinador = await _context.Patrocinadores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (patrocinador == null)
            {
                return NotFound();
            }

            return View(patrocinador);
        }

        // GET: Patrocinador/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Patrocinador/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Email,FechaIngreso,Presupuesto")] Patrocinador patrocinador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patrocinador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(patrocinador);
        }

        // GET: Patrocinador/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            //Esto lo agregamos || _context.Patrocinadores == null
            if (id == null || _context.Patrocinadores == null)
            {
                return NotFound();
            }

            var patrocinador = await _context.Patrocinadores.FindAsync(id);
            if (patrocinador == null)
            {
                return NotFound();
            }
            return View(patrocinador);
        }

        // POST: Patrocinador/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Email,FechaIngreso,Presupuesto")] Patrocinador patrocinador)
        {
            if (id != patrocinador.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patrocinador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatrocinadorExists(patrocinador.Id))
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
            return View(patrocinador);
        }

        // GET: Patrocinador/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            //Esto lo agregamos || _context.Patrocinadores == null
            if (id == null || _context.Patrocinadores == null)
            {
               return NotFound();
            }

            var patrocinador = await _context.Patrocinadores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (patrocinador == null)
            {
                return NotFound();
            }

            return View(patrocinador);
        }

        // POST: Patrocinador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var patrocinador = await _context.Patrocinadores.FindAsync(id);
            if (patrocinador != null)
            {
                _context.Patrocinadores.Remove(patrocinador);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatrocinadorExists(int id)
        {
            //Agregado
            return (_context.Patrocinadores?.Any(e => e.Id == id)).GetValueOrDefault();

            //Esto estaba con EF
            //return _context.Patrocinadores.Any(e => e.Id == id);
        }
    }
}
