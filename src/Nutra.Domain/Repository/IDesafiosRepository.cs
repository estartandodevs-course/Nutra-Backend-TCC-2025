using Nutra.Domain.Entidades;

namespace Nutra.Domain.Repository;

public interface IDesafiosRepository
{
    Task<Desafios?> ObterPorIdAsync(int id);
    Task<Desafios?> ObterPorTipoRegistroAsync(TipoRegistro tipoRegistro);
}
