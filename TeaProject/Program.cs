using Microsoft.EntityFrameworkCore;
using TeaProject.DataAccess.Data;
using TeaProject.DataAccess.Repository;
using TeaProject.DataAccess.Repository.IRepositity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using TeaProject.Models;
using Microsoft.AspNetCore.Identity.UI.Services;
using TeaProject.Utility;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<TeaProject0504Context>
	(options => options.UseSqlServer(builder.Configuration.GetConnectionString("TeaProject0504DBContext")));

builder.Services.AddIdentity<IdentityUser,IdentityRole>
	(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<TeaProject0504Context>().AddDefaultTokenProviders();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddRazorPages();

builder.Services.ConfigureApplicationCookie(options =>
 {
  
     options.LoginPath = "/Identity/Account/Login";
     options.LogoutPath = "/Identity/Account/Logout";
     options.AccessDeniedPath = "/Identity/Account/AccessDenied";
 });
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

app.UseAuthentication();  //在授權之前添加身分驗證
app.UseAuthorization();

app.MapRazorPages();  //啟用Razor 
app.MapControllerRoute(
	name: "default",
	pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

app.Run();
