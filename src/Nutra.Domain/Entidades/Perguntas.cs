namespace Nutra.Domain.Entidades;

public class Perguntas : Entity
{
    public string Enunciado { get; set;}
    public int IdQuestionario { get; set;}
    
    public Questionarios Questionarios { get; set;}
    public List<Opcoes> OpcoesRespostas { get; set; } = new List<Opcoes>();

    public Perguntas(){ }
    public Perguntas(string enunciado, int idQuestionario)
    {
        Enunciado = enunciado;
        IdQuestionario = idQuestionario;
    }
}