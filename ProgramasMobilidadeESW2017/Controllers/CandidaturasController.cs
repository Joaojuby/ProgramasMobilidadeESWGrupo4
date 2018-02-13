using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProgramasMobilidadeESW2017.Data;
using ProgramasMobilidadeESW2017.Models;

namespace ProgramasMobilidadeESW2017.Controllers
{
    [Authorize]
    public class CandidaturasController : Controller
    {
        private readonly ApplicationDbContext _context;
        //private readonly UserManager<ApplicationUser> _userManager;
        //private readonly SignInManager<ApplicationUser> _signInManager;

        //public CandidaturasController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        public CandidaturasController(ApplicationDbContext context)
        {
            _context = context;
            //_userManager = userManager;
            //_signInManager = signInManager;
        }

        // GET: Candidaturas
        [Authorize(Roles = "Utilizador, Administrador")]
        public async Task<IActionResult> Index()
        {
            bool isAdmin = User.IsInRole("Administrador");
            
            if (isAdmin)
            {
                var applicationDbContext = _context.Candidaturas.Include(c => c.EstadoCandidatura).Include(c => c.ProgramaMobilidade).Include(u => u.User);
                return View(await applicationDbContext.ToListAsync());
            } else
            {
                var userName = User.Identity.Name;
                var user = await _context.Users.SingleOrDefaultAsync(u => u.UserName == userName);

                var applicationDbContext = _context.Candidaturas.Where(u => u.User == user).Include(c => c.EstadoCandidatura).Include(c => c.ProgramaMobilidade).Include(u => u.User);
                return View(await applicationDbContext.ToListAsync());
            }
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
                .Include(u => u.User)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (candidatura == null)
            {
                return NotFound();
            }

            var viewModel = new AgendamentoEntrevista { Candidatura = candidatura };

            return View(viewModel);
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

            //ViewData["EstadoCandidaturaID"] = new SelectList(_context.EstadosCandidaturas, "ID", "Designacao");
            // ViewData["ProgramaMobilidadeID"] = new SelectList(_context.ProgramasMobilidade, "ID", "Descricao");
            return View();
        }

        // POST: Candidaturas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Utilizador")]
        public async Task<IActionResult> Create([Bind("ProgramaMobilidadeID,NomePessoaContacto,TelefonePessoaContacto,RelacaoComCandidato")] Candidatura candidatura)
        {
            if (ModelState.IsValid)
            {
                var userName = User.Identity.Name;
                var user = await _context.Users.SingleOrDefaultAsync(u => u.UserName == userName);
                candidatura.User = user;

                var estadoCandidatura = await _context.EstadosCandidaturas.SingleOrDefaultAsync(e => e.Designacao == "Em Análise");
                candidatura.EstadoCandidatura = estadoCandidatura;

                _context.Add(candidatura);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "ProgramasMobilidade");
            }
            ViewData["ProgramaMobilidadeID"] = new SelectList(_context.ProgramasMobilidade, "ID", "Descricao", candidatura.ProgramaMobilidadeID);
            return View();
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
                .Include(u => u.User)
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
        public async Task<IActionResult> CancelConfirmed(int id, [Bind("Nota")] ObservacaoCandidatura observacao)
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

        // POST: Candidaturas/Agendar/1
        [HttpPost, ActionName("Agendar")]
        [Authorize(Roles = "Administrador")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AgendarEntrevista(int id, [Bind("DataEntrevista")] Entrevista entrevista)
        {
            var candidatura = await _context.Candidaturas.SingleOrDefaultAsync(m => m.ID == id);
            var estadoAgendado = await _context.EstadosCandidaturas.SingleOrDefaultAsync(e => e.Designacao == "Agendada");
            candidatura.EstadoCandidaturaID = estadoAgendado.ID;

            // Adiciona entrevista
            entrevista.CandidaturaID = candidatura.ID;
            _context.Add(entrevista);

            _context.Candidaturas.Update(candidatura);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [ActionName("ConcluirEntrevista")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> ConcluirEntrevista(int id)
        {
            var candidatura = await _context.Candidaturas.SingleOrDefaultAsync(m => m.ID == id);
            var estadoAgendado = await _context.EstadosCandidaturas.SingleOrDefaultAsync(e => e.Designacao == "Aguardar Resultados");
            candidatura.EstadoCandidaturaID = estadoAgendado.ID;

            _context.Candidaturas.Update(candidatura);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Details), new { id });
        }

        [ActionName("AprovarCandidatura")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> AprovarCandidatura(int id)
        {
            var candidatura = await _context.Candidaturas.SingleOrDefaultAsync(m => m.ID == id);
            var estadoAgendado = await _context.EstadosCandidaturas.SingleOrDefaultAsync(e => e.Designacao == "Aprovada");
            candidatura.EstadoCandidaturaID = estadoAgendado.ID;

            _context.Candidaturas.Update(candidatura);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Details), new { id });
        }

        [ActionName("RejeitarCandidatura")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> RejeitarCandidatura(int id)
        {
            var candidatura = await _context.Candidaturas.SingleOrDefaultAsync(m => m.ID == id);
            var estadoAgendado = await _context.EstadosCandidaturas.SingleOrDefaultAsync(e => e.Designacao == "Não Aprovada");
            candidatura.EstadoCandidaturaID = estadoAgendado.ID;

            _context.Candidaturas.Update(candidatura);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Details), new { id });
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
