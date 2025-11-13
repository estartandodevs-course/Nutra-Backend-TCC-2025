namespace Nutra.Domain.Entidades;

public class Opcao : Entity
{
    public string Descricao { get; set;}
    public int IdPergunta { get; set;}
    
    public Pergunta Pergunta { get; set; }

    public Opcao(){ }
    
    public Opcao(string descricao, int idPergunta)
    {
        Descricao = descricao;
        IdPergunta = idPergunta;
    }
}