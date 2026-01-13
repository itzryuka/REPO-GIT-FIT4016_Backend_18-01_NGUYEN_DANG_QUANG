using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace SchoolManagement
{
    public class StudentsController : Controller
    {
        private readonly SchoolDbContext _context;

        public StudentsController(SchoolDbContext context)
        {
            _context = context;
        }

        // Load schools into dropdown
        private async Task LoadSchoolsAsync(int? selectedId = null)
        {
            var schools = await _context.Schools
                .OrderBy(s => s.Name)
                .ToListAsync();
            ViewBag.Schools = new SelectList(schools, "Id", "Name", selectedId);
        }

        // ===== CREATE =====

        // GET: Students/Create
        public async Task<IActionResult> Create()
        {
            await LoadSchoolsAsync();
            return View();
        }

        // POST: Students/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student student)
        {
            await LoadSchoolsAsync(student.SchoolId);

            // DataAnnotation validation
            if (!ModelState.IsValid)
                return View(student);

            // Unique StudentId
            if (await _context.Students.AnyAsync(s => s.StudentId == student.StudentId))
                ModelState.AddModelError("StudentId", "Student ID already exists.");

            // Unique Email
            if (await _context.Students.AnyAsync(s => s.Email == student.Email))
                ModelState.AddModelError("Email", "Email already exists.");

            // School must exist
            if (!await _context.Schools.AnyAsync(s => s.Id == student.SchoolId))
                ModelState.AddModelError("SchoolId", "Selected school does not exist.");

            if (!ModelState.IsValid)
                return View(student);

            try
            {
                student.CreatedAt = DateTime.UtcNow;
                student.UpdatedAt = DateTime.UtcNow;

                _context.Add(student);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Student created successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "An error occurred while creating the student.");
                return View(student);
            }
        }

        // ===== EDIT =====

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var student = await _context.Students.FindAsync(id);
            if (student == null) return NotFound();

            await LoadSchoolsAsync(student.SchoolId);
            return View(student);
        }

        // POST: Students/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Student student)
        {
            if (id != student.Id) return NotFound();

            await LoadSchoolsAsync(student.SchoolId);

            if (!ModelState.IsValid)
                return View(student);

            // Unique StudentId (ignore current id)
            if (await _context.Students.AnyAsync(s => s.StudentId == student.StudentId && s.Id != id))
                ModelState.AddModelError("StudentId", "Student ID already exists.");

            // Unique Email (ignore current id)
            if (await _context.Students.AnyAsync(s => s.Email == student.Email && s.Id != id))
                ModelState.AddModelError("Email", "Email already exists.");

            // School must exist
            if (!await _context.Schools.AnyAsync(s => s.Id == student.SchoolId))
                ModelState.AddModelError("SchoolId", "Selected school does not exist.");

            if (!ModelState.IsValid)
                return View(student);

            try
            {
                student.UpdatedAt = DateTime.UtcNow;
                _context.Update(student);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Student updated successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Students.Any(e => e.Id == student.Id))
                    return NotFound();
                throw;
            }
            catch
            {
                ModelState.AddModelError("", "An error occurred while updating the student.");
                return View(student);
            }
        }

        // Index, Delete… bạn đã có hoặc scaffold thêm
    }
}
