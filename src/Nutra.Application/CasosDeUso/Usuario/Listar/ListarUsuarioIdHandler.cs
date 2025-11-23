using MediatR;
using Nutra.Application.DTOs;
using Nutra.Domain.Entidades;
using Nutra.Domain.Repository;

namespace Nutra.Application.CasosDeUso.Usuario.Listar;

public class ListarUsuarioIdHandler : IRequestHandler<ListarUsuarioIdQuery, Response<UsuariosResponseDTO>>
{
    private readonly IUsuarioRepository _usuarioRepository;

    public ListarUsuarioIdHandler(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public async Task<Response<UsuariosResponseDTO>> Handle(ListarUsuarioIdQuery query, CancellationToken cancellationToken)
    {
        var usuario = await _usuarioRepository.ListarId(query.Id, cancellationToken);

        if (usuario == null)
            return Response<UsuariosResponseDTO>.Erro("Usuário não encontrado.");

        var usuarioDto = new UsuariosResponseDTO
        {
            Email = usuario.Email,
            Nome = usuario.Nome,
            Tipo = usuario.Tipo,      // assumindo que Tipo é do enum TipoUsuario
            XpTotal = usuario.XpTotal,
            Turma = usuario.Turma
        };

        return Response<UsuariosResponseDTO>.Ok(usuarioDto);
    }
}