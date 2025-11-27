using MediatR;
using Nutra.Domain.Repository;
using Nutra.Domain.Enums;
using Nutra.Domain.Entidades;

namespace Nutra.Application.CasosDeUso.Usuario.Criar;

public class CriarUsuarioCommandHandler : IRequestHandler<CriarUsuarioCommand, Response<Usuarios>>
{
    private readonly IUsuarioRepository _usuarioRepository;

    public CriarUsuarioCommandHandler(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public async Task<Response<Usuarios>> Handle(CriarUsuarioCommand comando, CancellationToken cancellationToken)
    {
       
        if (!comando.ValidarDados())
        {
            var mensagens = comando.ResultadoValidacao.Errors
                .Select(e => e.ErrorMessage)
                .ToList();

            return Response<Usuarios>.Erro(string.Join("; ", mensagens));
        }

        try
        {
            TipoUsuario tipoEnum = comando.ObterTipoEnum();

            var novoUsuario = new Usuarios(
                comando.Email,
                comando.Senha,
                comando.Nome,
                tipoEnum,
                comando.Turma
            );

            await _usuarioRepository.CriarUsuario(novoUsuario, cancellationToken);

            return Response<Usuarios>.Ok(novoUsuario);
        }
        catch (Exception ex)
        {
            return Response<Usuarios>.Erro($"Erro ao criar usuário: {ex.Message}");
        }
    }
}