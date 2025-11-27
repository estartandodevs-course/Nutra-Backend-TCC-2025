using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nutra.Application.CasosDeUso.Usuario.Atualizar;
using Nutra.Application.CasosDeUso.Usuario.Criar;
using Nutra.Application.CasosDeUso.Usuario.Deletar;
using Nutra.Application.CasosDeUso.Usuario.Listar;
using Nutra.Application.DTOs;

namespace Nutra.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuariosController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsuariosController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CriarUsuario([FromBody] UsuariosCriarDTO dto)
    {
        var comando = new CriarUsuarioCommand
        (
            dto.Nome,
            dto.Senha,
            dto.Email,
            dto.Tipo,
            dto.Turma
        );
        var resultado = await _mediator.Send(comando);
        
        if (!resultado.Sucesso)
            return BadRequest(resultado);
        
        return Ok(resultado);
    }

    [HttpGet]
    public async Task<IActionResult> Listar()
    {
        var query = new ListarUsuarioQuery();
        var usuarios = await _mediator.Send(query);

        return Ok(usuarios);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ListarId(int id)
    {
        var query = new ListarUsuarioIdQuery(id);
        var usuario = await _mediator.Send(query);

        return Ok(usuario);
    }
    
    [HttpPatch("{id}")]
    public async Task<IActionResult> AtualizarUsuario(int id, [FromBody] UsuariosAtualizarDTO dto)
    {
        var comando = new AtualizarUsuarioCommand
        (
            dto.Id, 
            dto.Nome,
            dto.Email,
            dto.Turma
        );

        var resultado = await _mediator.Send(comando);

        if (!resultado.Sucesso)
            return BadRequest(resultado);

        return Ok(resultado);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Deletar(int id)
    {
        var command = new DeletarUsuarioCommand(id);
        var sucesso = await _mediator.Send(command);

        if (!sucesso)
            return NotFound();

        return NoContent();
    }

}