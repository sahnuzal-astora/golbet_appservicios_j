using GolBet.Repositories.Data;
using GolBet.Repositories.Implementations; 
using GolBet.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using GolBet.Services.Implementations;

using GolBet.Services.Interfaces;

using GolBet.Services.Mapping;
var builder = WebApplication.CreateBuilder(args);

// 1. Agregar servicios al contenedor
builder.Services.AddControllersWithViews();

// Registramos el DbContext ANTES de construir la app (builder.Build)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Open generic registration: one line, a repository for every entity 

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));



// Specific repositories 

builder.Services.AddScoped<IMatchRepository, MatchRepository>();
// AutoMapper: scans the assembly containing MappingProfile for all profiles 

builder.Services.AddAutoMapper(typeof(MappingProfile));



// Business services 

builder.Services.AddScoped<IMatchService, MatchService>();
// 2. Construir la aplicación
var app = builder.Build();


// Seed the database on startup 

using (var scope = app.Services.CreateScope())

{

    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    await DbSeeder.SeedAsync(context);

}

// 3. Configurar el pipeline de peticiones HTTP
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