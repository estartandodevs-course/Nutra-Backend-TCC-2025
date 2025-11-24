using Nutra.Domain.Entidades;

namespace Nutra.Domain.Repository;

public interface IReceitasRepository
{
    Task<Receitas> AdicionarAsync(Receitas receita);
    Task<List<Receitas>> ObterTodasAsync();
    Task<Receitas?> ObterPorIdAsync(int id);
}
