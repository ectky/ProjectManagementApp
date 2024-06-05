using System.Configuration;
using EntityFrameworkCore.UseRowNumberForPaging;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using NuGet.Configuration;
using ProjectManagament.Services;
using ProjectManagement.Data;
using ProjectManagement.Data.Repos;
using ProjectManagement.Shared.Services.Contracts;
using ProjectManagementMVC;
using ProjectManagement.Shared.Extensions;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(m => m.AddProfile(new AutoMapperConfiguration()));
builder.Services.AutoBind(typeof(ProjectsService).Assembly);
builder.Services.AutoBind(typeof(ProjectRepository).Assembly);

// TODO   add more 


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie();


builder.Services.AddDbContext<ProjectManagementDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"], i => i.UseRowNumberForPaging());
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ProjectManagementDbContext>();
    // Automatically update database
    context.Database.Migrate();
}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
