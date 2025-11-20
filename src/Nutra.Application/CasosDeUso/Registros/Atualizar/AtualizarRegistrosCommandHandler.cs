using MediatR;
using System.Net;
using Nutra.Domain.Repository;
using Nutra.Domain.Entidades;

namespace Nutra.Application.CasosDeUso.Registros.Atualizar;

public class AtualizarRegistrosCommandHandler :
    IRequestHandler<AtualizarRegistrosCommand, Response<Domain.Entidades.Registros>>
{
    private readonly IUsuarioRepository _usuario;
    private readonly IRegistrosRepository _registro;

    public AtualizarRegistrosCommandHandler(IUsuarioRepository usuario, IRegistrosRepository registro)
    {
        _usuario = usuario;
        _registro = registro;
    }

    public async Task<Response<Domain.Entidades.Registros>> Handle(
        AtualizarRegistrosCommand comando,
        CancellationToken cancellationToken)
    {
        var usuario = await _usuario.ListarId(comando.IdUsuario, cancellationToken);
        if (usuario == null)
            return Response<Domain.Entidades.Registros>.Erro("Usuário não encontrado.");

        var registro = await _registro.ListarId(comando.Id, cancellationToken);
        if (registro == null)
            return Response<Domain.Entidades.Registros>.Erro("Registro não encontrado.");

        if (comando.Quantidade.HasValue)
            registro.Quantidade = comando.Quantidade.Value;

        if (!string.IsNullOrEmpty(comando.Observacao))
            registro.Observacao = comando.Observacao;

        registro.UpdatedAt = DateTime.UtcNow;

        await _registro.AtualizarRegistros(registro, usuario.Id, cancellationToken);

        return Response<Domain.Entidades.Registros>.Ok(registro);
    }
}