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
    public class ClienteController : Controller
    {
        private readonly BloggingContext _context;

        public ClienteController(BloggingContext context)
        {
            _context = context;
        }

        // GET: Cliente
        public async Task<IActionResult> Index()
        {
            var bloggingContext = _context.Cliente.Include(c => c.Contatto).Include(c => c.Spedizione);
            return View(await bloggingContext.ToListAsync());
        }

        // GET: Cliente/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente
                .Include(c => c.Contatto)
                .Include(c => c.Spedizione)
                .FirstOrDefaultAsync(m => m.ClienteId == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: Cliente/Create
        public IActionResult Create()
        {
            ViewData["ContattoId"] = new SelectList(_context.Contatto, "ContattoId", "ContattoId");
            ViewData["SpedizioneId"] = new SelectList(_context.Spedizione, "SpedizioneId", "SpedizioneId");
            return View();
        }

        // POST: Cliente/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClienteId,nome,cognome,dNascita,sesso,ContattoId,SpedizioneId")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ContattoId"] = new SelectList(_context.Contatto, "ContattoId", "ContattoId", cliente.ContattoId);
            ViewData["SpedizioneId"] = new SelectList(_context.Spedizione, "SpedizioneId", "SpedizioneId", cliente.SpedizioneId);
            return View(cliente);
        }

        // GET: Cliente/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            ViewData["ContattoId"] = new SelectList(_context.Contatto, "ContattoId", "ContattoId", cliente.ContattoId);
            ViewData["SpedizioneId"] = new SelectList(_context.Spedizione, "SpedizioneId", "SpedizioneId", cliente.SpedizioneId);
            return View(cliente);
        }

        // POST: Cliente/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ClienteId,nome,cognome,dNascita,sesso,ContattoId,SpedizioneId")] Cliente cliente)
        {
            if (id != cliente.ClienteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.ClienteId))
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
            ViewData["ContattoId"] = new SelectList(_context.Contatto, "ContattoId", "ContattoId", cliente.ContattoId);
            ViewData["SpedizioneId"] = new SelectList(_context.Spedizione, "SpedizioneId", "SpedizioneId", cliente.SpedizioneId);
            return View(cliente);
        }

        // GET: Cliente/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente
                .Include(c => c.Contatto)
                .Include(c => c.Spedizione)
                .FirstOrDefaultAsync(m => m.ClienteId == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var cliente = await _context.Cliente.FindAsync(id);
            _context.Cliente.Remove(cliente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(string id)
        {
            return _context.Cliente.Any(e => e.ClienteId == id);
        }
    }
}
