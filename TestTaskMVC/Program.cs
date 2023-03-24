using Microsoft.EntityFrameworkCore;
using TestTaskApi.BLL.Infrastructure;
using TestTaskApi.DAL.EF;
using TestTaskApi.BLL.Services.Interfaces;
using TestTaskApi.BLL.Services;
using TestTaskApi.DAL.Interfaces;
using TestTaskApi.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddDbContext<TestTaskContext>(options => options.UseNpgsql("Host=localhost;Port=5432;Username=i.soklakov;Password=Wertvbnm3090;Database=TestTask"));
builder.Services.AddScoped<ITestTaskUnitOfWork, TestTaskUnitOfWork>();
builder.Services.AddTransient<ITestTaskServices, TestTaskServices>();




var app = builder.Build();

// Configure the HTTP request pipeline.

    //app.UseExceptionHandler("/Home/Error");
    //// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
