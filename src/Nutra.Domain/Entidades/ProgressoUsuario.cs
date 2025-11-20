namespace Nutra.Domain.Entidades;

public class ProgressoUsuario : Entity
{
    public bool completo { get; set; } = false;
    public DateTime DataConclusao { get; set; }
    
    public int IdAluno { get; set; }
    public int IdNivel{ get; set;}
    
    public Usuarios Usuarios { get; set; }
    public Niveis? Nivel { get; set; }
    
    public ProgressoUsuario(){ }
}