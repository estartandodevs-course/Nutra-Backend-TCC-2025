using Nutra.Domain.Entidades;
namespace Nutra.Domain.Repository;

public interface IValidacaoRepository
{
    Task<bool> ExisteQuestionario(int id, CancellationToken cancellationToken);
    Task<bool> ExistemPerguntas(int questionarioId, List<int> perguntasIds, CancellationToken cancellationToken);
    Task<bool> ExistemOpcoes(List<int> perguntasIds, List<int> opcoesIds, CancellationToken cancellationToken);
    Task<bool> ExistemRespostas(int idUsuario, CancellationToken cancellationToken);
}