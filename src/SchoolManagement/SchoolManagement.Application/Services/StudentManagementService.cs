using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.RepositoryContracts;
using SchoolManagement.Domain.ServiceContracts;

namespace SchoolManagement.Application.Services
{
    public class StudentManagementService : IStudentManagementService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentManagementService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<Student> GetStudentByIdAsync(Guid id)
        {
            return await _studentRepository.GetByIdAsync(id, "sp_GetStudentById");
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await _studentRepository.GetAllAsync("sp_GetAllStudents");
        }

        public async Task AddStudentAsync(Student student)
        {
            await _studentRepository.AddAsync(student, "sp_AddStudent");
        }

        public async Task UpdateStudentAsync(Student student)
        {
            await _studentRepository.UpdateAsync(student, "sp_UpdateStudent");
        }

        public async Task DeleteStudentAsync(Guid id)
        {
            await _studentRepository.DeleteAsync(id, "sp_DeleteStudent");
        }
    }
}
