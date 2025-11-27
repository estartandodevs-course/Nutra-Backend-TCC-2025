using Nutra.Domain.Enums;
namespace Nutra.Domain.Entidades;

public class Usuarios : Entity
{
    public string Email { get; set; } = string.Empty;
    public string Senha { get; private set; }
    public string Nome { get; set; } = string.Empty;
    public TipoUsuario Tipo { get; set; } = TipoUsuario.Aluno;
    public int XpTotal { get; set; } = 0; 
    public string Turma { get; set; } = string.Empty; 
    public bool Ativo { get; set; } = true;

    public List<Respostas>? Respostas { get; set; } = new List<Respostas>();
    
    private Usuarios(){ }
    public Usuarios(string email, string senha, string nome, TipoUsuario tipo, string turma)
    {
        Email = email;
        Senha = senha;
        Nome = nome;
        Turma = turma;
        Tipo = tipo;
        Ativo = true;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }
}