using MediatR;
using System.Net;
using Nutra.Domain.Repository;
namespace Nutra.Application.CasosDeUso.Usuario.Atualizar;

public class AtualizarUsuarioCommandHandler : IRequestHandler<AtualizarUsuarioCommand,Response<Domain.Entidades.Usuarios>>
{
    private readonly IUsuarioRepository _usuario;

    public AtualizarUsuarioCommandHandler(IUsuarioRepository usuario)
    {
        _usuario = usuario;
    }

    public async Task<Response<Domain.Entidades.Usuarios>> Handle(AtualizarUsuarioCommand comando,
        CancellationToken cancellationToken)
    {
        if (!comando.ValidarDados())
        {
            var mensagens = comando.ResultadoValidacao.Errors
                .Select(e => e.ErrorMessage)
                .ToList();

            return Response<Domain.Entidades.Usuarios>.Erro(string.Join("; ", mensagens));
        }

        var usuario = await _usuario.ListarId(comando.Id, cancellationToken);

        if (usuario == null)
        {
            return Response<Domain.Entidades.Usuarios>.Erro("Usuário não encontrado.");
        }

        if (comando.Nome is not null)
            usuario.Nome = comando.Nome;

        if (comando.Email is not null)
            usuario.Email = comando.Email;

        if (comando.Turma is not null)
            usuario.Turma = comando.Turma;
        
        usuario.UpdatedAt = DateTime.UtcNow;

        await _usuario.AtualizarUsuario(usuario, cancellationToken);

        return Response<Domain.Entidades.Usuarios>.Ok(usuario);
    }

}