using MediatR;
using Nutra.Domain.Entidades;
using Nutra.Domain.Repository;

namespace Nutra.Application.CasosDeUso.Usuario.Listar;

public class ListarUsuarioIdHandler : IRequestHandler<ListarUsuarioIdQuery, Response<Usuarios>>
{
    private readonly IUsuarioRepository _usuarioRepository;

    public ListarUsuarioIdHandler(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public async Task<Response<Usuarios>> Handle(ListarUsuarioIdQuery query, CancellationToken cancellationToken)
    {
        var usuario = await _usuarioRepository.ListarId(query.Id, cancellationToken);

        if (usuario == null)
            return Response<Usuarios>.Erro("Usuário não encontrado.");

        return Response<Usuarios>.Ok(usuario);
    }
}