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
    public class ContattiController : Controller
    {
        private readonly BloggingContext _context;

        public ContattiController(BloggingContext context)
        {
            _context = context;
        }

        // GET: Contatti
        public async Task<IActionResult> Index()
        {
            return View(await _context.Contatto.ToListAsync());
        }

        // GET: Contatti/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contatto = await _context.Contatto
                .FirstOrDefaultAsync(m => m.ContattoId == id);
            if (contatto == null)
            {
                return NotFound();
            }

            return View(contatto);
        }

        // GET: Contatti/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contatti/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContattoId,nTelefono,nFax,nCellulare,eMail")] Contatto contatto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contatto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contatto);
        }

        // GET: Contatti/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contatto = await _context.Contatto.FindAsync(id);
            if (contatto == null)
            {
                return NotFound();
            }
            return View(contatto);
        }

        // POST: Contatti/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContattoId,nTelefono,nFax,nCellulare,eMail")] Contatto contatto)
        {
            if (id != contatto.ContattoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contatto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContattoExists(contatto.ContattoId))
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
            return View(contatto);
        }

        // GET: Contatti/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contatto = await _context.Contatto
                .FirstOrDefaultAsync(m => m.ContattoId == id);
            if (contatto == null)
            {
                return NotFound();
            }

            return View(contatto);
        }

        // POST: Contatti/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contatto = await _context.Contatto.FindAsync(id);
            _context.Contatto.Remove(contatto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContattoExists(int id)
        {
            return _context.Contatto.Any(e => e.ContattoId == id);
        }
    }
}
