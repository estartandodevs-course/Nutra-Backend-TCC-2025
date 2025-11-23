namespace Nutra.Domain.Entidades;

public class Niveis : Entity
{
    public string Nome { get; private set;}
    public string? Descricao { get; private set;}
    public int XpNecessario { get; private set; }
    
    public Niveis(){}

    public Niveis(string nome, string? descricao, int xpNecessario)
    {
        Nome = nome;
        Descricao = descricao;
        XpNecessario = xpNecessario;
    }
}