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
    public class FattureController : Controller
    {
        private readonly BloggingContext _context;

        public FattureController(BloggingContext context)
        {
            _context = context;
        }

        // GET: Fatture
        public async Task<IActionResult> Index()
        {
            var bloggingContext = _context.Fattura.Include(f => f.Cliente);
            return View(await bloggingContext.ToListAsync());
        }

        // GET: Fatture/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fattura = await _context.Fattura
                .Include(f => f.Cliente)
                .FirstOrDefaultAsync(m => m.FatturaId == id);
            if (fattura == null)
            {
                return NotFound();
            }

            return View(fattura);
        }

        // GET: Fatture/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "nome", "ClienteId", "cognome");
            return View();
        }

        // POST: Fatture/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FatturaId,quantitaProdotto,iva,sconto,totFattura,ClienteId")] Fattura fattura)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fattura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "ClienteId", fattura.ClienteId);
            return View(fattura);
        }

        // GET: Fatture/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fattura = await _context.Fattura.FindAsync(id);
            if (fattura == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "cognome", fattura.ClienteId);
            return View(fattura);
        }

        // POST: Fatture/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FatturaId,quantitaProdotto,iva,sconto,totFattura,ClienteId")] Fattura fattura)
        {
            if (id != fattura.FatturaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fattura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FatturaExists(fattura.FatturaId))
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
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "cognome", fattura.ClienteId);
            return View(fattura);
        }

        // GET: Fatture/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fattura = await _context.Fattura
                .Include(f => f.Cliente)
                .FirstOrDefaultAsync(m => m.FatturaId == id);
            if (fattura == null)
            {
                return NotFound();
            }

            return View(fattura);
        }

        // POST: Fatture/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fattura = await _context.Fattura.FindAsync(id);
            _context.Fattura.Remove(fattura);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FatturaExists(int id)
        {
            return _context.Fattura.Any(e => e.FatturaId == id);
        }
    }
}
