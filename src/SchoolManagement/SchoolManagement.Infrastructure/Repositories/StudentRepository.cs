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

        public async Task<Student> GetStudentById(Guid studentId)
        {
            return await GetByIdAsync(studentId);
        }

        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            return await GetAllAsync();
        }

        public async Task AddStudent(Student student)
        {
            await AddAsync(student);
        }
        public async Task UpdateStudent(Student student)
        {
            await UpdateAsync(student);
        }
        public async Task DeleteStudent(Guid studentId)
        {
            await DeleteAsync(studentId);
        }
    }
}
