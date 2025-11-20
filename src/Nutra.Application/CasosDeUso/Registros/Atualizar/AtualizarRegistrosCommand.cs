using MediatR;
namespace Nutra.Application.CasosDeUso.Registros.Atualizar;

public class AtualizarRegistrosCommand : IRequest<Response<Domain.Entidades.Registros>>
{
    public int Id { get; set; }
    public int? Quantidade { get; set;}
    public string? Observacao { get; set; }
    public int IdUsuario { get; set; }
    
    public AtualizarRegistrosCommand
    (
        int id,
        int? quantidade, 
        string? observacao,
        int idUsuario
    )
    {
        Id = id;
        Quantidade = quantidade;
        Observacao = observacao;
        IdUsuario = idUsuario;
    }

}