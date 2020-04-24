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

        private bool ClassroomTypeExists(int id)
        {
            return this.context.ClassroomTypes.Any(e => e.Id == id);
        }


    }
}
