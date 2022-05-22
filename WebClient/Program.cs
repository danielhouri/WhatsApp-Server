using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebClient.Data;
using WebClient.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<WebClientContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WebClientContext") ?? throw new InvalidOperationException("Connection string 'WebClientContext' not found.")));

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
