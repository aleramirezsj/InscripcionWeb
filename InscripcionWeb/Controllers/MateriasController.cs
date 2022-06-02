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
    public class MateriasController : Controller
    {
        private readonly InscripcionWebContext _context;

        public MateriasController(InscripcionWebContext context)
        {
            _context = context;
        }

        // GET: Materias
        public async Task<IActionResult> Index()
        {
            var inscripcionWebContext = _context.Materias.Include(m => m.PeriodoAcademico).ThenInclude(p=>p.Carrera);
            return View(await inscripcionWebContext.ToListAsync());
        }

        // GET: Materias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Materias == null)
            {
                return NotFound();
            }

            var materia = await _context.Materias
                .Include(m => m.PeriodoAcademico)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (materia == null)
            {
                return NotFound();
            }

            return View(materia);
        }

        // GET: Materias/Create
        public IActionResult Create()
        {
            //ViewData["PeriodoAcademicoId"] = new SelectList(_context.PeriodosAcademicos, "Id", "Nombre");
            ViewData["PeriodoAcademicoId"] = new SelectList(
                from periodo in _context.PeriodosAcademicos.Include(p=>p.Carrera).ToList()
                select new {Id=periodo.Id, Nombre=periodo.Nombre+" "+periodo.Carrera.Nombre},"Id","Nombre");
                
            return View();
        }

        // POST: Materias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,PeriodoAcademicoId")] Materia materia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(materia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PeriodoAcademicoId"] = new SelectList(_context.PeriodosAcademicos, "Id", "Nombre", materia.PeriodoAcademicoId);
            return View(materia);
        }

        // GET: Materias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Materias == null)
            {
                return NotFound();
            }

            var materia = await _context.Materias.FindAsync(id);
            if (materia == null)
            {
                return NotFound();
            }
            ViewData["PeriodoAcademicoId"] = new SelectList(_context.PeriodosAcademicos, "Id", "Nombre", materia.PeriodoAcademicoId);
            return View(materia);
        }

        // POST: Materias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,PeriodoAcademicoId")] Materia materia)
        {
            if (id != materia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(materia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MateriaExists(materia.Id))
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
            ViewData["PeriodoAcademicoId"] = new SelectList(_context.PeriodosAcademicos, "Id", "Nombre", materia.PeriodoAcademicoId);
            return View(materia);
        }

        // GET: Materias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Materias == null)
            {
                return NotFound();
            }

            var materia = await _context.Materias
                .Include(m => m.PeriodoAcademico)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (materia == null)
            {
                return NotFound();
            }

            return View(materia);
        }

        // POST: Materias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Materias == null)
            {
                return Problem("Entity set 'InscripcionWebContext.Materia'  is null.");
            }
            var materia = await _context.Materias.FindAsync(id);
            if (materia != null)
            {
                _context.Materias.Remove(materia);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MateriaExists(int id)
        {
          return (_context.Materias?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public async Task<IActionResult> Periodos(int? id)
        {
            if (id == null || _context.Materias == null)
            {
                return NotFound();
            }

            var materia = await _context.Materias
                .Include(m => m.PeriodoAcademico)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (materia == null)
            {
                return NotFound();
            }

            return View(materia);
        }

    }
}
