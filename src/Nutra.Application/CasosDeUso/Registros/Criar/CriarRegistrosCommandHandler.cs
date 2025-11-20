using MediatR;
using System.Net;
using Nutra.Domain.Repository;
using Nutra.Domain.Entidades;

namespace Nutra.Application.CasosDeUso.Registros.Criar;

public class CriarRegistrosCommandHandler 
    : IRequestHandler<CriarRegistrosCommand, Response<Domain.Entidades.Registros>>
{
    private readonly IRegistrosRepository _registrosRepository;
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly ITipoRegistroRepository _tipoRegistroRepository;

    public CriarRegistrosCommandHandler(
        IRegistrosRepository registrosRepository,
        IUsuarioRepository usuarioRepository,
        ITipoRegistroRepository tipoRegistroRepository)
    {
        _registrosRepository = registrosRepository;
        _usuarioRepository = usuarioRepository;
        _tipoRegistroRepository = tipoRegistroRepository;
    }

    public async Task<Response<Domain.Entidades.Registros>> Handle(
        CriarRegistrosCommand comando,
        CancellationToken cancellationToken)
    {
      
        if (!comando.ValidarDados())
            return Response<Domain.Entidades.Registros>.Erro(
                comando.ResultadoValidacao.Errors.First().ErrorMessage
            );

        var usuario = await _usuarioRepository.ListarId(comando.IdUsuario, cancellationToken);
        if (usuario == null)
            return Response<Domain.Entidades.Registros>.Erro("Usuário não encontrado.");

        var tipoRegistro = await _tipoRegistroRepository.ObterPorCategoria(
            comando.Categoria.ToString(),
            cancellationToken);

        if (tipoRegistro == null)
            return Response<Domain.Entidades.Registros>.Erro("Categoria não encontrada.");

        // Criar registro
        var registro = new Domain.Entidades.Registros(
            comando.Quantidade,
            comando.Observacao,
            comando.IdUsuario,
            tipoRegistro.Id
        );

        await _registrosRepository.CriarRegistros(registro, cancellationToken);

        return Response<Domain.Entidades.Registros>.Ok(registro);
    }
}
