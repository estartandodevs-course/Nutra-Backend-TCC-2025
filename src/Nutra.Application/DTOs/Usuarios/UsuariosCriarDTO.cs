namespace Nutra.Application.DTOs;

public class UsuariosCriarDTO
{
    public string Nome { get; set; }
    public string Senha { get; set; }
    public string Email { get; set; }
    public string Tipo { get; set; } = "Aluno";
    public string Turma { get; set; } = string.Empty;
}