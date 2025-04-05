using SchoolManagement.Domain;

namespace SchoolManagement.Application
{
    public interface ISchoolManagementUnitOfWork : IUnitOfWork
    {
        // Add your repository properties here
        // Example:
        // IStudentRepository StudentRepository { get; }
        // ICourseRepository CourseRepository { get; }
        // IEnrollmentRepository EnrollmentRepository { get; }
        // Add any additional methods specific to the School Management context here
    }
}
