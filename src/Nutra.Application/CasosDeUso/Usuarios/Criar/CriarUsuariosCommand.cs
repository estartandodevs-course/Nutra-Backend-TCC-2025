using MediatR;
namespace Nutra.Application.CasosDeUso.Usuarios.Criar;

public class CriarUsuariosCommand : IRequest<CriarUsuariosCommandResponse>
{
    public string Email { get; set; } = string.Empty;
    public string Nome { get; set; } = string.Empty;
    
    public CriarUsuariosCommand(string email, string nome)
    {
        Email = email;
        Nome = nome;
    }
}