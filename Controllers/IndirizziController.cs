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
    public class IndirizziController : Controller
    {
        private readonly BloggingContext _context;

        public IndirizziController(BloggingContext context)
        {
            _context = context;
        }

        // GET: Indirizzi
        public async Task<IActionResult> Index()
        {
            return View(await _context.Indirizzo.ToListAsync());
        }

        // GET: Indirizzi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var indirizzo = await _context.Indirizzo
                .FirstOrDefaultAsync(m => m.IndirizzoId == id);
            if (indirizzo == null)
            {
                return NotFound();
            }

            return View(indirizzo);
        }

        // GET: Indirizzi/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Indirizzi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IndirizzoId,indirizzoSpedizione,indirizzoFatturazione")] Indirizzo indirizzo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(indirizzo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(indirizzo);
        }

        // GET: Indirizzi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var indirizzo = await _context.Indirizzo.FindAsync(id);
            if (indirizzo == null)
            {
                return NotFound();
            }
            return View(indirizzo);
        }

        // POST: Indirizzi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IndirizzoId,indirizzoSpedizione,indirizzoFatturazione")] Indirizzo indirizzo)
        {
            if (id != indirizzo.IndirizzoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(indirizzo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IndirizzoExists(indirizzo.IndirizzoId))
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
            return View(indirizzo);
        }

        // GET: Indirizzi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var indirizzo = await _context.Indirizzo
                .FirstOrDefaultAsync(m => m.IndirizzoId == id);
            if (indirizzo == null)
            {
                return NotFound();
            }

            return View(indirizzo);
        }

        // POST: Indirizzi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var indirizzo = await _context.Indirizzo.FindAsync(id);
            _context.Indirizzo.Remove(indirizzo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IndirizzoExists(int id)
        {
            return _context.Indirizzo.Any(e => e.IndirizzoId == id);
        }
    }
}
