using KD12MVCHamburger.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//Default : İçerisine verdiğin Proplar yeterli oluyor.
//DataAnnotation ile yapabilirsin.
//FluentAPI ile yapılması!!

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<HamburgerDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("HamburgerConnectionString"));
});
//DbContext!!
//CodeFirst // DbContext --> SQLServer Bağlantısını
var app = builder.Build();

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
