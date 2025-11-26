using Nutra.Domain.Entidades;
using Nutra.Domain.Enums;

namespace Nutra.Domain.Repository;

public interface IProgressosRepository
{
    Task<Progressos?> ObterPorIdAsync(int id);
    Task<List<Progressos>> ObterPorTipoRegistro(int tipoRegistro, int idUsuario, CancellationToken cancellationToken);
    Task<List<Progressos>> ObterPorTipoDetalhe(TipoDetalhe tipoDetalhe, int idUsuario, CancellationToken cancellationToken);
    Task AdicionarAsync(int idUsuario, int idDesafio, int QuantidadeAtual, CancellationToken cancellationToken);
}
