namespace POISchedule.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using POISchedule.Data;
    using POISchedule.Data.Entities;
    using System.Linq;
    using System.Threading.Tasks;

    public class ClassroomTypesController : Controller
    {
        private readonly DataContext context;

        public ClassroomTypesController(DataContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await context.ClassroomTypes.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activity = await this.context.ClassroomTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (activity == null)
            {
                return NotFound();
            }

            return View(activity);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClassroomType classroomType)
        {
            if (ModelState.IsValid)
            {
                this.context.Add(classroomType);
                await this.context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(classroomType);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classroomType = await this.context.ClassroomTypes.FindAsync(id);
            if (classroomType == null)
            {
                return NotFound();
            }
            return View(classroomType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ClassroomType classroomType)
        {
            if (id != classroomType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    this.context.Update(classroomType);
                    await this.context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassroomTypeExists(classroomType.Id))
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
            return View(classroomType);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classroomType = await this.context.ClassroomTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (classroomType == null)
            {
                return NotFound();
            }

            return View(classroomType);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var classroomType = await this.context.ClassroomTypes.FindAsync(id);
            this.context.ClassroomTypes.Remove(classroomType);
            await this.context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassroomTypeExists(int id)
        {
            return this.context.ClassroomTypes.Any(e => e.Id == id);
        }


    }
}
