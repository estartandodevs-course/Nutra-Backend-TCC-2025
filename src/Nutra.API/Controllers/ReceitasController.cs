using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nutra.Application.CasosDeUso.Receitas.Criar;
using Nutra.Domain.Repository;

namespace Nutra.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReceitasController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IReceitasRepository _receitasRepository;

    public ReceitasController(IMediator mediator, IReceitasRepository receitasRepository)
    {
        _mediator = mediator;
        _receitasRepository = receitasRepository;
    }

    // GET api/receitas
    [HttpGet]
    public async Task<IActionResult> GetTodas()
    {
        var receitas = await _receitasRepository.ObterTodasAsync();
        return Ok(receitas);
    }

    // GET api/receitas/5
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetPorId(int id)
    {
        var receita = await _receitasRepository.ObterPorIdAsync(id);

        if (receita == null)
            return NotFound();

        return Ok(receita);
    }

    // POST api/receitas
    [HttpPost]
    public async Task<IActionResult> Criar([FromBody] CriarReceitaCommand comando)
    {
        var resposta = await _mediator.Send(comando);

        if (!resposta.Sucesso)
            return StatusCode((int)resposta.StatusCode, resposta);

        return StatusCode((int)resposta.StatusCode, resposta.Dados);
    }
}
