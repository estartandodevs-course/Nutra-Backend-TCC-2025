using MediatR;
using Nutra.Application.DTOs;

namespace Nutra.Application.CasosDeUso.Registros.Listar;

public class ListarRegistrosIdQuery : IRequest<Response<RegistroResponseDto>>
{
    public int Id { get; set; }

    public ListarRegistrosIdQuery(int id)
    {
        Id = id;
    }
}