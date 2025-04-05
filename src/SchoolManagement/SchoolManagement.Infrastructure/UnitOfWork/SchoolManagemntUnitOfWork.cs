using Microsoft.Extensions.Configuration;
using SchoolManagement.Domain;
using SchoolManagement.Domain.RepositoryContracts;

namespace SchoolManagement.Infrastructure.UnitOfWork
{
    public class SchoolManagemntUnitOfWork : UnitOfWork, ISchoolManagementUnitOfWork
    {
        public SchoolManagemntUnitOfWork(
            IConfiguration configuration,
            IStudentRepository studentRepository
            ) : base(configuration)
        {
            StudentRepository = studentRepository;
        }

        public IStudentRepository StudentRepository { get; private set; }
    }
}
