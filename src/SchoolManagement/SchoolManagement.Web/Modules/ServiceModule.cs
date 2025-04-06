using SchoolManagement.Application.Services;
using SchoolManagement.Domain.RepositoryContracts;
using SchoolManagement.Domain.ServiceContracts;
using SchoolManagement.Infrastructure.Repositories;

namespace SchoolManagement.Web.Modules
{
    public static class ServiceModule
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IStudentManagementService, StudentManagementService>();
        }
    }
}
