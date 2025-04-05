using Microsoft.Extensions.Configuration;
using SchoolManagement.Domain;

namespace SchoolManagement.Infrastructure.UnitOfWork
{
    public class SchoolManagemntUnitOfWork : UnitOfWork, ISchoolManagementUnitOfWork
    {
        public SchoolManagemntUnitOfWork(IConfiguration configuration) : base(configuration)
        {
        }
        // Add your repository properties here
        // Example:
        // public IStudentRepository StudentRepository => GetRepository<IStudentRepository>();
        // public ICourseRepository CourseRepository => GetRepository<ICourseRepository>();
        // public IEnrollmentRepository EnrollmentRepository => GetRepository<IEnrollmentRepository>();
    }
}
