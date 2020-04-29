using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POISchedule.Data;
using POISchedule.Data.Entities;
using POISchedule.Helpers;
using POISchedule.Models;


namespace POISchedule.Controllers
{
    public class CleaningStaffsController : Controller
    {
        private readonly DataContext _context;
        private readonly IImageHelper _imageHelper;

        public CleaningStaffsController(DataContext context, 
            IImageHelper imageHelper)
        {
            _context = context;
            _imageHelper = imageHelper;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.CleaningStaffs.ToListAsync());
        }

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

        public IActionResult Create()
        {
            var model = new CleaningStaffViewModel();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CleaningStaffViewModel model)
        {
            if (ModelState.IsValid)
            {
                var cleaningStaff = new CleaningStaff
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName
                };
                if(model.ImageFile != null)
                {
                    cleaningStaff.ImageUrl = await _imageHelper.UploadImageAsync(model.ImageFile, model.FullName, "CleaningStaff");
                };
                _context.Add(cleaningStaff);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

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
            var model = new CleaningStaffViewModel
            {
                Id = cleaningStaff.Id,
                FirstName = cleaningStaff.FirstName,
                LastName = cleaningStaff.LastName,
                ImageUrl = cleaningStaff.ImageUrl
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CleaningStaffViewModel model)
        {
            if (ModelState.IsValid)
            {
                var cleaningStaff = await _context.CleaningStaffs.FindAsync(model.Id);
                if (cleaningStaff == null)
                {
                    return NotFound();
                }

                cleaningStaff.FirstName = model.FirstName;
                cleaningStaff.LastName = model.LastName;
                if(model.ImageFile != null)
                {
                    cleaningStaff.ImageUrl = await _imageHelper.UploadImageAsync(model.ImageFile, model.FullName, "CleaningStaff");
                }
                _context.Update(cleaningStaff);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
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
