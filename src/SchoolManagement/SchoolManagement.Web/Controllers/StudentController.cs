using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.ServiceContracts;

namespace SchoolManagement.Web.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentManagementService _studentManagementService;

        public StudentController(IStudentManagementService studentManagementService)
        {
            _studentManagementService = studentManagementService;
        }

        public async Task<IActionResult> Index()
        {
            var students = await _studentManagementService.GetAllStudentsAsync();
            return View(students);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Student student)
        {
            if (ModelState.IsValid)
            {
                await _studentManagementService.AddStudentAsync(student);
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var student = await _studentManagementService.GetStudentByIdAsync(id);
            if (student == null) return NotFound();

            return View(student);
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                await _studentManagementService.UpdateStudentAsync(student);
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var student = await _studentManagementService.GetStudentByIdAsync(id);
            if (student == null) return NotFound();

            return View(student);
        }

        // POST: /Student/DeleteConfirmed
        [HttpPost, ValidateAntiForgeryToken, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _studentManagementService.DeleteStudentAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
