using MediatR;
using Nutra.Application.DTOs;
using Nutra.Domain.Entidades;

namespace Nutra.Application.CasosDeUso.Usuario.Listar;

public class ListarUsuarioIdQuery : IRequest<Response<UsuariosResponseDTO>>
{
    public int Id { get; set; }
        
    public ListarUsuarioIdQuery(int id)
    {
        Id = id;
    }
}