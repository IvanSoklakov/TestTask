using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NLog.Web;
using TestTaskApi.BLL.Infrastructure;
using TestTaskApi.BLL.Services;
using TestTaskApi.BLL.Services.Interfaces;
using TestTaskApi.DAL.EF;
using TestTaskApi.DAL.Interfaces;
using TestTaskApi.DAL.Repositories;

var logger = NLogBuilder.ConfigureNLog("nLog.config").GetCurrentClassLogger();

try
{
    #region ConfigureServices
    var builder = WebApplication.CreateBuilder(args);
    var connection = builder.Configuration.GetConnectionString("DefaultConnection");  

    builder.Services.AddDbContext<TestTaskContext>(options => options.UseNpgsql(connection));
    builder.Services.AddControllers();
    builder.Services.AddAutoMapper(typeof(MappingProfile));
    builder.Services.AddEndpointsApiExplorer();

    #region Logging
    builder.Logging.ClearProviders();
    builder.Logging.SetMinimumLevel(LogLevel.Warning);
    builder.Host.UseNLog();
    #endregion

    builder.Services.AddSwaggerGen(options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "TestTaskApi",
            Description = "API for interaction with the Test Task",
        });
    });
    builder.Services.AddScoped<ITestTaskUnitOfWork, TestTaskUnitOfWork>();
    builder.Services.AddTransient<ITestTaskServices, TestTaskServices>();
    #endregion

    #region Configure
    var app = builder.Build();


    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseDefaultFiles();
    app.UseStaticFiles();
    app.UseHttpsRedirection();
    app.UseRouting();  
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
    #endregion
}
catch (Exception exception)
{
    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{
    NLog.LogManager.Shutdown();
}

