using Microsoft.EntityFrameworkCore;
using TeaProject.DataAccess.Data;
using TeaProject.DataAccess.Repository;
using TeaProject.DataAccess.Repository.IRepositity;

using TeaProject.DataAccess.Repository;
using Microsoft.AspNetCore.Identity;
using TeaProject.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<TeaProject0504Context>
	(options => options.UseSqlServer(builder.Configuration.GetConnectionString("TeaProject0504DBContext")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<TeaProject0504Context>();

//�NRepository�g�i�M�� ���U�̿�`�J�������A��

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


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
