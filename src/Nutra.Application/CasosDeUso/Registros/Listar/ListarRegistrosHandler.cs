using MediatR;
using Nutra.Domain.Repository;

namespace Nutra.Application.CasosDeUso.Registros.Listar;

public class ListarRegistrosHandler 
    : IRequestHandler<ListarRegistrosQuery, Response<List<Domain.Entidades.Registros>>>
{
    private readonly IRegistrosRepository _registros;

    public ListarRegistrosHandler(IRegistrosRepository registros)
    {
        _registros = registros;
    }

    public async Task<Response<List<Domain.Entidades.Registros>>> Handle(
        ListarRegistrosQuery comando,
        CancellationToken cancellationToken)
    {
        var lista = await _registros.ListarRegistros(cancellationToken);

        return Response<List<Domain.Entidades.Registros>>.Ok(lista);
    }
}