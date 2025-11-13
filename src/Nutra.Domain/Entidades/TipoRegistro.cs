using Nutra.Domain.Enums;
namespace Nutra.Domain.Entidades;

public class TipoRegistro : Entity
{
    public CategoriaRegistro Categoria;
    public string? Descricao { get; set;}

    public List<Registro> Registros { get; set; } = new List<Registro>();
    
    public TipoRegistro(){ }

    public TipoRegistro(CategoriaRegistro categoria, string? descricao)
    {
        Categoria = categoria;
        Descricao = descricao;
    }
    
}