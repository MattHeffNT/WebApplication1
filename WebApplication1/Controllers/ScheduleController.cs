using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ScheduleController : Controller
    {
       
        private readonly ApplicationDbContext _context;

        public ScheduleController(ApplicationDbContext context)
        {
            _context = context;
            
        }


        // GET: Schedule

        public async Task<IActionResult> test()
        {

          //  return View(await _context.Schedule.ToListAsync());

            return View();

        }

        // GET: Details or (Schedule/5)
        public async Task<IActionResult> Index(int? id)

        {
            if (id == null)
            {
                return View();
            }

            var Schedule = await _context.Schedule
                .FirstOrDefaultAsync(m => m.Id == id);


            if (Schedule == null)
            {
                return View(Schedule);
            }

            return View(Schedule);

        }

        [Authorize(Policy = "Admin")]
        // GET: Schedule/Create
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Policy = "Admin")]
        // POST: Schedule/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,When,Description,Location")] Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                _context.Add(schedule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(schedule);
        }

        [Authorize(Policy = "Admin")]
        // GET: Schedule/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }
        [Authorize(Policy = "Admin")]
        // POST: Schedule/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [Authorize(Policy = "Admin")]

        // GET: Schedule/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        [Authorize(Policy = "Admin")]
        // POST: Schedule/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}