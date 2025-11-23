using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nutra.Application.CasosDeUso.Registros.Atualizar;
using Nutra.Application.CasosDeUso.Registros.Criar;
using Nutra.Application.CasosDeUso.Registros.Deletar;
using Nutra.Application.CasosDeUso.Registros.Listar;

namespace Nutra.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RegistrosController : ControllerBase
{
    private readonly IMediator _mediator;

    public RegistrosController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CriarRegistro([FromBody] CriarRegistrosCommand comando)
    {
        var resultado = await _mediator.Send(comando);

        if (!resultado.Sucesso)
            return BadRequest(resultado);

        return Ok(resultado);
    }

    [HttpGet]
    public async Task<IActionResult> ListarRegistros()
    {
        var resultado = await _mediator.Send(new ListarRegistrosQuery());
        return Ok(resultado);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ListarId(int id)
    {
        var resultado = await _mediator.Send(new ListarRegistrosIdQuery(id));

        if (!resultado.Sucesso)
            return NotFound(resultado);

        return Ok(resultado);
    }

    [HttpPatch("{idUsuario}/{idRegistro}")]
    public async Task<IActionResult> AtualizarParcial(
        int idUsuario,
        int idRegistro,
        [FromBody] AtualizarRegistrosCommand comando)
    {
        comando.IdUsuario = idUsuario;
        comando.Id = idRegistro;

        var resultado = await _mediator.Send(comando);

        if (!resultado.Sucesso)
            return BadRequest(resultado);

        return Ok(resultado);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Deletar(int id)
    {
        var resultado = await _mediator.Send(new DeletarRegistrosCommand(id));

        if (!resultado.Sucesso)
            return NotFound(resultado);

        return NoContent();
    }
}

