using SchoolManagement.Domain;
using SchoolManagement.Infrastructure.UnitOfWork;

namespace SchoolManagement.Web.Modules
{
    public static class ServiceModule
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ISchoolManagementUnitOfWork, SchoolManagemntUnitOfWork>();
        }
    }
}
