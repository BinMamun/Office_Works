using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Domain.ServiceContracts
{
    public interface IStudentManagementService
    {
        Task<Student> GetStudentByIdAsync(Guid id);
        Task<IEnumerable<Student>> GetAllStudentsAsync();
        Task AddStudentAsync(Student student);
        Task UpdateStudentAsync(Student student);
        Task DeleteStudentAsync(Guid id);
    }
}
