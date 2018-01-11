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

namespace ProgramasMobilidadeESW2017
{
    public class InstituicoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InstituicoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Instituicoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Instituicoes.Include(i => i.Pais);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Instituicoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instituicao = await _context.Instituicoes
                .Include(i => i.Pais)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.ID == id);
            if (instituicao == null)
            {
                return NotFound();
            }

            return View(instituicao);
        }

        // GET: Instituicoes/Create
        [Authorize]
        public IActionResult Create()
        {
            //ViewData["PaisID"] = new SelectList(_context.Paises, "ID", "ID");
            PopulateInstituicoesDropDownList();
            return View();
        }

        // POST: Instituicoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("ID,Nome,Morada,Email,PhoneNumber,Website,PaisID")] Instituicao instituicao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(instituicao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["PaisID"] = new SelectList(_context.Paises, "ID", "ID", instituicao.PaisID);
            PopulateInstituicoesDropDownList(instituicao.PaisID);
            return View(instituicao);
        }

        // GET: Instituicoes/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instituicao = await _context.Instituicoes.AsNoTracking().SingleOrDefaultAsync(m => m.ID == id);
            if (instituicao == null)
            {
                return NotFound();
            }
            //ViewData["PaisID"] = new SelectList(_context.Paises, "ID", "ID", instituicao.PaisID);
            PopulateInstituicoesDropDownList(instituicao.PaisID);
            return View(instituicao);
        }

        // POST: Instituicoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nome,Morada,Email,PhoneNumber,Website,PaisID")] Instituicao instituicao)
        {
            if (id != instituicao.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(instituicao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstituicaoExists(instituicao.ID))
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
            //ViewData["PaisID"] = new SelectList(_context.Paises, "ID", "ID", instituicao.PaisID);
            PopulateInstituicoesDropDownList(instituicao.PaisID);
            return View(instituicao);
        }

        // GET: Instituicoes/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instituicao = await _context.Instituicoes
                .Include(i => i.Pais)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.ID == id);
            if (instituicao == null)
            {
                return NotFound();
            }

            return View(instituicao);
        }

        // POST: Instituicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var instituicao = await _context.Instituicoes.SingleOrDefaultAsync(m => m.ID == id);
            _context.Instituicoes.Remove(instituicao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InstituicaoExists(int id)
        {
            return _context.Instituicoes.Any(e => e.ID == id);
        }

        private void PopulateInstituicoesDropDownList(object selectedPais = null)
        {
            var paisQuery = from p in _context.Paises
                            orderby p.Nome
                            select p;
            ViewBag.PaisID = new SelectList(paisQuery.AsNoTracking(), "ID", "Nome", selectedPais);
        }

    }
}
