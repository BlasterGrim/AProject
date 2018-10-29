using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EFGetStarted.AspNetCore.NewDb.Models;

namespace EFGetStarted.AspNetCore.NewDb.Controllers
{
    public class SpedizioniController : Controller
    {
        private readonly BloggingContext _context;

        public SpedizioniController(BloggingContext context)
        {
            _context = context;
        }

        // GET: Spedizioni
        public async Task<IActionResult> Index()
        {
            return View(await _context.Spedizione.ToListAsync());
        }

        // GET: Spedizioni/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spedizione = await _context.Spedizione
                .FirstOrDefaultAsync(m => m.SpedizioneId == id);
            if (spedizione == null)
            {
                return NotFound();
            }

            return View(spedizione);
        }

        // GET: Spedizioni/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Spedizioni/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SpedizioneId,nome,descrizione,costiSpedizione")] Spedizione spedizione)
        {
            if (ModelState.IsValid)
            {
                _context.Add(spedizione);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(spedizione);
        }

        // GET: Spedizioni/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spedizione = await _context.Spedizione.FindAsync(id);
            if (spedizione == null)
            {
                return NotFound();
            }
            return View(spedizione);
        }

        // POST: Spedizioni/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SpedizioneId,nome,descrizione,costiSpedizione")] Spedizione spedizione)
        {
            if (id != spedizione.SpedizioneId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(spedizione);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpedizioneExists(spedizione.SpedizioneId))
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
            return View(spedizione);
        }

        // GET: Spedizioni/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spedizione = await _context.Spedizione
                .FirstOrDefaultAsync(m => m.SpedizioneId == id);
            if (spedizione == null)
            {
                return NotFound();
            }

            return View(spedizione);
        }

        // POST: Spedizioni/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var spedizione = await _context.Spedizione.FindAsync(id);
            _context.Spedizione.Remove(spedizione);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpedizioneExists(int id)
        {
            return _context.Spedizione.Any(e => e.SpedizioneId == id);
        }
    }
}
