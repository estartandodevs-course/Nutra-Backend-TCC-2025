using Nutra.Domain.Entidades;

namespace Nutra.Domain.Repository;

public interface IProgressosRepository
{
    Task<Progressos?> ObterPorIdAsync(int id);
    Task AdicionarAsync(int idUsuario, int idDesafio, int QuantidadeAtual, CancellationToken cancellationToken);
}
