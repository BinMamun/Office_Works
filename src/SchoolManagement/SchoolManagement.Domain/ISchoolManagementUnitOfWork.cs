using SchoolManagement.Domain.RepositoryContracts;

namespace SchoolManagement.Domain
{
    public interface ISchoolManagementUnitOfWork : IUnitOfWork
    {
        IStudentRepository StudentRepository { get; }
    }
}
