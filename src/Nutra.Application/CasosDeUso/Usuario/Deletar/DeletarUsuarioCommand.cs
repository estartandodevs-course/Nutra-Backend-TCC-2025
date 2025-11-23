using MediatR;
using System.Net;
namespace Nutra.Application.CasosDeUso.Usuario.Deletar;

public class DeletarUsuarioCommand : IRequest<bool>
{
    public int Id { get; }

    public DeletarUsuarioCommand(int id)
    {
        Id = id;
    }
}