using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nutra.Application.CasosDeUso.Respostas.Criar;
using Nutra.Application.CasosDeUso.Respostas.Deletar;
using Nutra.Application.CasosDeUso.Respostas.Listar;

namespace TesteNutra.WebApi.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class RespostasController : ControllerBase
{
    private readonly IMediator _mediator;

    public RespostasController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CriarResposta([FromBody] CriarRespostaCommand comando)
    {
        var resultado = await _mediator.Send(comando);

        if (!resultado.Sucesso)
            return BadRequest(resultado);

        return Ok(resultado);
    }

    [HttpGet]
    public async Task<IActionResult> ListarRespostas()
    {
        var resultado = await _mediator.Send(new ListarRespostasQuery());
        if (!resultado.Sucesso)
            return NotFound(resultado);

        return Ok(resultado);
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Deletar(int id)
    {
        var resultado = await _mediator.Send(new DeletarRespostasCommand(id));

        if (!resultado.Sucesso)
            return NotFound(resultado);

        return NoContent();
    }
}