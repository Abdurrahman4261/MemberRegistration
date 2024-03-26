using FluentValidation.AspNetCore;
using MemberRegistration.BusinessLayer.FluentValidation.ValidationRules;
using MemberRegistration.DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSession();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddControllersWithViews().AddFluentValidation
    (x=>x.RegisterValidatorsFromAssemblyContaining<UserValidator>());

builder.Services.AddDbContext<MemberContext>
    (options =>options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnect")) );

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
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Index}/{id?}");

app.Run();
