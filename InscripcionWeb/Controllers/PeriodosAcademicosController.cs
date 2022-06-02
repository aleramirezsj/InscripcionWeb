using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InscripcionWeb.Data;
using InscripcionWeb.Models;

namespace InscripcionWeb.Controllers
{
    public class PeriodosAcademicosController : Controller
    {
        private readonly InscripcionWebContext _context;

        public PeriodosAcademicosController(InscripcionWebContext context)
        {
            _context = context;
        }

        // GET: PeriodosAcademicos
        public async Task<IActionResult> Index()
        {
            var inscripcionWebContext = _context.PeriodosAcademicos.Include(p => p.Carrera);
            return View(await inscripcionWebContext.ToListAsync());
        }

        // GET: PeriodosAcademicos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PeriodosAcademicos == null)
            {
                return NotFound();
            }

            var periodoAcademico = await _context.PeriodosAcademicos
                .Include(p => p.Carrera)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (periodoAcademico == null)
            {
                return NotFound();
            }

            return View(periodoAcademico);
        }

        // GET: PeriodosAcademicos/Create
        public IActionResult Create()
        {
            ViewData["CarreraId"] = new SelectList(_context.Carreras, "Id", "Nombre");
            return View();
        }

        // POST: PeriodosAcademicos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,CarreraId")] PeriodoAcademico periodoAcademico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(periodoAcademico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarreraId"] = new SelectList(_context.Carreras, "Id", "Nombre", periodoAcademico.CarreraId);
            return View(periodoAcademico);
        }

        // GET: PeriodosAcademicos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PeriodosAcademicos == null)
            {
                return NotFound();
            }

            var periodoAcademico = await _context.PeriodosAcademicos.FindAsync(id);
            if (periodoAcademico == null)
            {
                return NotFound();
            }
            ViewData["CarreraId"] = new SelectList(_context.Carreras, "Id", "Nombre", periodoAcademico.CarreraId);
            return View(periodoAcademico);
        }

        // POST: PeriodosAcademicos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,CarreraId")] PeriodoAcademico periodoAcademico)
        {
            if (id != periodoAcademico.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(periodoAcademico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PeriodoAcademicoExists(periodoAcademico.Id))
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
            ViewData["CarreraId"] = new SelectList(_context.Carreras, "Id", "Nombre", periodoAcademico.CarreraId);
            return View(periodoAcademico);
        }

        // GET: PeriodosAcademicos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PeriodosAcademicos == null)
            {
                return NotFound();
            }

            var periodoAcademico = await _context.PeriodosAcademicos
                .Include(p => p.Carrera)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (periodoAcademico == null)
            {
                return NotFound();
            }

            return View(periodoAcademico);
        }

        // POST: PeriodosAcademicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PeriodosAcademicos == null)
            {
                return Problem("Entity set 'InscripcionWebContext.PeriodoAcademico'  is null.");
            }
            var periodoAcademico = await _context.PeriodosAcademicos.FindAsync(id);
            if (periodoAcademico != null)
            {
                _context.PeriodosAcademicos.Remove(periodoAcademico);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PeriodoAcademicoExists(int id)
        {
          return (_context.PeriodosAcademicos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
