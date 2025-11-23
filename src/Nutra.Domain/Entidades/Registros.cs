namespace Nutra.Domain.Entidades;

public class Registros : Entity
{
    public int Quantidade { get; set;}
    public string? Observacao { get; set; }
    public int IdUsuario { get; set; }
    public int IdTipoRegistro { get; set;}

    public Usuarios Usuarios { get; set; } = null!;
    public TipoRegistro Tipo { get; set; } = null!;

    public Registros(){ }
    public Registros(int quantidade, string? observacao, int idUsuario, int idTipoRegistro)
    {
        Quantidade = quantidade;
        Observacao = observacao;
        IdUsuario = idUsuario;
        IdTipoRegistro = idTipoRegistro;
    }
}