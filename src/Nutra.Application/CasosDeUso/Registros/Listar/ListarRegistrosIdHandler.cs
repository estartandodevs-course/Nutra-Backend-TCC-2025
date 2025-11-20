using MediatR;
using Nutra.Domain.Repository;

namespace Nutra.Application.CasosDeUso.Registros.Listar;

public class ListarRegistrosIdHandler 
    : IRequestHandler<ListarRegistrosIdQuery, Response<Domain.Entidades.Registros>>
{
    private readonly IRegistrosRepository _registro;

    public ListarRegistrosIdHandler(IRegistrosRepository registro)
    {
        _registro = registro;
    }

    public async Task<Response<Domain.Entidades.Registros>> Handle(
        ListarRegistrosIdQuery query,
        CancellationToken cancellationToken)
    {
        var registro = await _registro.ListarId(query.Id, cancellationToken);

        if (registro == null)
            return Response<Domain.Entidades.Registros>.Erro("Registro não encontrado.");

        return Response<Domain.Entidades.Registros>.Ok(registro);
    }
}