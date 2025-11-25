using Amazon.Lambda.AspNetCoreServer.Hosting;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Nutra.API.Infrastructure;
using Nutra.API.Infrastructure.Repository;
using Nutra.Application.CasosDeUso.Registros.Criar;
using Nutra.Application.CasosDeUso.Respostas.Criar;
using Nutra.Application.CasosDeUso.Usuario.Criar;
using Nutra.Domain.Repository;
using Nutra.ServiceDefaults;
using Pomelo.EntityFrameworkCore.MySql;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add Lambda hosting
builder.Services.AddAWSLambdaHosting(LambdaEventSource.HttpApi);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
}

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    // Use a specific MySQL version or get it from configuration
    // AutoDetect can fail during startup in serverless environments
    var serverVersion = new MySqlServerVersion(new Version(8, 0, 35)); // Adjust to your MySQL version
    options.UseMySql(connectionString, serverVersion, mysqlOptions =>
    {
        mysqlOptions.EnableRetryOnFailure(
            maxRetryCount: 3,
            maxRetryDelay: TimeSpan.FromSeconds(30),
            errorNumbersToAdd: null);
    });
});
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IRespostasRepository, RespostaRepository>();
builder.Services.AddScoped<IRegistrosRepository, RegistrosRepository>();
builder.Services.AddScoped<ITipoRegistroRepository, TipoRegistroRepository>();
builder.Services.AddScoped<IValidacaoRepository, ValidacaoRepository>();
builder.Services.AddScoped<IReceitasRepository, ReceitasRepository>();
builder.Services.AddScoped<IDesafiosRepository, DesafiosRepository>();
builder.Services.AddScoped<IProgressosRepository, ProgressosRepository>();
builder.Services.AddScoped<IRegrasDesafiosRepository, RegrasDesafiosRepository>();


builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(CriarUsuarioCommand).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(CriarRespostaCommand).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(CriarRegistrosCommand).Assembly);
});
// Add Controllers
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(
            new JsonStringEnumConverter(allowIntegerValues: false)
        );
    });

// Add Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "v1",
        Title = "Nutra API",
        Description = "AWS Lambda ASP.NET Core API Nutra",
    });

    // Include XML comments
    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    if (File.Exists(xmlPath))
    {
        c.IncludeXmlComments(xmlPath);
    }
});

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Add Exception Handler
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();
// Apply pending migrations at startup
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

    try
    {
        logger.LogInformation("Aplicando migrations pendentes (se houver)...");
        db.Database.Migrate();

        logger.LogInformation("Garantindo que a tabela 'Receitas' exista...");

        db.Database.ExecuteSqlRaw(@"
            CREATE TABLE IF NOT EXISTS `Receitas` (
              `Id` INT NOT NULL AUTO_INCREMENT,
              `Nome` VARCHAR(150) NOT NULL,
              `Ingredientes` TEXT NOT NULL,
              `ModoPreparo` TEXT NOT NULL,
              `ImagemBase64` LONGTEXT NULL,
              `CreatedAt` DATETIME(6) NOT NULL,
              `UpdatedAt` DATETIME(6) NULL,
              PRIMARY KEY (`Id`)
            ) ENGINE=InnoDB
              DEFAULT CHARSET=utf8mb4
              COLLATE=utf8mb4_unicode_ci;
        ");

        logger.LogInformation("Tabela 'Receitas' verificada/criada com sucesso.");
    }
    catch (Exception ex)
    {
                logger.LogError(ex, "Error applying migrations or ensuring database is created. " +
                           "The application will continue but database operations may fail.");
        // Don't throw - allow the app to start even if migrations fail
        // This is important for Lambda cold starts
    }
}

app.UseHttpsRedirection();

app.Use(async (context, next) =>
{
    if (context.Request.Method == HttpMethods.Options)
    {
        context.Response.StatusCode = 200;
        await context.Response.CompleteAsync();
    }
    else
    {
        await next();
    }
});

app.UseCors("AllowAll");

app.UseExceptionHandler();

// Configure Swagger (before MapDefaultEndpoints to avoid conflicts)
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    var jsonPath = builder.Configuration["Swagger:JsonPath"];
    c.SwaggerEndpoint(jsonPath, "Nutra API V1");
    c.RoutePrefix = "api/swagger";
    c.DocumentTitle = "Nutra API Documentation";
    c.DefaultModelsExpandDepth(-1);
    c.DisplayRequestDuration();
});

app.MapControllers();
app.MapDefaultEndpoints();

app.Run();

/// <summary>
/// Global exception handler for better error responses
/// </summary>
public class GlobalExceptionHandler : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger;

    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        _logger.LogError(exception, "An unhandled exception occurred");

        var problemDetails = new Microsoft.AspNetCore.Mvc.ProblemDetails
        {
            Status = StatusCodes.Status500InternalServerError,
            Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
            Title = "An error occurred while processing your request",
            Detail = exception.Message
        };

        httpContext.Response.StatusCode = problemDetails.Status ?? 500;
        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }
}
