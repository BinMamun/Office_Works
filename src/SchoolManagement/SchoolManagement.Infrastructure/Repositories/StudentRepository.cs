using SchoolManagement.Domain;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.RepositoryContracts;

namespace SchoolManagement.Infrastructure.Repositories
{
    public class StudentRepository : Repository<Student, Guid>, IStudentRepository
    {
        public StudentRepository(ISqlUtility sqlUtility) : base(sqlUtility)
        {
        }
    }
}
