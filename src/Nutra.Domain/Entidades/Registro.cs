namespace Nutra.Domain.Entidades;

public class Registro : Entity
{
    public int Quantidade { get; set;}
    public string? Observacao { get; set; }
    public int IdUsuario { get; set; }
    public int IdTipoRegistro { get; set;}

    public Usuario Usuario { get; set; } = null!;
    public TipoRegistro Tipo { get; set; } = null!;

    public Registro(){ }
    public Registro(int quantidade, string? observacao, int idUsuario, int idTipoRegistro)
    {
        Quantidade = quantidade;
        Observacao = observacao;
        IdUsuario = idUsuario;
        IdTipoRegistro = idTipoRegistro;
    }
}