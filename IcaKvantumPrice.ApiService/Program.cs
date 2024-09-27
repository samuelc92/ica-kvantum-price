using FastEndpoints;
using FastEndpoints.Swagger;
using IcaKvantumPrice.ApiService.Database;
using IcaKvantumPrice.ApiService.Services;
using IcaKvantumPrice.ApiService.Shoppings.UploadReceipt;
using Serilog;
using Serilog.Events;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateBootstrapLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddSerilog((services, lc) =>lc
        .ReadFrom.Configuration(builder.Configuration)
        .ReadFrom.Services(services)
        .Enrich.FromLogContext()
        .WriteTo.Console());

    builder.Services.AddFastEndpoints();
    builder.Services.AddSwaggerDocument();

    // Add service defaults & Aspire components.
    builder.AddServiceDefaults();

    // Add services to the container.
    builder.Services.AddProblemDetails();

    builder.AddNpgsqlDbContext<DatabaseContext>("IcaConnectionString");
    builder.Services.AddScoped<IPdfService, PdfService>();
    builder.Services.AddScoped<IShoppingService, ShoppingService>();

    var app = builder.Build();

    app.UseFastEndpoints();
    // Configure the HTTP request pipeline.
    app.UseExceptionHandler();

    app.MapDefaultEndpoints();

    app.UseOpenApi();
    app.UseSwaggerUi(c => c.ConfigureDefaults());

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}
