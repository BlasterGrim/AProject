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
    public class ClientiController : Controller
    {
        private readonly BloggingContext _context;

        public ClientiController(BloggingContext context)
        {
            _context = context;
        }

        // GET: Clienti
        /*public async Task<IActionResult> Index()
        {
            var bloggingContext = _context.Cliente.Include(c => c.Contatto).Include(c => c.Spedizione);
            return View(await bloggingContext.ToListAsync());
        }*/

        public async Task<IActionResult> Index(string SearchString, string SearchString1, string SearchString2, char SearchString3, string SearchString4, string SearchString5)
        {
            var name = from c in _context.Cliente.Include(c => c.Contatto).Include(i => i.Indirizzo).Include(t => t.Tipo)
                       select c;

            if (!String.IsNullOrEmpty(SearchString))
            {
                name = name.Where(s => s.nome.Contains(SearchString));
            }
            if (!String.IsNullOrEmpty(SearchString1))
            {
                name = name.Where(s => s.cognome.Contains(SearchString1));
            }
            if (!String.IsNullOrEmpty(SearchString2))
            {
                name = name.Where(s => s.dNascita.Contains(SearchString2));
            }
            if (!char.IsControl(SearchString3))
            {
                name = name.Where(s => s.sesso.Equals(SearchString3));
            }
               if (!String.IsNullOrEmpty(SearchString4) & String.IsNullOrEmpty(SearchString5))
            {
                name = name.Where(s => s.Tipo.descrizione.Contains(SearchString4));
            }
               if (!String.IsNullOrEmpty(SearchString5) & String.IsNullOrEmpty(SearchString4))
            {
                name = name.Where(s => s.Tipo.descrizione.Contains(SearchString5));
            }

            return View(await name.ToListAsync());
        }

        // GET: Clienti/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente
                .Include(c => c.Contatto)
                .Include(i => i.Indirizzo)
                .Include(t => t.Tipo)
                .FirstOrDefaultAsync(m => m.ClienteId == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: Clienti/Create
        public IActionResult Create()
        {
            ViewData["ContattoId"] = new SelectList(_context.Contatto, "ContattoId", "ContattoId");
            ViewData["IndirizzoId"] = new SelectList(_context.Indirizzo, "IndirizzoId", "IndirizzoId");
            ViewData["TipoId"] = new SelectList(_context.Tipo, "TipoId", "descrizione");
            return View();
        }


        // POST: Clienti/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClienteId,nome,cognome,dNascita,sesso,ContattoId,IndirizzoId,TipoId")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ContattoId"] = new SelectList(_context.Contatto, "ContattoId", "ContattoId", cliente.ContattoId);
            ViewData["IndirizzoId"] = new SelectList(_context.Indirizzo, "IndirizzoId", "IndirizzoId", cliente.IndirizzoId);
            ViewData["TipoId"] = new SelectList(_context.Tipo, "TipoId", "TipoId", cliente.TipoId);
            return View(cliente);
        }

        // GET: Clienti/Edit/5
        public async Task<IActionResult> Edit(int? id)
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
            ViewData["IndirizzoId"] = new SelectList(_context.Indirizzo, "IndirizzoId", "IndirizzoId", cliente.IndirizzoId);
            ViewData["TipoId"] = new SelectList(_context.Tipo, "TipoId", "TipoId", cliente.TipoId);
            return View(cliente);
        }

        // POST: Clienti/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClienteId,nome,cognome,dNascita,sesso,ContattoId,IndirizzoId,TipoId")] Cliente cliente)
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
            ViewData["IndirizzoId"] = new SelectList(_context.Indirizzo, "IndirizzoId", "IndirizzoId", cliente.IndirizzoId);
            ViewData["TipoId"] = new SelectList(_context.Tipo, "TipoId", "TipoId", cliente.TipoId);
            return View(cliente);
        }

        // GET: Clienti/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente
                .Include(c => c.Contatto)
                .Include(i => i.Indirizzo)
                .Include(t => t.Tipo)
                .FirstOrDefaultAsync(m => m.ClienteId == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: Clienti/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var cliente = await _context.Cliente.FindAsync(id);
            _context.Cliente.Remove(cliente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(int id)
        {
            return _context.Cliente.Any(e => e.ClienteId == id);
        }
    }
}
