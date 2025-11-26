using System.Net;
using MediatR;
using Nutra.Domain.Entidades;
using Nutra.Domain.Repository;

namespace Nutra.Application.CasosDeUso.Receitas.Criar;

public class CriarReceitaCommandHandler : IRequestHandler<CriarReceitaCommand, CriarReceitaCommandResponse>
{
    private readonly IReceitasRepository _receitasRepository;

    public CriarReceitaCommandHandler(IReceitasRepository receitasRepository)
    {
        _receitasRepository = receitasRepository;
    }

    public async Task<CriarReceitaCommandResponse> Handle(CriarReceitaCommand request, CancellationToken cancellationToken)
    {
        try
        {
                var receita = new Nutra.Domain.Entidades.Receitas(
                nome: request.Nome,
                ingredientes: request.Ingredientes,
                modoPreparo: request.ModoPreparo,
                imagemBase64: request.ImagemBase64
            );

            var novaReceita = await _receitasRepository.AdicionarAsync(receita);

            return CriarReceitaCommandResponse.Ok(
                statusCode: HttpStatusCode.Created,
                dados: novaReceita
            );
        }
        catch (Exception ex)
        {
            return CriarReceitaCommandResponse.Erro(
                statusCode: HttpStatusCode.InternalServerError,
                erros: new List<string> { ex.Message }
            );
        }
    }
}
