using OBilet_Case.Application.Services;
using OBilet_Case.Core.Interfaces.IAdapter;
using OBilet_Case.Core.Interfaces.IManager;
using OBilet_Case.Core.Interfaces.IRepository;
using OBilet_Case.Core.Interfaces.IService;
using OBilet_Case.Infrastructure.Adapters;
using OBilet_Case.Infrastructure.Caches;
using OBilet_Case.Infrastructure.Managers;
using OBilet_Case.Infrastructure.Repositories;
using OBilet_Case.UI.Middlewares;
using System.Net.Http;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddHttpContextAccessor();
builder.Services.AddControllersWithViews();
builder.Services.AddSession();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromDays(1);
});
builder.Services.AddSingleton<ICacheManager,InMemoryCacheManager>();

builder.Services.AddScoped<IUserContextManager, UserContextManager>();
builder.Services.AddHttpClient<IOBiletAPIAdapter, OBiletAPIV2Adapter>(client =>
{
    client.BaseAddress = new Uri("https://v2-api.obilet.com/");

    client.DefaultRequestHeaders.Add("Authorization", "Basic JEcYcEMyantZV095WVc3G2JtVjNZbWx1");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});

builder.Services.AddScoped<IBusLocationRepository, BusLocationRepository>();
builder.Services.AddScoped<IJourneyRepository, JourneyRepository>();

builder.Services.AddScoped<IBusLocationService, BusLocationService>();
builder.Services.AddScoped<IJourneyService, JourneyService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseSession();
app.UseMiddleware<UserContextMiddleware>();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
