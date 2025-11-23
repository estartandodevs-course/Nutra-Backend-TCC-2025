using Nutra.Domain.Enums;

namespace Nutra.Application.DTOs;

public class UsuariosResponseDTO
{
    public string Email { get; set; } = string.Empty;
    public string Nome { get; set; } = string.Empty;
    public TipoUsuario Tipo { get; set; } = TipoUsuario.Aluno;
    public int XpTotal { get; set; } = 0; 
    public string Turma { get; set; } = string.Empty; 
}