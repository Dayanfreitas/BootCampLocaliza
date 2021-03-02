using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CursoMVC.Models;


namespace CursoMVC.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly Contexto _context;

        public CategoriaController(Contexto  contexto) 
        {
            _context = contexto;
        }
    

        public async Task<IActionResult> Index()
        {
            return View(await _context.Categorias.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, Descricao")] Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(categoria);
        }

        public async Task<IActionResult> Edit(int? id) 
        {
            if (id == null) 
            {
                return NotFound();
            }
            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Descricao")] Categoria categoria) 
        {
            if (id != categoria.Id) 
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try 
                {
                    _context.Update(categoria);
                    await _context.SaveChangesAsync();
                }catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriaExists(categoria.Id)) 
                    {
                        return NotFound();
                    }else 
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
        
            return View(categoria);
        }

         public async Task<IActionResult> Delete(int? id) 
        {
            if (id == null) 
            {
                return NotFound();
            }
            var categoria = await _context.Categorias.FirstOrDefaultAsync(m => m.Id == id);
            if (categoria == null)
            {
                return NotFound();
            }
            return View(categoria);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id) 
        {
            
            var categoria = await _context.Categorias.FindAsync(id);
            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) 
            {
                return NotFound();
            }

            var categoria = await _context.Categorias.FirstOrDefaultAsync(m => m.Id == id);
            if (categoria == null) 
            {
                return NotFound();
            }
            return View(categoria);
        }

        private bool CategoriaExists(int id) 
        {
            return _context.Categorias.Any(e => e.Id == id);
        }
    }
}