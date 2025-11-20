using MediatR;
using Nutra.Domain.Entidades;
using System.Collections.Generic;

namespace Nutra.Application.CasosDeUso.Usuario.Listar
{
    public class ListarUsuarioQuery : IRequest<Response<List<Usuarios>>>
    {
        public ListarUsuarioQuery() { }
    }
}