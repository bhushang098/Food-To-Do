using FoodToDo.Core;
using FoodToDo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<FoodToDoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FoodToDoContext") ?? throw new InvalidOperationException("Connection string 'FoodToDoContext' not found.")));



var connectionString = builder.Configuration.GetConnectionString("FoodToDoConnectionString");

builder.Services.AddDbContextPool<FoodToDoDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Services.AddScoped<IRestorantData, SqlRestorantData>();

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

app.UseAuthorization();

app.MapRazorPages();

app.Run();
