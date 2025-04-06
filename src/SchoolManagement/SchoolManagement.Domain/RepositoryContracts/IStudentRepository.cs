using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Domain.RepositoryContracts
{
    public interface IStudentRepository : IRepository<Student, Guid>
    {
    }
}
