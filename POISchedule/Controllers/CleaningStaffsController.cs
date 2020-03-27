using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using POISchedule.Data;
using POISchedule.Data.Entities;

namespace POISchedule.Controllers
{
    public class CleaningStaffsController : Controller
    {
        private readonly DataContext _context;

        public CleaningStaffsController(DataContext context)
        {
            _context = context;
        }

        // GET: CleaningStaffs
        public async Task<IActionResult> Index()
        {
            return View(await _context.CleaningStaffs.ToListAsync());
        }

        // GET: CleaningStaffs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cleaningStaff = await _context.CleaningStaffs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cleaningStaff == null)
            {
                return NotFound();
            }

            return View(cleaningStaff);
        }

        // GET: CleaningStaffs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CleaningStaffs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,ImageUrl")] CleaningStaff cleaningStaff)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cleaningStaff);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cleaningStaff);
        }

        // GET: CleaningStaffs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cleaningStaff = await _context.CleaningStaffs.FindAsync(id);
            if (cleaningStaff == null)
            {
                return NotFound();
            }
            return View(cleaningStaff);
        }

        // POST: CleaningStaffs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,ImageUrl")] CleaningStaff cleaningStaff)
        {
            if (id != cleaningStaff.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cleaningStaff);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CleaningStaffExists(cleaningStaff.Id))
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
            return View(cleaningStaff);
        }

        // GET: CleaningStaffs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cleaningStaff = await _context.CleaningStaffs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cleaningStaff == null)
            {
                return NotFound();
            }

            return View(cleaningStaff);
        }

        // POST: CleaningStaffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cleaningStaff = await _context.CleaningStaffs.FindAsync(id);
            _context.CleaningStaffs.Remove(cleaningStaff);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CleaningStaffExists(int id)
        {
            return _context.CleaningStaffs.Any(e => e.Id == id);
        }
    }
}
