using MediatR;
namespace Nutra.Application.CasosDeUso.Respostas.Deletar;

public class DeletarRespostasCommand : IRequest<Response<bool>>
{
    public int Id { get; set;}

    public DeletarRespostasCommand(int id)
    {
        Id = id;
    }
}