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
    public class AcquistiController : Controller
    {
        private readonly BloggingContext _context;

        public AcquistiController(BloggingContext context)
        {
            _context = context;
        }

        // GET: Acquisti
        public async Task<IActionResult> Index()
        {
            var bloggingContext = _context.Acquisti.Include(a => a.Cliente).Include(a => a.Fattura).Include(a => a.Spedizione);
            return View(await bloggingContext.ToListAsync());
        }

        // GET: Acquisti/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acquisti = await _context.Acquisti
                .Include(a => a.Cliente)
                .Include(a => a.Fattura)
                .Include(a => a.Spedizione)
                .FirstOrDefaultAsync(m => m.AcquistiID == id);
            if (acquisti == null)
            {
                return NotFound();
            }

            return View(acquisti);
        }

        // GET: Acquisti/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "cognome");
            ViewData["FatturaId"] = new SelectList(_context.Fattura, "FatturaId", "FatturaId");
            ViewData["SpedizioneId"] = new SelectList(_context.Spedizione, "SpedizioneId", "SpedizioneId");
            return View();
        }

        // POST: Acquisti/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AcquistiID,ClienteId,SpedizioneId,FatturaId")] Acquisti acquisti)
        {
            if (ModelState.IsValid)
            {
                _context.Add(acquisti);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "cognome", acquisti.ClienteId);
            ViewData["FatturaId"] = new SelectList(_context.Fattura, "FatturaId", "FatturaId", acquisti.FatturaId);
            ViewData["SpedizioneId"] = new SelectList(_context.Spedizione, "SpedizioneId", "SpedizioneId", acquisti.SpedizioneId);
            return View(acquisti);
        }

        // GET: Acquisti/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acquisti = await _context.Acquisti.FindAsync(id);
            if (acquisti == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "cognome", acquisti.ClienteId);
            ViewData["FatturaId"] = new SelectList(_context.Fattura, "FatturaId", "FatturaId", acquisti.FatturaId);
            ViewData["SpedizioneId"] = new SelectList(_context.Spedizione, "SpedizioneId", "SpedizioneId", acquisti.SpedizioneId);
            return View(acquisti);
        }

        // POST: Acquisti/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AcquistiID,ClienteId,SpedizioneId,FatturaId")] Acquisti acquisti)
        {
            if (id != acquisti.AcquistiID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(acquisti);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AcquistiExists(acquisti.AcquistiID))
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
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "cognome", acquisti.ClienteId);
            ViewData["FatturaId"] = new SelectList(_context.Fattura, "FatturaId", "FatturaId", acquisti.FatturaId);
            ViewData["SpedizioneId"] = new SelectList(_context.Spedizione, "SpedizioneId", "SpedizioneId", acquisti.SpedizioneId);
            return View(acquisti);
        }

        // GET: Acquisti/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acquisti = await _context.Acquisti
                .Include(a => a.Cliente)
                .Include(a => a.Fattura)
                .Include(a => a.Spedizione)
                .FirstOrDefaultAsync(m => m.AcquistiID == id);
            if (acquisti == null)
            {
                return NotFound();
            }

            return View(acquisti);
        }

        // POST: Acquisti/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var acquisti = await _context.Acquisti.FindAsync(id);
            _context.Acquisti.Remove(acquisti);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AcquistiExists(int id)
        {
            return _context.Acquisti.Any(e => e.AcquistiID == id);
        }
    }
}
