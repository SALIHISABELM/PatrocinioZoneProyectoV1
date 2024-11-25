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
    public class ZonaPatrocinioController : Controller
    {
        private readonly PatrocinioZoneDataBaseContext _context;

        public ZonaPatrocinioController(PatrocinioZoneDataBaseContext context)
        {
            _context = context;
        }

        // GET: ZonaPatrocinio
        public async Task<IActionResult> Index()
        {
            //Esto es para que tome la lista
            return _context.ZonaPatrocinios != null ?
                         View(await _context.ZonaPatrocinios.ToListAsync()) :
                         Problem("Entity set 'PatrocinioZoneDataBaseContext.Patrocinadores'  is null.");

            //Esto es lo que me creó EF
            //return View(await _context.ZonaPatrocinios.ToListAsync());
        }

        // GET: ZonaPatrocinio/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            //Esto lo agregamos || _context.ZonaPatrocinios == null
            if (id == null || _context.ZonaPatrocinios == null)
            {
                return NotFound();
            }

            var zonaPatrocinio = await _context.ZonaPatrocinios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zonaPatrocinio == null)
            {
                return NotFound();
            }

            return View(zonaPatrocinio);
        }

        // GET: ZonaPatrocinio/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ZonaPatrocinio/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tamanio,EstadoReservado,Ubicacion")] ZonaPatrocinio zonaPatrocinio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zonaPatrocinio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zonaPatrocinio);
        }

        // GET: ZonaPatrocinio/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            //Esto lo agregamos || _context.ZonaPatrocinios == null
            if (id == null || _context.ZonaPatrocinios == null)
            {
                return NotFound();
            }

            var zonaPatrocinio = await _context.ZonaPatrocinios.FindAsync(id);
            if (zonaPatrocinio == null)
            {
                return NotFound();
            }
            return View(zonaPatrocinio);
        }

        // POST: ZonaPatrocinio/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tamanio,EstadoReservado,Ubicacion")] ZonaPatrocinio zonaPatrocinio)
        {
            if (id != zonaPatrocinio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zonaPatrocinio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZonaPatrocinioExists(zonaPatrocinio.Id))
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
            return View(zonaPatrocinio);
        }

        // GET: ZonaPatrocinio/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            //Esto lo agregamos || _context.ZonaPatrocinios == null
            if (id == null || _context.ZonaPatrocinios == null)
            {
                return NotFound();
            }

            var zonaPatrocinio = await _context.ZonaPatrocinios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zonaPatrocinio == null)
            {
                return NotFound();
            }

            return View(zonaPatrocinio);
        }

        // POST: ZonaPatrocinio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zonaPatrocinio = await _context.ZonaPatrocinios.FindAsync(id);
            if (zonaPatrocinio != null)
            {
                _context.ZonaPatrocinios.Remove(zonaPatrocinio);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZonaPatrocinioExists(int id)
        {
            //Agregado
            return (_context.ZonaPatrocinios?.Any(e => e.Id == id)).GetValueOrDefault();

            //Esto estaba con EF
            //return _context.ZonaPatrocinios.Any(e => e.Id == id);
        }
    }
}
