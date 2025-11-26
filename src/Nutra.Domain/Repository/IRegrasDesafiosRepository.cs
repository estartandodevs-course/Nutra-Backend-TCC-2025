using Nutra.Domain.Entidades;

namespace Nutra.Domain.Repository;

public interface IRegrasDesafiosRepository
{
    Task<RegrasDesafios?> ObterPorIdAsync(int id);
    Task<List<RegrasDesafios>> ObterPorIdOpcao(int idOpcao, CancellationToken cancellationToken);
}
