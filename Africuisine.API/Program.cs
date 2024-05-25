using Africuisine.Application.Data.Config;
using Africuisine.Application.Extensions;
using Africuisine.Infrastructure.Extensions;
using Africuisine.API.Extensions;
using Africuisine.API.Middleware;
using Serilog;
using Serilog.Formatting.Json;
using Africuisine.Application;

string SeqUri = "http://localhost:5341";

Log.Logger = new LoggerConfiguration().WriteTo
    .Console(new JsonFormatter())
    .WriteTo.Seq(SeqUri)
    .CreateLogger();

try
{
    Log.Information("Setting up Africuisine API");
    var builder = WebApplication.CreateBuilder(args);
    // Add services to the container.

    builder.Services.AddAPIAutoMappingAndFluentValidation();
    builder.Services.AddAPIDbContext(builder.Configuration);
    builder.Services.AddAPIDefaultDbContext(builder.Configuration);
    builder.Services.AddAPIAuthentication(builder.Configuration);

    //Add Custom API Repositories To The Container

    //Add Custom API Services To The Container
    builder.Services.AddAPIApplicationServices();
    builder.Services.AddAPIInfrastructureServices(builder.Configuration);
    builder.Services.EnableCors();

    //Adding Configuration Options
    builder.Services.Configure<PostmarkConfig>(builder.Configuration.GetSection("Postmark"));
    builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("JWT"));
    builder.Services.Configure<CloudinaryConfig>(builder.Configuration.GetSection("Cloudinary"));
    builder.Services.Configure<AzureConfig>(builder.Configuration.GetSection("Azure"));
    builder.Services.Configure<DatabaseConfig>(builder.Configuration.GetSection("ConnectionStrings"));

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddAPISwaggerGen();
    builder.Services.AddSerilog(
        (opts) =>
        {
            opts.MinimumLevel.Information();
            opts.MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Warning);
            opts.MinimumLevel.Override("System", Serilog.Events.LogEventLevel.Warning);
        }
    );

    builder.Host.UseSerilog(
        (ctx, lc) =>
        {
            lc.WriteTo.Console(new JsonFormatter()).WriteTo.Seq(SeqUri);
        }
    );

    var app = builder.Build();

    app.UseMiddleware<ExceptionMiddleware>();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.UseCors(opts =>
    {
        opts.AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin();
    });

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    Log.Information("Starting up Africuisine API");

    app.Run();
    Log.Information("Africuisine API is now running succcessfully at {}");
}
catch (Exception exception)
{
    Log.Fatal(
        exception,
        "An unexpected error occurred while initializing Africuisine API. Cause:{exception}",
        exception
    );
}
finally
{
    Log.CloseAndFlush();
}
