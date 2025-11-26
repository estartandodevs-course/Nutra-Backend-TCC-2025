using Nutra.Domain.Enums;

namespace Nutra.Application.DTOs;

public class RegistroAtualizarDTO
{
    public int Id { get; set; }
    public int IdUsuario { get; set; }
    public TipoDetalhe? TipoDetalhe { get; set; }
    public int? Quantidade { get; set; }
    public string? Observacao { get; set; }
}