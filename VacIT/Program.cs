using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VacIT.Data;
using VacIT.Data.Services;
using VacIT.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<VacITContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("VacITContext") ?? throw new InvalidOperationException("Connection string 'VacITContext' not found.")));

// Services configuration
builder.Services.AddScoped<IJobListingsService, JobListingsService>();
builder.Services.AddScoped<IProfilesService, ProfilesService>();
builder.Services.AddScoped<IEmployersService, EmployersService>();

// Authentication and authorization
builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<VacITContext>();
builder.Services.AddMemoryCache();
builder.Services.AddSession();
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
});

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    VacITDbInitializer.Initialize(services);
    //VacITDbInitializer.InitializeUsersAndRolesAsync(services).Wait();
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
app.UseSession();

// Authentication & Authorization
app.UseAuthentication();
app.UseAuthorization();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=JobListings}/{action=Index}/{id?}");

app.Run();