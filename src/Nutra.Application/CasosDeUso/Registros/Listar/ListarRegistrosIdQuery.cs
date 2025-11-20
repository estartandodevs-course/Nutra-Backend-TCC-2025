using MediatR;

namespace Nutra.Application.CasosDeUso.Registros.Listar;

public class ListarRegistrosIdQuery : IRequest<Response<Domain.Entidades.Registros>>
{
    public int Id { get; set; }

    public ListarRegistrosIdQuery(int id)
    {
        Id = id;
    }
}