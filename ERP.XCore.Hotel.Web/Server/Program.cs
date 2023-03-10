using ERP.XCore.Data.Context;
using ERP.XCore.Entities.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ERP.XCore.Core.Helpers;
using ERP.XCore.Data.Seeder;

var builder = WebApplication.CreateBuilder(args);

 // Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services
    .AddDbContext<ApplicationDbContext>(options => options
        .UseSqlServer(connectionString));

builder.Services
    .AddDatabaseDeveloperPageExceptionFilter();

builder.Services
    .AddIdentity<ApplicationUser, ApplicationRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultUI();

builder.Services
    .AddIdentityServer()
    .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

builder.Services
    .AddAuthentication()
    .AddIdentityServerJwt();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();


var app = builder.Build();


if (Constants.Seed.ENABLED)
{
    var dbContext = builder.Services.BuildServiceProvider().CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();
    var usManager = builder.Services.BuildServiceProvider().CreateScope().ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    var rlManager = builder.Services.BuildServiceProvider().CreateScope().ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
    DbSeeder.Seed(dbContext, usManager, rlManager);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseIdentityServer();
app.UseAuthentication();
app.UseAuthorization();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
