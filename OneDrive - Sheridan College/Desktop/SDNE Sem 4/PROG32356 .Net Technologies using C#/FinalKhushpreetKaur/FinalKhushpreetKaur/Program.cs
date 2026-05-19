using FinalKhushpreetKaur.Components;
using FinalKhushpreetKaur.Data;
using Microsoft.EntityFrameworkCore;
using FinalKhushpreetKaur.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var connStr= builder.Configuration.GetConnectionString("EmployeeConnection");
builder.Services.AddDbContext<EmployeeContext>(options =>
    options.UseSqlServer(connStr));

builder.Services.AddScoped<EmployeeService>(); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
