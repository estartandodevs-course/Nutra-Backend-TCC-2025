using MediatR;
using Nutra.Domain.Entidades;

namespace Nutra.Application.CasosDeUso.Usuario.Listar;

public class ListarUsuarioIdQuery : IRequest<Response<Usuarios>>
{
    public int Id { get; set; }
    
    public ListarUsuarioIdQuery(int id)
    {
        Id = id;
    }
}