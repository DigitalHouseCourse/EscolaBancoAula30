﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Escola.Models;

namespace Escola.Controllers
{
    public class AlunoesController : Controller
    {
        private readonly EscolaContext _context;

        public AlunoesController(EscolaContext context)
        {
            _context = context;
        }

        // GET: Alunoes
        public async Task<IActionResult> Index()
        {
              return _context.alunos != null ? 
                          View(await _context.alunos.ToListAsync()) :
                          Problem("Entity set 'EscolaContext.alunos'  is null.");
        }

        // GET: Alunoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.alunos == null)
            {
                return NotFound();
            }

            var aluno = await _context.alunos
                .FirstOrDefaultAsync(m => m.id == id);
            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }

        // GET: Alunoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Alunoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nome,sobrenome")] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aluno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aluno);
        }

        // GET: Alunoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.alunos == null)
            {
                return NotFound();
            }

            var aluno = await _context.alunos.FindAsync(id);
            if (aluno == null)
            {
                return NotFound();
            }
            return View(aluno);
        }

        // POST: Alunoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nome,sobrenome")] Aluno aluno)
        {
            if (id != aluno.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aluno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlunoExists(aluno.id))
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
            return View(aluno);
        }

        // GET: Alunoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.alunos == null)
            {
                return NotFound();
            }

            var aluno = await _context.alunos
                .FirstOrDefaultAsync(m => m.id == id);
            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }

        // POST: Alunoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.alunos == null)
            {
                return Problem("Entity set 'EscolaContext.alunos'  is null.");
            }
            var aluno = await _context.alunos.FindAsync(id);
            if (aluno != null)
            {
                _context.alunos.Remove(aluno);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlunoExists(int id)
        {
          return (_context.alunos?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
