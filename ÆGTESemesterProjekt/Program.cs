using ÆGTESemesterProjekt.Models;
using ÆGTESemesterProjekt.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ÆGTESemesterProjekt.EFDbContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSingleton<UserService, UserService>();
builder.Services.AddSingleton<IProductService, ProductService>();
builder.Services.AddSingleton<IRepairService, RepairService>();
builder.Services.AddSingleton<OrderService, OrderService>();
builder.Services.AddSingleton<WishlistService, WishlistService>();
builder.Services.AddTransient<JsonFileService<Product>>();
builder.Services.AddTransient<JsonFileService<User>>();
builder.Services.AddTransient<JsonFileService<Employee>>();
builder.Services.AddTransient<JsonFileService<Customer>>();
builder.Services.AddTransient<JsonFileService<Repair>>();
builder.Services.AddTransient<JsonFileService<Wishlist>>();
builder.Services.AddDbContext<ProductDbContext>();
builder.Services.AddTransient<DbService>();
builder.Services.AddTransient<DbGenericService<Product>>();
builder.Services.AddTransient<DbGenericService<User>>();
builder.Services.AddTransient<DbGenericService<Order>>();
builder.Services.AddTransient<DbGenericService<Repair>>();
builder.Services.AddTransient<DbGenericService<Wishlist>>();
builder.Services.AddTransient<UserDbService, UserDbService>();


builder.Services.Configure<CookiePolicyOptions>(options => { 
	// This lambda determines whether user consent for non-essential cookies is needed for a given request.
options.CheckConsentNeeded = context => true; options.MinimumSameSitePolicy = SameSiteMode.None;  });  
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(cookieOptions => { cookieOptions.LoginPath = "/Login/LogInPage";  }); 
builder.Services.AddMvc().AddRazorPagesOptions(options => { options.Conventions.AuthorizeFolder("/Products/GetAllProducts");  }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
