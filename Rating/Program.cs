using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Rating.Data;
using Rating.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<RatingContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RatingContext") ?? throw new InvalidOperationException("Connection string 'RatingContext' not found.")));
builder.Services.AddScoped<IRatingService, RatingService>();
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Feedbacks}/{action=Index}/{id?}");

app.Run();
