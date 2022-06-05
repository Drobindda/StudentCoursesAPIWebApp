using StudentCoursesAPIWebApp.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<StudentCoursesAPIContext>(option => option.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseEndpoints(endpoint =>
{
    endpoint.MapControllers();
});


app.MapGet("/", () => "Hello World!");

app.Run();
