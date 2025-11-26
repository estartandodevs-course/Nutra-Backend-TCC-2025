using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nutra.Application.CasosDeUso.Progressos.Listar;

namespace Nutra.API.Controllers;


[ApiController]
[Route("api/[controller]")]

public class ProgressosController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProgressosController(IMediator mediator)
    {
            _mediator = mediator;
    }
    
    [HttpGet("{idUsuario}")]
    public async Task<IActionResult> ListarProgressosUsuario(int idUsuario)
    {
        var resultado = await _mediator.Send(new ObterPorUsuarioQuery(idUsuario));
        return Ok(resultado);
    }
}
