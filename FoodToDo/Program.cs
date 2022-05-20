using FoodToDo.Core;
using FoodToDo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();


var connectionString = builder.Configuration.GetConnectionString("FoodToDoConnectionString");

builder.Services.AddDbContextPool<FoodToDoDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

// for aspnetcore3.0+
builder.Services.AddControllers();

builder.Services.AddScoped<IRestorantData, SqlRestorantData>();

builder.Services.AddLogging();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}


app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(e =>
{
    e.MapRazorPages();
    e.MapControllers();
});

app.MapRazorPages();

app.UseStaticFiles();

app.UseCookiePolicy();

app.Run();
