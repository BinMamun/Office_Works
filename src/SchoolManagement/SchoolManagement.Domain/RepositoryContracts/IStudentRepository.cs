using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Domain.RepositoryContracts
{
    public interface IStudentRepository : IRepository<Student, Guid>
    {
        Task<Student> GetStudentById(Guid studentId);
        Task<IEnumerable<Student>> GetAllStudents();
        Task AddStudent(Student student);
        Task UpdateStudent(Student student);
        Task DeleteStudent(Guid studentId);
    }
}
