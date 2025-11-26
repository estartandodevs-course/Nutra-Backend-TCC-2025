namespace Nutra.Domain.Entidades;

public class Progressos : Entity
{
    public bool Completo { get; set; } = false;
    public DateTime? DataConclusao { get; set; }
    public int QuantidadeAtual { get; set; } = 0;
    public bool Ativo { get; private set; } = true;
    public int IdUsuario { get; private set; }
    public int IdDesafio { get; private set; }
    public Usuarios Usuario { get; private set; }
    public Desafios Desafio { get; private set; }
    public Progressos() { }

    public Progressos(int idUsuario, int idDesafio)
    {
        IdUsuario = idUsuario;
        IdDesafio = idDesafio;
        Completo = false;
        QuantidadeAtual = 0;
        Ativo = true;
    }
}