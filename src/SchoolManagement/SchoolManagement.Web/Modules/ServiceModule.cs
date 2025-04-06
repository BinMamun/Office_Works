using SchoolManagement.Application.Services;
using SchoolManagement.Domain;
using SchoolManagement.Domain.RepositoryContracts;
using SchoolManagement.Domain.ServiceContracts;
using SchoolManagement.Infrastructure.Repositories;
using SchoolManagement.Infrastructure.Utilities;

namespace SchoolManagement.Web.Modules
{
    public static class ServiceModule
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ISqlUtility, SqlUtility>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IStudentManagementService, StudentManagementService>();
        }
    }
}
