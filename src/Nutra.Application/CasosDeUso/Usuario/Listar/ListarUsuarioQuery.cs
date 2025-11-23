using MediatR;
using Nutra.Domain.Entidades;
using System.Collections.Generic;
using Nutra.Application.DTOs;

namespace Nutra.Application.CasosDeUso.Usuario.Listar
{
    public class ListarUsuarioQuery : IRequest<Response<List<UsuariosResponseDTO>>>
    {
        public ListarUsuarioQuery() { }
    }
}