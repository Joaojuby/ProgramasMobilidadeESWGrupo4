using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Candidaturas.Include(c => c.EstadoCandidatura).Include(c => c.ProgramaMobilidade);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Candidaturas/Details/5
        [Authorize(Roles = "Utilizador, Administrador")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidatura = await _context.Candidaturas
                .Include(c => c.EstadoCandidatura)
                .Include(c => c.ProgramaMobilidade)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (candidatura == null)
            {
                return NotFound();
            }

            return View(candidatura);
        }

        // GET: Candidaturas/Create
        [Authorize(Roles = "Utilizador")]
        public IActionResult Create(int? id)
        {
            if (id != null)
            {
                PopulateProgramaMobilidadeDropDownList(id);
            }
            else
            {
                PopulateProgramaMobilidadeDropDownList();
            }

            ViewData["EstadoCandidaturaID"] = new SelectList(_context.EstadosCandidaturas, "ID", "ID");
            // ViewData["ProgramaMobilidadeID"] = new SelectList(_context.ProgramasMobilidade, "ID", "Descricao");
            return View();
        }

        // POST: Candidaturas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Utilizador")]
        public async Task<IActionResult> Create([Bind("ProgramaMobilidadeID,EstadoCandidaturaID,NomePessoaContacto,TelefonePessoaContacto,RelacaoComCandidato")] Candidatura candidatura)
        {
            if (ModelState.IsValid)
            {
                _context.Add(candidatura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EstadoCandidaturaID"] = new SelectList(_context.EstadosCandidaturas, "ID", "ID", candidatura.EstadoCandidaturaID);
            ViewData["ProgramaMobilidadeID"] = new SelectList(_context.ProgramasMobilidade, "ID", "Descricao", candidatura.ProgramaMobilidadeID);
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
            ViewData["ProgramaMobilidadeID"] = new SelectList(_context.ProgramasMobilidade, "ID", "Descricao", candidatura.ProgramaMobilidadeID);
            return View(candidatura);
        }

        // POST: Candidaturas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ProgramaMobilidadeID,EstadoCandidaturaID,NomePessoaContacto,TelefonePessoaContacto,RelacaoComCandidato")] Candidatura candidatura)
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
            ViewData["ProgramaMobilidadeID"] = new SelectList(_context.ProgramasMobilidade, "ID", "Descricao", candidatura.ProgramaMobilidadeID);
            return View(candidatura);
        }

        // GET: Candidaturas/Delete/5
        [Authorize(Roles = "Administrador, Utilizador")]
        public async Task<IActionResult> Cancel(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidatura = await _context.Candidaturas
                .Include(c => c.EstadoCandidatura)
                .Include(c => c.ProgramaMobilidade)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (candidatura == null)
            {
                return NotFound();
            }

            return View(candidatura);
        }

        // POST: Candidaturas/Delete/5
        [HttpPost, ActionName("Cancel")]
        [Authorize(Roles = "Administrador, Utilizador")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CancelConfirmed(int id, [Bind ("Nota")] ObservacaoCandidatura observacao)
        {
            var candidatura = await _context.Candidaturas.SingleOrDefaultAsync(m => m.ID == id);
            var estadoCancelado = await _context.EstadosCandidaturas.SingleOrDefaultAsync(e => e.Designacao == "Cancelada");
            candidatura.EstadoCandidaturaID = estadoCancelado.ID;

            // Adiciona observacao
            observacao.CandidaturaID = candidatura.ID;
            _context.Add(observacao);

            _context.Candidaturas.Update(candidatura);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CandidaturaExists(int id)
        {
            return _context.Candidaturas.Any(e => e.ID == id);
        }

        private void PopulateProgramaMobilidadeDropDownList(object selectedProgramaMobilidade = null)
        {
            var programaMobilidade = from p in _context.ProgramasMobilidade
                                     select p;
            ViewBag.ProgramaMobilidadeID = new SelectList(programaMobilidade.AsNoTracking(), "ID", "Nome", selectedProgramaMobilidade);
        }
    }
}
