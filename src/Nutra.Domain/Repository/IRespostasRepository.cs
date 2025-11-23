using Nutra.Domain.Entidades;
namespace Nutra.Domain.Repository;

public interface IRespostasRepository
{
    Task CriarResposta(IEnumerable<Respostas> respostas,  CancellationToken cancellationToken);
    Task<List<Respostas>> ListarRespostas(CancellationToken cancellationToken);
    Task<bool> DeletarRespostas(int idUsuario, CancellationToken cancellationToken);

}