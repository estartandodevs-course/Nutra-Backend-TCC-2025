using Nutra.Domain.Enums;
namespace Nutra.Domain.Entidades;

public class TipoRegistro : Entity
{
    public CategoriaRegistro Categoria { get; set; }
    
    public TipoDetalhe TipoDetalhe { get; set; }
    public string? Descricao { get; set;}

    public List<Registros> Registros { get; set; } = new List<Registros>();
    
    public TipoRegistro(){ }

    public TipoRegistro(CategoriaRegistro categoria, string? descricao, TipoDetalhe tipoDetalhe)
    {
        Categoria = categoria;
        Descricao = descricao;
    }
    
}