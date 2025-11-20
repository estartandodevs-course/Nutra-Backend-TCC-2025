using MediatR;
using Nutra.Domain.Repository;
using Nutra.Domain.Entidades;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Nutra.Application.CasosDeUso.Usuario.Listar
{
    public class ListarUsuarioHandler : IRequestHandler<ListarUsuarioQuery, Response<List<Usuarios>>>
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public ListarUsuarioHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Response<List<Usuarios>>> Handle(ListarUsuarioQuery query, CancellationToken cancellationToken)
        {
            var usuarios = await _usuarioRepository.Listar(cancellationToken);

            if (usuarios == null || usuarios.Count == 0)
                return Response<List<Usuarios>>.Erro("Nenhum usuário encontrado.");

            return Response<List<Usuarios>>.Ok(usuarios);
        }
    }
}