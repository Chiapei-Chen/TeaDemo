using Microsoft.EntityFrameworkCore;
using TeaProject.DataAccess.Data;
using TeaProject.DataAccess.Repository;
using TeaProject.DataAccess.Repository.IRepositity;

using TeaProject.DataAccess.Repository;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<TeaProject0504Context>
	(options => options.UseSqlServer(builder.Configuration.GetConnectionString("TeaProject0504DBContext")));
//將Repository寫進專案 註冊依賴注入的相關服務

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

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

app.Run();
