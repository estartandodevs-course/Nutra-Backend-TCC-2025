namespace Nutra.Domain.Entidades;

public class Questionario : Entity
{
    public string Titulo { get; set;}
    public bool Ativo { get; set; }
    
    public ICollection<Pergunta> Perguntas { get; set; } = new List<Pergunta>();
    
    public Questionario(){ }
    public Questionario(string titulo)
    {
        Titulo = titulo;
    }
}