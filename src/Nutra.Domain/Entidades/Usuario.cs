using Nutra.Domain.Enums;
namespace Nutra.Domain.Entidades;

public class Usuario : Entity
{
    public string Email { get; private set; } = string.Empty;
    private string Senha { get; set;} = string.Empty;
    public string Nome { get; set; } = string.Empty;
    public TipoUsuario Tipo { get; private set;}
    public int XpTotal { get; set; } = 0; 
    public string Turma { get; set; } = string.Empty; 
    public bool Ativo { get; set; } = true;

    public List<Respostas>? Respostas { get; set; } = new List<Respostas>();
   
    public Usuario(){ }
    
    public Usuario(string email, string senha, string nome, TipoUsuario tipo, string turma)
    {
        Email = email;
        Senha = senha;
        Nome = nome;
        Turma = turma;
        Tipo = tipo;
    }
}