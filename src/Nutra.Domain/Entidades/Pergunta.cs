namespace Nutra.Domain.Entidades;

public class Pergunta : Entity
{
    public string Enunciado { get; set;}
    public int IdQuestionario { get; set;}
    
    public Questionario Questionario { get; set;}
    public List<Opcao> OpcoesRespostas { get; set; } = new List<Opcao>();

    public Pergunta(){ }
    public Pergunta(string enunciado, int idQuestionario)
    {
        Enunciado = enunciado;
        IdQuestionario = idQuestionario;
    }
}