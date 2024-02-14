using CalmSquirrel.Application.Extensions;
using CalmSquirrel.Infrastructure.IoC.Extensions;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();
builder.Services.RegisterOptions(builder.Configuration);
builder.Services.RegisterServices();
builder.Services.AddMediatR(configure =>
{
    configure.RegisterServicesFromAssembly(typeof(IServiceCollectionExtensions).Assembly);
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
