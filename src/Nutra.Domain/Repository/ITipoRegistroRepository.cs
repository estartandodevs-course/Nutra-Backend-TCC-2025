using Nutra.Domain.Entidades;
namespace Nutra.Domain.Repository;

public interface ITipoRegistroRepository
{
    Task<TipoRegistro?> ObterPorCategoria(string categoria, CancellationToken ct);
}
