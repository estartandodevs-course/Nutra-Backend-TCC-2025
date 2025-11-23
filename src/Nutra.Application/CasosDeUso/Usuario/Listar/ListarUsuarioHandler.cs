using MediatR;
using Nutra.Domain.Repository;
using Nutra.Domain.Entidades;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Nutra.Application.DTOs;

namespace Nutra.Application.CasosDeUso.Usuario.Listar
{
    public class ListarUsuarioHandler : IRequestHandler<ListarUsuarioQuery, Response<List<UsuariosResponseDTO>>>
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public ListarUsuarioHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Response<List<UsuariosResponseDTO>>> Handle(ListarUsuarioQuery query, CancellationToken cancellationToken)
        {
            var usuarios = await _usuarioRepository.Listar(cancellationToken);

            if (usuarios == null || usuarios.Count == 0)
                return Response<List<UsuariosResponseDTO>>.Erro("Nenhum usuário encontrado.");

            var usuariosDto = usuarios.Select(u => new UsuariosResponseDTO
            {
                Email = u.Email,
                Nome = u.Nome,
                Tipo = u.Tipo, 
                XpTotal = u.XpTotal,
                Turma = u.Turma
            }).ToList();

            return Response<List<UsuariosResponseDTO>>.Ok(usuariosDto);
        }
    }
}