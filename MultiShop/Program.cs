using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using MultiShop.DAL;
using MultiShop.Utilities;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"))) ;

builder.Services.AddScoppedRegister();
builder.Services.AddSession();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie();
var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
app.UseSession();


app.UseRouting();
app.UseStaticFiles();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});
app.MapControllerRoute("default", "{controller=home}/{action=index}/{id?}");

app.Run();
