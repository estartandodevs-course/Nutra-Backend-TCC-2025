namespace Nutra.Domain.Entidades;

public class Questionarios : Entity
{
    public string Titulo { get; set;}
    public bool Ativo { get; set; }
    
    public ICollection<Perguntas> Perguntas { get; set; } = new List<Perguntas>();
    
    public Questionarios(){ }
    public Questionarios(string titulo)
    {
        Titulo = titulo;
    }
}