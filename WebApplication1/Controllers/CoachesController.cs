using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    public class CoachesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CoachesController(ApplicationDbContext context)
        {
            _context = context;

        }


        [Authorize(Policy = "Member")]
        // GET: Coaches

        public async Task<IActionResult> Index()
        {
            return View(await _context.Coach.ToListAsync());

        }

        // GET: Coaches/Details/5
        public async Task<IActionResult> Details(string id)

        {
            if (id == null)
            {
                return NotFound();
            }

            var coach = await _context.Coach
                .FirstOrDefaultAsync(m => m.Email == id);


            if (coach == null)
            {
                return NotFound();
            }
            
            return View(coach);
        }

        // GET: Coaches/Details/MyProfile
        //public async Task<IActionResult> Details(string email)

        //{
        //    if (email == null)
        //    {
        //        return NotFound();
        //    }

        //    var coach = await _context.Coach
        //        .FirstOrDefaultAsync(m => m.Email == email);


        //    if (coach == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(coach);
        //}



        [Authorize(Policy = "Coach")]
        // GET: Coaches/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Coaches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Email,Biography,PhotoUrl")] Coach coach)
        {
            if (ModelState.IsValid)
            {
                _context.Add(coach);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(coach);
        }

        [Authorize(Policy = "Coach")]
        // GET: Coaches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coach = await _context.Coach.FindAsync(id);
            if (coach == null)
            {
                return NotFound();
            }
            return View(coach);
            }

        // POST: Coaches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Email,Biography,PhotoUrl")] Coach coach)
        {
            if (id != coach.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coach);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoachExists(coach.Id))
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
            return View(coach);
        }

        [Authorize(Policy = "Coach")]

        // GET: Coaches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coach = await _context.Coach
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coach == null)
            {
                return NotFound();
            }

            return View(coach);
        }
        [Authorize(Policy = "Coach")]
        // POST: Coaches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var coach = await _context.Coach.FindAsync(id);
            _context.Coach.Remove(coach);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CoachExists(int id)
        {
            return _context.Coach.Any(e => e.Id == id);
        }
    }
}
