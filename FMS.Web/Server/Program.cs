using FMS.Application;
using FMS.DAL;

var builder = WebApplication.CreateBuilder();

builder.Services.AddControllers();

builder.Services.AddApplication();

var app  = builder.Build();

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