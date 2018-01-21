using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProgramasMobilidadeESW2017.Data;
using ProgramasMobilidadeESW2017.Models;

namespace ProgramasMobilidadeESW2017.Controllers
{
    public class CandidaturasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CandidaturasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Candidaturas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Candidaturas.Include(c => c.EstadoCandidatura);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Candidaturas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidatura = await _context.Candidaturas
                .Include(c => c.EstadoCandidatura)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (candidatura == null)
            {
                return NotFound();
            }

            return View(candidatura);
        }

        // GET: Candidaturas/Create
        public IActionResult Create()
        {
            ViewData["EstadoCandidaturaID"] = new SelectList(_context.EstadosCandidaturas, "ID", "ID");
            return View();
        }

        // POST: Candidaturas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ProgramaMobilidadeID,NomePessoaContacto,TelefonePessoaContacto,RelacaoComCandidato,EstadoCandidaturaID")] Candidatura candidatura)
        {
            if (ModelState.IsValid)
            {
                _context.Add(candidatura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EstadoCandidaturaID"] = new SelectList(_context.EstadosCandidaturas, "ID", "ID", candidatura.EstadoCandidaturaID);
            return View(candidatura);
        }

        // GET: Candidaturas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidatura = await _context.Candidaturas.SingleOrDefaultAsync(m => m.ID == id);
            if (candidatura == null)
            {
                return NotFound();
            }
            ViewData["EstadoCandidaturaID"] = new SelectList(_context.EstadosCandidaturas, "ID", "ID", candidatura.EstadoCandidaturaID);
            return View(candidatura);
        }

        // POST: Candidaturas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ProgramaMobilidadeID,NomePessoaContacto,TelefonePessoaContacto,RelacaoComCandidato,EstadoCandidaturaID")] Candidatura candidatura)
        {
            if (id != candidatura.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(candidatura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CandidaturaExists(candidatura.ID))
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
            ViewData["EstadoCandidaturaID"] = new SelectList(_context.EstadosCandidaturas, "ID", "ID", candidatura.EstadoCandidaturaID);
            return View(candidatura);
        }

        // GET: Candidaturas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidatura = await _context.Candidaturas
                .Include(c => c.EstadoCandidatura)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (candidatura == null)
            {
                return NotFound();
            }

            return View(candidatura);
        }

        // POST: Candidaturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var candidatura = await _context.Candidaturas.SingleOrDefaultAsync(m => m.ID == id);
            _context.Candidaturas.Remove(candidatura);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CandidaturaExists(int id)
        {
            return _context.Candidaturas.Any(e => e.ID == id);
        }
    }
}
