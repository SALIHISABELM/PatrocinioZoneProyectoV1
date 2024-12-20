﻿using System;
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
    public class ClubController : Controller
    {
        private readonly PatrocinioZoneDataBaseContext _context;

        public ClubController(PatrocinioZoneDataBaseContext context)
        {
            _context = context;
        }

        // GET: Club
        public async Task<IActionResult> Index()
        {
            return _context.Clubes != null ?
                         View(await _context.Clubes.ToListAsync()) :
                         Problem("Entity set 'PatrocinioZoneDataBaseContext.Patrocinadores'  is null.");

            //Esto es lo que me creó EF
            //return View(await _context.Clubes.ToListAsync());
        }

        // GET: Club/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            //Esto lo agregamos || _context.Clubes == null
            if (id == null || _context.Clubes == null)
            {
                return NotFound();
            }

            var club = await _context.Clubes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (club == null)
            {
                return NotFound();
            }

            return View(club);
        }

        // GET: Club/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Club/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Email,FechaIngreso,DeporteFavorito")] Club club)
        {
            if (ModelState.IsValid)
            {
                _context.Add(club);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(club);
        }

        // GET: Club/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            //Esto lo agregamos || _context.Clubes == null
            if (id == null || _context.Clubes == null)
            {
                return NotFound();
            }

            var club = await _context.Clubes.FindAsync(id);
            if (club == null)
            {
                return NotFound();
            }
            return View(club);
        }

        // POST: Club/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Email,FechaIngreso,DeporteFavorito")] Club club)
        {
            if (id != club.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(club);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClubExists(club.Id))
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
            return View(club);
        }

        // GET: Club/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            //Esto lo agregamos || _context.Clubes == null
            if (id == null || _context.Clubes == null)
            {
                return NotFound();
            }

            var club = await _context.Clubes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (club == null)
            {
                return NotFound();
            }

            return View(club);
        }

        // POST: Club/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var club = await _context.Clubes.FindAsync(id);
            if (club != null)
            {
                _context.Clubes.Remove(club);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClubExists(int id)
        {
            //Agregado
            return (_context.Clubes?.Any(e => e.Id == id)).GetValueOrDefault();

            //Esto estaba con EF
            //return _context.Clubes.Any(e => e.Id == id);
        }
    }
}
