using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using ProgramasMobilidadeESW2017.Data;
using ProgramasMobilidadeESW2017.Models;

namespace ProgramasMobilidadeESW2017
{
    public class InstituicoesController : Controller
    {
        /// <summary>
        /// Contexto da base de dados
        /// </summary>
        /// <remarks></remarks>
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Inicializa uma nova instância de <see cref="ProgramasMobilidadeESW2017.InstituicoesController" />. 
        /// </summary>
        /// <param name="context">O contexto da base da dados</param>
        public InstituicoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Instituicoes
        /// <summary>
        /// Devolve uma página com instituições
        /// </summary>
        /// <param name="searchString">string a pesquisar no nome das instituições e dos países das instituições</param>
        public async Task<IActionResult> Index(string searchString)
        {
            var instituicoes = _context.Instituicoes.Include(i => i.Pais);

            if (!String.IsNullOrEmpty(searchString))
            {

                return View(instituicoes.Where(i => i.Nome.Contains(searchString) || i.Pais.Nome.Contains(searchString))
                    .ToList());
            }

            return View(instituicoes.ToList());
        }

        // GET: Instituicoes/Details/5
        /// <summary>
        /// Devolve uma página com os detalhes da instituição
        /// </summary>
        /// <param name="id">ID da Instituição</param>
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
        /// <summary>
        /// Devolve uma página para adicionar uma instituição
        /// </summary>
        [Authorize(Roles = "Administrador")]
        public IActionResult Create()
        {
            //ViewData["PaisID"] = new SelectList(_context.Paises, "ID", "ID");
            PopulateInstituicoesDropDownList();
            return View();
        }

        // POST: Instituicoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Adiciona uma instituição à base de dados
        /// </summary>
        /// <param name="instituicao">Instituição a adicionar</param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
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
        /// <summary>
        /// Devolve uma página para editar uma instituição
        /// </summary>
        /// <param name="id">ID da instituição</param>
        [Authorize(Roles = "Administrador")]
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
        /// <summary>
        /// Guarda os dados da instituição editada
        /// </summary>
        /// <param name="id">ID da instituição</param>
        /// <param name="instituicao">Dados da instituição a guardar</param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
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
        /// <summary>
        /// Devolve uma página para eliminar uma instituição após confirmação
        /// </summary>
        /// <param name="id">ID da instituição</param>
        [Authorize(Roles = "Administrador")]
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
        /// <summary>
        /// Remove a instituição da base de dados
        /// </summary>
        /// <param name="id">ID da Instituição</param>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
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

        /// <summary>
        /// Coloca um selector com os paises na ViewBag
        /// </summary>
        /// <param name="selectedPais">Optional. O valor por defeito é null.</param>
        private void PopulateInstituicoesDropDownList(object selectedPais = null)
        {
            var paisQuery = from p in _context.Paises
                            orderby p.Nome
                            select p;
            ViewBag.PaisID = new SelectList(paisQuery.AsNoTracking(), "ID", "Nome", selectedPais);
        }

    }
}
