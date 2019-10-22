using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ScheduleMembersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IHttpContextAccessor _session;
        private int scheduleId;

        public ScheduleMembersController (ApplicationDbContext context, UserManager<IdentityUser> userManager, IHttpContextAccessor session)
        {
            _userManager = userManager;
            _context = context;
            _session = session;
        }


        // GET: Schedule Members

        public async Task<IActionResult> Index()
        {


            var schedulemembers = _context.ScheduleMembers
                .Where(c => c.ScheduleId == scheduleId);

            return View(await _context.ScheduleMembers.ToListAsync());


        }


        // GET: Details or (Schedule/5)
        public async Task<IActionResult> Details(string id)

        {
            if (id == null)
            {
                return NotFound();
            }

            var Schedule = await _context.Schedule.ToListAsync();

            //(m => m.MemberEmail == id)

            if (Schedule == null)
            {
                return View(Schedule);
            }

            return View(Schedule);

        }


        // GET: ScheduleMembers/Create
        public ActionResult Create()
        {
            return View();
        }



        // POST: ScheduleMembers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ScheduleMembers/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ScheduleMembers/Edit/5
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


        // GET: Items/Purchase

        //public async Task<IActionResult> Enrol()
        //{
        //    // get the schedule id
        //    var scheduleId = _session.HttpContext.Session.GetInt32("cartId");

        //    // get the schedule items
        //    var schedule = _context.ScheduleMembers
        //        .Where(c => c.ScheduleId == scheduleId);

        //    // get the member name
        //    var member = _userManager.GetUserName(User);

        //    // create the enrolment
        //    foreach (ScheduleMembers schedulemember in schedulemembers.ToList())
        //    {
        //        // find the item
        //        var item = await _context.ScheduleMembers
        //            .FirstOrDefaultAsync(m => m.ScheduleId == schedule.item);


        //        Sales sale = new Sales { Buyer = buyer, Item = cart.Item, Quantity = cart.Quantity };
        //        _db.Update(sale);
        //    }

        //    // Save the changes
        //    await _context.SaveChangesAsync();

        //    // delete cart
        //    _session.HttpContext.Session.SetString("cartId", "");
        //    _session.HttpContext.Session.SetInt32("cartCount", 0);

        //    return RedirectToAction(nameof(Index), "Items");
        //}




        // GET: ScheduleMembers/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ScheduleMembers/Delete/5
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