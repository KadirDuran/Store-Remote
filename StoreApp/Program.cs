using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.Models;
using Repositories;
using Services.Contracts;
using Services;
using Entities.Models;
using StoreApp.Pages;
using StoreApp.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddDbContext<RepositoryContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("sqlConntection")));

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.Cookie.Name = "StoreApp.Session";
    options.IdleTimeout = TimeSpan.FromMinutes(10);
});
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IServiceManager, ServiceManager>();
builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<Cart>(c => SessionCart.GetCart(c));
var app = builder.Build();
app.UseHttpsRedirection();
app.UseRouting();
app.UseStaticFiles();
app.UseSession();
app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(name:"Admin",
        areaName:"Admin",
        pattern: "Admin/{Controller=Dashboard}/{action=Index}/{id?}"
        );
    endpoints.MapControllerRoute(name: "default",
    pattern: "{Controller=Home}/{action=Index}/{id?}");

    endpoints.MapRazorPages();
});

app.Run();
