namespace Nutra.Domain.Entidades;

public class Usuarios : Entity
{
    public string Email { get; set; } = string.Empty;
    public string Nome { get; set; } = string.Empty;
    
    public Usuarios(string email, string nome)
    {
        Email = email;
        Nome = nome;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }
}