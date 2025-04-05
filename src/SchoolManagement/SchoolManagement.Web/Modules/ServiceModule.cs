using SchoolManagement.Domain;
using SchoolManagement.Domain.RepositoryContracts;
using SchoolManagement.Infrastructure.Repositories;
using SchoolManagement.Infrastructure.UnitOfWork;

namespace SchoolManagement.Web.Modules
{
    public static class ServiceModule
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ISchoolManagementUnitOfWork, SchoolManagemntUnitOfWork>();

            services.AddScoped<IStudentRepository, StudentRepository>();
        }
    }
}
