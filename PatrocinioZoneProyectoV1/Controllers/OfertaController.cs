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
    public class OfertaController : Controller
    {
        private readonly PatrocinioZoneDataBaseContext _context;

        public OfertaController(PatrocinioZoneDataBaseContext context)
        {
            _context = context;
        }

        // GET: Oferta
        public async Task<IActionResult> Index()
        {
            //var PatrocinioZoneDataBaseContext = _context.Ofertas.Include(b => b.Patrocinador);
            //return View(await PatrocinioZoneDataBaseContext.ToListAsync());
            return View(await _context.Ofertas.ToListAsync());
        }

        // GET: Oferta/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null /*|| _context.Ofertas == null*/)
            {
                return NotFound();
            }

            var oferta = await _context.Ofertas
                 //.Include(b => b.Patrocinador)
                .FirstOrDefaultAsync(m => m.OfertaId == id);
            if (oferta == null)
            {
                return NotFound();
            }

            return View(oferta);
        }

        // GET: Oferta/Create
        public IActionResult Create()
        {
            //ViewData["PatrocinadorID"] = new SelectList(_context.Patrocinadores, "PatrocindorID", "Name");
            return View();
        }

        // POST: Oferta/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OfertaId,PatrocinadorID,Costo,ClubID,ZonaDePatrocinioID")] Oferta oferta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(oferta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            //ViewData["PatrocinadorID"] = new SelectList(_context.Patrocinadores, "PatrocinadorID", "Name", oferta.PatrocinadorID);
            return View(oferta);
        }

        // GET: Oferta/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oferta = await _context.Ofertas.FindAsync(id);
            if (oferta == null)
            {
                return NotFound();
            }
            return View(oferta);
        }

        // POST: Oferta/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OfertaId,PatrocinadorID,Costo,ClubID,ZonaDePatrocinioID")] Oferta oferta)
        {
            if (id != oferta.OfertaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(oferta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OfertaExists(oferta.OfertaId))
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
            return View(oferta);
        }

        // GET: Oferta/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oferta = await _context.Ofertas
                .FirstOrDefaultAsync(m => m.OfertaId == id);
            if (oferta == null)
            {
                return NotFound();
            }

            return View(oferta);
        }

        // POST: Oferta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var oferta = await _context.Ofertas.FindAsync(id);
            if (oferta != null)
            {
                _context.Ofertas.Remove(oferta);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OfertaExists(int id)
        {
            return _context.Ofertas.Any(e => e.OfertaId == id);
        }
    }
}
