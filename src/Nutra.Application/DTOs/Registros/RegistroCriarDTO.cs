using Nutra.Domain.Enums;

namespace Nutra.Application.DTOs;

public class RegistroCriarDTO
{
    public int IdUsuario { get; set; }
    public CategoriaRegistro Categoria { get; set; }
    public TipoDetalhe TipoDetalhe { get; set; }
    public int Quantidade { get; set;}
    public string? Observacao { get; set; }
}