namespace Nutra.Domain.Entidades;

public class Opcoes : Entity
{
    public string Descricao { get; set;}
    public int IdPergunta { get; set;}
    
    public Perguntas Perguntas { get; set; }

    public Opcoes(){ }
    
    public Opcoes(string descricao, int idPergunta)
    {
        Descricao = descricao;
        IdPergunta = idPergunta;
    }
}