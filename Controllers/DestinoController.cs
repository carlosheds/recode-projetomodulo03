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
    public class DestinoController : Controller
    {
        private readonly AgenciaContext _context;

        public DestinoController(AgenciaContext context)
        {
            _context = context;
        }

        // GET: Destino
        public async Task<IActionResult> Index()
        {
            return View(await _context.DestinoModel.ToListAsync());
        }

        // GET: Destino/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var destinoModel = await _context.DestinoModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (destinoModel == null)
            {
                return NotFound();
            }

            return View(destinoModel);
        }

        // GET: Destino/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Destino/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Pais,Estado,Cidade")] DestinoModel destinoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(destinoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(destinoModel);
        }

        // GET: Destino/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var destinoModel = await _context.DestinoModel.FindAsync(id);
            if (destinoModel == null)
            {
                return NotFound();
            }
            return View(destinoModel);
        }

        // POST: Destino/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Pais,Estado,Cidade")] DestinoModel destinoModel)
        {
            if (id != destinoModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(destinoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DestinoModelExists(destinoModel.Id))
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
            return View(destinoModel);
        }

        // GET: Destino/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var destinoModel = await _context.DestinoModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (destinoModel == null)
            {
                return NotFound();
            }

            return View(destinoModel);
        }

        // POST: Destino/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var destinoModel = await _context.DestinoModel.FindAsync(id);
            _context.DestinoModel.Remove(destinoModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DestinoModelExists(int id)
        {
            return _context.DestinoModel.Any(e => e.Id == id);
        }
    }
}
