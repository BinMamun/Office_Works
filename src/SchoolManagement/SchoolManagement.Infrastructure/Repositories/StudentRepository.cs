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
            return await GetByIdAsync(studentId, "sp_GetStudentById");
        }

        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            return await GetAllAsync("sp_GetAllStudents");
        }

        public async Task AddStudent(Student student)
        {
            await AddAsync(student, "sp_AddStudent");
        }
        public async Task UpdateStudent(Student student)
        {
            await UpdateAsync(student, "sp_UpdateStudent");
        }
        public async Task DeleteStudent(Guid studentId)
        {
            await DeleteAsync(studentId, "sp_DeleteStudent");
        }
    }
}
