using SchoolManagement.Web.Modules;
using Serilog;


#region Bootstrap Logger
var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(config)
    .CreateBootstrapLogger();
#endregion


try
{
    Log.Information("Starting up the application...");

    var builder = WebApplication.CreateBuilder(args);

    #region Serilog integration for Application logs

    builder.Host.UseSerilog((services, ls) => ls
                .Enrich.FromLogContext()
                .ReadFrom.Configuration(builder.Configuration));

    #endregion

    #region Register IServiceCollection services for DI
    builder.Services.RegisterServices();
    #endregion

    // Add services to the container.
    builder.Services.AddControllersWithViews();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseRouting();

    app.UseAuthorization();

    app.MapStaticAssets();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
        .WithStaticAssets();

    Log.Information("Application started...");
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Fatal Error: Application start-up failed");
}
finally
{
    Log.CloseAndFlush();
}


