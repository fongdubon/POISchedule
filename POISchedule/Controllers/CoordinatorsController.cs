namespace POISchedule.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using POISchedule.Data;
    using POISchedule.Data.Entities;
    using POISchedule.Helpers;
    using POISchedule.Models;
    using System.Linq;
    using System.Threading.Tasks;


    //[Authorize(Roles = "Lender")]
    public class CoordinatorsController : Controller
    {
        private readonly DataContext _context;
        private readonly IImageHelper _imageHelper;

        public CoordinatorsController(DataContext context,
            IImageHelper imageHelper)
        {
            _context = context;
            _imageHelper = imageHelper;
        }

        // GET: Coordinators
        public async Task<IActionResult> Index()
        {
            return View(await _context.Coordinators.ToListAsync());
        }

        // GET: Coordinators/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coordinator = await _context.Coordinators
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coordinator == null)
            {
                return NotFound();
            }

            return View(coordinator);
        }

        // GET: Coordinators/Create
        public IActionResult Create()
        {
            var model = new CoordinatorViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CoordinatorViewModel model)
        {
            if (ModelState.IsValid)
            {
                var coordinator = new Coordinator
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName

                };
                if (model.ImageFile != null)
                {
                    coordinator.ImageUrl = await _imageHelper.UploadImageAsync(model.ImageFile, model.FullName, "Coordinator");
                }
                _context.Add(coordinator);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Coordinators/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coordinator = await _context.Coordinators.FindAsync(id);
            if (coordinator == null)
            {
                return NotFound();
            }
            var model = new CoordinatorViewModel
            {
                Id = coordinator.Id,
                FirstName = coordinator.FirstName,
                LastName = coordinator.LastName,
                ImageUrl = coordinator.ImageUrl
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CoordinatorViewModel model)
        {
            if (ModelState.IsValid)
            {
                var coordinator = await _context.Coordinators.FindAsync(model.Id);
                if (coordinator == null)
                {
                    return NotFound();
                }

                coordinator.FirstName = model.FirstName;
                coordinator.LastName = model.LastName;
                if (model.ImageFile != null)
                {
                    coordinator.ImageUrl = await _imageHelper.UploadImageAsync(model.ImageFile, model.FullName, "Coordinator");
                }
                _context.Update(coordinator);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Coordinators/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coordinator = await _context.Coordinators
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coordinator == null)
            {
                return NotFound();
            }

            return View(coordinator);
        }

        // POST: Coordinators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var coordinator = await _context.Coordinators.FindAsync(id);
            _context.Coordinators.Remove(coordinator);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CoordinatorExists(int id)
        {
            return _context.Coordinators.Any(e => e.Id == id);
        }
    }
}
