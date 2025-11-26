using MediatR;
using Nutra.Application.DTOs.Progressos;

namespace Nutra.Application.CasosDeUso.Progressos.Listar;

public class ObterPorUsuarioQuery : IRequest<Response<List<ProgressosListarDTO>>>
{
    public int IdUsuario { get; set; }

    public ObterPorUsuarioQuery(int idUsuario)
    {
        IdUsuario = idUsuario;
    }
}