using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using VacIT.Data;
using VacIT.Data.Services;
using VacIT.Extensions;
using Microsoft.AspNetCore.HttpOverrides;
using System.Text.Json.Serialization;
using NLog;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<VacITContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("VacITContext") ?? throw new InvalidOperationException("Connection string 'VacITContext' not found.")));

LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/Logger/nlog.config"));

// Services configuration
builder.Services.AddScoped<IJobListingsService, JobListingsService>();
builder.Services.AddScoped<IProfilesService, ProfilesService>();
builder.Services.AddScoped<IEmployersService, EmployersService>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.ConfigureLoggerService();

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
    options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
        options.SlidingExpiration = true;
        options.AccessDeniedPath = "/Forbidden/";
    });

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    VacITDbInitializer.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});

app.UseCors("CorsPolicy");

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=JobListings}/{action=Index}/{id?}");

app.Run();