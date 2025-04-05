using SchoolManagement.Domain;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.ServiceContracts;

namespace SchoolManagement.Application.Services
{
    public class StudentManagementService : IStudentManagementService
    {
        private readonly ISchoolManagementUnitOfWork _schoolManagementUnitOfWork;
        
        public StudentManagementService(ISchoolManagementUnitOfWork schoolManagementUnitOfWork)
        {
            _schoolManagementUnitOfWork = schoolManagementUnitOfWork;
        }
        public async Task<Student> GetStudentByIdAsync(Guid id)
        {
            return await _schoolManagementUnitOfWork.StudentRepository.GetStudentById(id);
        }
        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await _schoolManagementUnitOfWork.StudentRepository.GetAllStudents();
        }
        public async Task AddStudentAsync(Student student)
        {
            await _schoolManagementUnitOfWork.StudentRepository.AddStudent(student);
            await _schoolManagementUnitOfWork.CommitAsync();
        }
        public async Task UpdateStudentAsync(Student student)
        {
            await _schoolManagementUnitOfWork.StudentRepository.UpdateStudent(student);
            await _schoolManagementUnitOfWork.CommitAsync();
        }
        public async Task DeleteStudentAsync(Guid id)
        {
            await _schoolManagementUnitOfWork.StudentRepository.DeleteStudent(id);
            await _schoolManagementUnitOfWork.CommitAsync();
        }
    }
}
