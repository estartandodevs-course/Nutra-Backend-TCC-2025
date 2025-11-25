using Nutra.Domain.Entidades;

namespace Nutra.Domain.Repository;

public interface IDesafiosRepository
{
    Task<Desafios?> ObterPorIdAsync(int id, CancellationToken cancellationToken);
    Task<Desafios?> ObterPorTipoRegistroAsync(int tipoRegistro, CancellationToken cancellationToken);
}
