using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using RBS.API.Infrastracture;
using RBS.API.Infrastracture.StartupConfiguration;
using RBS.Persistence.Database;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();


try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.ConfigureService();

    var app = builder.Build();

    using (var scope = app.Services.CreateScope())
    {
        var dataContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        dataContext.Database.Migrate();
    }

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseCors();


    app.UseRouting();

    var options = new HealthCheckOptions
    {
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
    };
    //app.UseHealthChecks("/HealthCheck", options);
    app.UseEndpoints(endpoints =>
    {

        endpoints.MapHealthChecks("/HealthCheck", options);

    });
    app.UseHttpsRedirection();

    app.UseMiddleware<ErrorHandlerMiddleware>();


    app.UseAuthorization();

    app.MapControllers();

    app.Run();

}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpecredly");
}
finally
{
    Log.CloseAndFlush();
}

