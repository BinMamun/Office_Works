using Microsoft.AspNetCore.Mvc;
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
    }
}
