using MediatR;
using Nutra.Domain.Repository;
using Nutra.Domain.Entidades;

namespace Nutra.Application.CasosDeUso.Respostas.Listar;

public class ListarRespostasHandler : IRequestHandler<ListarRespostasQuery, Response<List<Domain.Entidades.Respostas>>>
{
    private readonly IRespostasRepository _respostasRepository;

    public ListarRespostasHandler(IRespostasRepository respostasRepository)
    {
        _respostasRepository = respostasRepository;
    }

    public async Task<Response<List<Domain.Entidades.Respostas>>> Handle(ListarRespostasQuery query, CancellationToken cancellationToken)
    {
        var respostas = await _respostasRepository.ListarRespostas(cancellationToken);

        if (respostas == null || !respostas.Any())
            return Response<List<Domain.Entidades.Respostas>>.Erro("Nenhuma resposta encontrada.");

        return Response<List<Domain.Entidades.Respostas>>.Ok(respostas);
    }
}