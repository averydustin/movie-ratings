using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieStorageAveryDustin.Models;

namespace MovieStorageAveryDustin.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieDBcontext _context;

        public MoviesController(MovieDBcontext context)
        {
            _context = context;
        }

        // GET: Movies
        public async Task<IActionResult> Index()
        {
            return View(await _context.Movies.ToListAsync());
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieResponse = await _context.Movies
                .FirstOrDefaultAsync(m => m.MovieId == id);
            if (movieResponse == null)
            {
                return NotFound();
            }

            return View(movieResponse);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MovieId,Category,Title,StartYear,DirectorName,Rating,Edit,LentTo,Notes")] MovieResponse movieResponse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movieResponse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movieResponse);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieResponse = await _context.Movies.FindAsync(id);
            if (movieResponse == null)
            {
                return NotFound();
            }
            return View(movieResponse);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MovieId,Category,Title,StartYear,DirectorName,Rating,Edit,LentTo,Notes")] MovieResponse movieResponse)
        {
            if (id != movieResponse.MovieId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movieResponse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieResponseExists(movieResponse.MovieId))
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
            return View(movieResponse);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieResponse = await _context.Movies
                .FirstOrDefaultAsync(m => m.MovieId == id);
            if (movieResponse == null)
            {
                return NotFound();
            }

            return View(movieResponse);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movieResponse = await _context.Movies.FindAsync(id);
            _context.Movies.Remove(movieResponse);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieResponseExists(int id)
        {
            return _context.Movies.Any(e => e.MovieId == id);
        }
    }
}
