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
    public class ProgramasMobilidadeController : Controller
    {
        /// <summary>
        /// Contexto da base de dados
        /// </summary>
        /// <remarks></remarks>
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Inicializa uma nova instância de <see cref="ProgramasMobilidadeESW2017.ProgramasMobilidadeController" />. 
        /// </summary>
        /// <param name="context">O contexto da base da dados</param>
        public ProgramasMobilidadeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProgramaMobilidades
        /// <summary>
        /// Devolve uma página com programas de mobilidade
        /// </summary>
        /// <param name="searchString">string a pesquisar no nome dos programas mobilidade</param>
        public async Task<IActionResult> Index(string searchString)
        {
            var programasMobilidade = _context.ProgramasMobilidade.Include(p => p.TipoProgramaMobilidade);

            if (!String.IsNullOrEmpty(searchString))
            {

                return View(programasMobilidade.Where(i => i.Nome.Contains(searchString)).ToList());
            }

            return View(programasMobilidade.ToList());
        }

        // GET: ProgramaMobilidades/Details/5
        /// <summary>
        /// Devolve uma página com os detalhes do programa de mobilidade
        /// </summary>
        /// <param name="id">ID do Programa Mobilidade</param>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programaMobilidade = await _context.ProgramasMobilidade
                .Include(p => p.TipoProgramaMobilidade)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.ID == id);
            if (programaMobilidade == null)
            {
                return NotFound();
            }

            return View(programaMobilidade);
        }

        // GET: ProgramaMobilidades/Create
        /// <summary>
        /// Devolve uma página para adicionar um programa de mobilidade
        /// </summary>
        [Authorize(Roles = "Administrador")]
        public IActionResult Create()
        {
            //ViewData["TipoProgramaMobilidadeID"] = new SelectList(_context.TiposProgramaMobilidade, "ID", "ID");
            PopulateTipoProgramaDropDownList();
            return View();
        }

        // POST: ProgramaMobilidades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Adiciona um programa de mobilidade à base de dados.
        /// </summary>
        /// <param name="programaMobilidade">programa de mobilidade a adicionar</param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Create([Bind("ID,Nome,Descricao,TipoProgramaMobilidadeID,Duracao,DataInicioInscricao,DataLimiteInscricao")] ProgramaMobilidade programaMobilidade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(programaMobilidade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["TipoProgramaMobilidadeID"] = new SelectList(_context.TiposProgramaMobilidade, "ID", "ID", programaMobilidade.TipoProgramaMobilidadeID);
            PopulateTipoProgramaDropDownList(programaMobilidade.TipoProgramaMobilidadeID);
            return View(programaMobilidade);
        }

        // GET: ProgramaMobilidades/Edit/5
        /// <summary>
        /// Devolve uma página para editar um programa de mobilidade
        /// </summary>
        /// <param name="id">ID do programa de mobilidade</param>
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programaMobilidade = await _context.ProgramasMobilidade.AsNoTracking().SingleOrDefaultAsync(m => m.ID == id);
            if (programaMobilidade == null)
            {
                return NotFound();
            }
            //ViewData["TipoProgramaMobilidadeID"] = new SelectList(_context.TiposProgramaMobilidade, "ID", "ID", programaMobilidade.TipoProgramaMobilidadeID);
            PopulateTipoProgramaDropDownList(programaMobilidade.TipoProgramaMobilidadeID);
            return View(programaMobilidade);
        }

        // POST: ProgramaMobilidades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Guarda os detalhes do programa de mobilidade alterado
        /// </summary>
        /// <param name="id">ID do programa mobilidade</param>
        /// <param name="programaMobilidade">Dados do programa de mobilidade a guardar</param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nome,Descricao,TipoProgramaMobilidadeID,Duracao,DataInicioInscricao,DataLimiteInscricao")] ProgramaMobilidade programaMobilidade)
        {
            if (id != programaMobilidade.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(programaMobilidade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProgramaMobilidadeExists(programaMobilidade.ID))
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
            //ViewData["TipoProgramaMobilidadeID"] = new SelectList(_context.TiposProgramaMobilidade, "ID", "ID", programaMobilidade.TipoProgramaMobilidadeID);
            PopulateTipoProgramaDropDownList(programaMobilidade.TipoProgramaMobilidadeID);
            return View(programaMobilidade);
        }

        // GET: ProgramaMobilidades/Delete/5
        /// <summary>
        /// Devolve uma página para eliminar um programa de mobilidade após confirmação
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programaMobilidade = await _context.ProgramasMobilidade
                .Include(p => p.TipoProgramaMobilidade)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.ID == id);
            if (programaMobilidade == null)
            {
                return NotFound();
            }

            return View(programaMobilidade);
        }

        // POST: ProgramaMobilidades/Delete/5
        /// <summary>
        /// Remove o programa de mobilidade da base de dados
        /// </summary>
        /// <param name="id">ID do programa de mobilidade</param>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var programaMobilidade = await _context.ProgramasMobilidade.SingleOrDefaultAsync(m => m.ID == id);
            _context.ProgramasMobilidade.Remove(programaMobilidade);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProgramaMobilidadeExists(int id)
        {
            return _context.ProgramasMobilidade.Any(e => e.ID == id);
        }

        /// <summary>
        /// Coloca um selector com os tipos de programa na ViewBag
        /// </summary>
        /// <param name="selectedTipoPrograma">Optional. O valor por defeito é null.</param>
        private void PopulateTipoProgramaDropDownList(object selectedTipoPrograma = null)
        {
            var tipoProgramaMobilidade = from t in _context.TiposProgramaMobilidade
                                         orderby t.Designacao
                                         select t;
            ViewBag.TipoProgramaID = new SelectList(tipoProgramaMobilidade.AsNoTracking(), "ID", "Designacao", selectedTipoPrograma);
        }
    }
}
