using FMS.Application;
using FMS.DAL;
using Microsoft.AspNetCore.Hosting.StaticWebAssets;

var builder = WebApplication.CreateBuilder();

builder.Services.AddControllers();

builder.Services.AddApplication();

// for local Production mode
// https://stackoverflow.com/questions/75029227/blazor-pages-displaying-incorrectly-in-production-mode
//builder.WebHost.ConfigureAppConfiguration((ctx, cb) =>
//    {
//        if (!ctx.HostingEnvironment.IsDevelopment())
//        {
//            StaticWebAssetsLoader.UseStaticWebAssets(ctx.HostingEnvironment, ctx.Configuration);
//        }
//    }
//);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}

app.UseHttpsRedirection();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.MapControllers();
app.MapFallbackToFile("index.html");

using (var scope = app.Services.CreateScope())
{
    SeedData.Initialize(scope.ServiceProvider.GetRequiredService<FMSContext>());
}

app.Run();