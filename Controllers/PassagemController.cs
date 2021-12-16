using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgenciaViagemUp.Data;
using AgenciaViagemUp.Models;

namespace AgenciaViagemUp.Controllers
{
    public class PassagemController : Controller
    {
        private readonly AgenciaContext _context;

        public PassagemController(AgenciaContext context)
        {
            _context = context;
        }

        // GET: Passagem
        public async Task<IActionResult> Index()
        {
            var agenciaContext = _context.PassagemModel.Include(p => p.ClienteModel).Include(p => p.DestinoModel);
            return View(await agenciaContext.ToListAsync());
        }

        // GET: Passagem/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passagemModel = await _context.PassagemModel
                .Include(p => p.ClienteModel)
                .Include(p => p.DestinoModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (passagemModel == null)
            {
                return NotFound();
            }

            return View(passagemModel);
        }

        // GET: Passagem/Create
        public IActionResult Create()
        {
            ViewData["ClienteModelId"] = new SelectList(_context.ClienteModel, "Id", "Nome");
            ViewData["DestinoModelId"] = new SelectList(_context.DestinoModel, "Id", "Cidade");
            return View();
        }

        // POST: Passagem/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClienteModelId,DestinoModelId,Preco")] PassagemModel passagemModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(passagemModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteModelId"] = new SelectList(_context.ClienteModel, "Id", "Nome", passagemModel.ClienteModelId);
            ViewData["DestinoModelId"] = new SelectList(_context.DestinoModel, "Id", "Cidade", passagemModel.DestinoModelId);
            return View(passagemModel);
        }

        // GET: Passagem/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passagemModel = await _context.PassagemModel.FindAsync(id);
            if (passagemModel == null)
            {
                return NotFound();
            }
            ViewData["ClienteModelId"] = new SelectList(_context.ClienteModel, "Id", "Nome", passagemModel.ClienteModelId);
            ViewData["DestinoModelId"] = new SelectList(_context.DestinoModel, "Id", "Cidade", passagemModel.DestinoModelId);
            return View(passagemModel);
        }

        // POST: Passagem/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClienteModelId,DestinoModelId,Preco")] PassagemModel passagemModel)
        {
            if (id != passagemModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(passagemModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PassagemModelExists(passagemModel.Id))
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
            ViewData["ClienteModelId"] = new SelectList(_context.ClienteModel, "Id", "Nome", passagemModel.ClienteModelId);
            ViewData["DestinoModelId"] = new SelectList(_context.DestinoModel, "Id", "Cidade", passagemModel.DestinoModelId);
            return View(passagemModel);
        }

        // GET: Passagem/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passagemModel = await _context.PassagemModel
                .Include(p => p.ClienteModel)
                .Include(p => p.DestinoModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (passagemModel == null)
            {
                return NotFound();
            }

            return View(passagemModel);
        }

        // POST: Passagem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var passagemModel = await _context.PassagemModel.FindAsync(id);
            _context.PassagemModel.Remove(passagemModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PassagemModelExists(int id)
        {
            return _context.PassagemModel.Any(e => e.Id == id);
        }
    }
}
