using Nutra.Domain.Entidades;
using Nutra.Domain.Enums;

namespace Nutra.Domain.Repository;

public interface ITipoRegistroRepository
{
    Task<TipoRegistro?> ObterPorCategoriaETipo(CategoriaRegistro categoria, TipoDetalhe tipoEspecifico,
        CancellationToken cancellationToken);
    Task<TipoRegistro?> ObterPorId(int id, CancellationToken cancellationToken);
}