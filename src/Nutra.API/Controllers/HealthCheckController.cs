using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nutra.API.Data;

namespace Nutra.API.Controllers;

/// <summary>
/// Controller for health check and database connection verification
/// </summary>
[ApiController]
[Route("api/v1/[controller]")]
[Produces("application/json")]
public class HealthCheckController : ControllerBase
{
    private readonly ILogger<HealthCheckController> _logger;
    private readonly NutraDbContext _dbContext;

    public HealthCheckController(ILogger<HealthCheckController> logger, NutraDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    /// <summary>
    /// Verifica se a conexão com o banco de dados está funcionando
    /// </summary>
    [HttpGet("database")]
    [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(object), StatusCodes.Status503ServiceUnavailable)]
    public async Task<ActionResult> CheckDatabase(CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation("Verificando conexão com o banco de dados");
            
            // Tenta abrir uma conexão com o banco de dados
            var canConnect = await _dbContext.Database.CanConnectAsync(cancellationToken);
            
            if (canConnect)
            {
                // Tenta executar uma query simples para garantir que a conexão está funcionando
                await _dbContext.Database.ExecuteSqlRawAsync("SELECT 1", cancellationToken);
                
                _logger.LogInformation("Conexão com o banco de dados verificada com sucesso");
                
                return Ok(new
                {
                    status = "ok",
                    message = "Conexão com o banco de dados está funcionando corretamente",
                    timestamp = DateTime.UtcNow,
                    database = _dbContext.Database.GetDbConnection().Database
                });
            }
            else
            {
                _logger.LogWarning("Não foi possível conectar ao banco de dados");
                return StatusCode(503, new
                {
                    status = "error",
                    message = "Não foi possível conectar ao banco de dados",
                    timestamp = DateTime.UtcNow
                });
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao verificar conexão com o banco de dados");
            return StatusCode(503, new
            {
                status = "error",
                message = "Erro ao verificar conexão com o banco de dados",
                error = ex.Message,
                timestamp = DateTime.UtcNow
            });
        }
    }
}

