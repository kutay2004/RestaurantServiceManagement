using SengWeb.Client.Pages;
using SengWeb.Components;
using Microsoft.EntityFrameworkCore;
using SengWeb.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextFactory<SengWebContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SengWebContext")
        ?? throw new InvalidOperationException("Connection string 'SengWebContext' not found.")));

builder.Services.AddQuickGridEntityFrameworkAdapter();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
    app.UseMigrationsEndPoint();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(SengWeb.Client._Imports).Assembly);

app.Run();