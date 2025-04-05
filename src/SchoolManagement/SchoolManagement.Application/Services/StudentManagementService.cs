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
            return await _schoolManagementUnitOfWork.StudentRepository.GetByIdAsync(id);
        }
        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await _schoolManagementUnitOfWork.StudentRepository.GetAllAsync();
        }
        public async Task AddStudentAsync(Student student)
        {
            await _schoolManagementUnitOfWork.StudentRepository.AddAsync(student);
            await _schoolManagementUnitOfWork.CommitAsync();
        }
        public async Task UpdateStudentAsync(Student student)
        {
            await _schoolManagementUnitOfWork.StudentRepository.UpdateAsync(student);
            await _schoolManagementUnitOfWork.CommitAsync();
        }
        public async Task DeleteStudentAsync(int id)
        {
            await _schoolManagementUnitOfWork.StudentRepository.DeleteAsync(id);
            await _schoolManagementUnitOfWork.CommitAsync();
        }
    }
}
