using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CesiNewsModel.Context;
using CesiNewsModel.Entities;

namespace CesiNewsBackofficeMVC.Controllers
{
    public class TextesController : Controller
    {
        private readonly NewsDbContext _context;

        public TextesController(NewsDbContext context)
        {
            _context = context;
        }


        // GET: Textes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Textes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Libelle")] Texte texte)
        {
            if (ModelState.IsValid)
            {
                _context.Add(texte);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), "Supports");
            }
            return View(texte);
        }

        // GET: Textes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var texte = await _context.Textes.FindAsync(id);
            if (texte == null)
            {
                return NotFound();
            }
            return View(texte);
        }

        // POST: Textes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Libelle")] Texte texte)
        {
            if (id != texte.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(texte);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TexteExists(texte.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), "Supports");
            }
            return View(texte);
        }


        private bool TexteExists(int id)
        {
            return _context.Textes.Any(e => e.Id == id);
        }
    }
}
