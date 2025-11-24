using MediatR;
using System.Net;
using Nutra.Domain.Repository;

namespace Nutra.Application.CasosDeUso.Usuarios.Criar;

public class CriarUsuariosCommandHandler : IRequestHandler<CriarUsuariosCommand, CriarUsuariosCommandResponse>
{
    private readonly IUsuariosRepository _usuariosRepository;

    public CriarUsuariosCommandHandler(IUsuariosRepository usuariosRepository)
    {
        _usuariosRepository = usuariosRepository;
    }

    public async Task<CriarUsuariosCommandResponse> Handle(CriarUsuariosCommand comando,
        CancellationToken cancellationToken)
    {
        try
        {
            var novoUsuario = new Domain.Entidades.Usuarios(
                comando.Email, 
                comando.Nome,
            );

            await _usuariosRepository.CriarUsuarios(novoUsuario, cancellationToken);

            return CriarUsuariosCommandResponse.Sucesso(
                statusCode: HttpStatusCode.Created,
                dados: novoUsuario
            );
        }
        catch (Exception ex)
        {
            return CriarUsuariosCommandResponse.ErroValidacao(
                statusCode: HttpStatusCode.InternalServerError,
                mensagensErros: new List<string> { ex.ToString() }
            );
        }
    }
}