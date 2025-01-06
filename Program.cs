using Microsoft.EntityFrameworkCore;
using ProjetCsharpWebS5.Data;
using ProjetCsharpWebS5.Fixtures;
using ProjetCsharpWebS5.Services;
using ProjetCsharpWebS5.Services.impl;

var builder = WebApplication.CreateBuilder(args);

string connectionString=builder.Configuration.GetConnectionString("MySQLConnection")!;

builder.Services.AddDbContext<ApplicationDbContext>(options =>

            options.UseLazyLoadingProxies().
                UseMySql(connectionString, 
                new MySqlServerVersion(new Version(10, 4, 32))))
                ;


builder.Services.AddScoped<IProduitService, ProduitService>();
builder.Services.AddScoped<IDetailService, DetailService>();
builder.Services.AddScoped<ICommandeService, CommandeService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<ClientFixtures>();

builder.Services.AddDistributedMemoryCache(); // Cache en mémoire pour la session
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Durée de vie de la session
    options.Cookie.HttpOnly = true; // Sécuriser les cookies
    options.Cookie.IsEssential = true; // Marquer les cookies comme essentiels pour l'application
});

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseSession(); // Ajoute le middleware de session avant le middleware MVC
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Authentification}/{action=Login}");


// Load Fixtures
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    var seeder = scope.ServiceProvider.GetRequiredService<ClientFixtures>();
    seeder.Load();
}
app.Run();
