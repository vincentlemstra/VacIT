using Microsoft.EntityFrameworkCore;
using VacIT.Data;
using VacIT.Data.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<VacITContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("VacITContext") ?? throw new InvalidOperationException("Connection string 'VacITContext' not found.")));

// Services configuration
builder.Services.AddScoped<IJobListingsService, JobListingsService>();
builder.Services.AddScoped<IProfilesService, ProfilesService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=JobListings}/{action=Index}/{id?}");

app.Run();