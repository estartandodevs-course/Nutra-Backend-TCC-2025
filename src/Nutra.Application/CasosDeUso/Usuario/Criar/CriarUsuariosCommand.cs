using System.Net;
using MediatR;
using FluentValidation;
using FluentValidation.Results;
using Nutra.Domain.Enums;
namespace Nutra.Application.CasosDeUso.Usuario.Criar;

public class CriarUsuarioCommand : IRequest<Response<Domain.Entidades.Usuarios>>
{
   
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Tipo { get; set; } = "Aluno"; // agora string
    public string Turma { get; set; } = string.Empty;

    public ValidationResult ResultadoValidacao { get; set; }

    public CriarUsuarioCommand( string nome, string email, string tipo, string turma)
    {

        Nome = nome;
        Email = email;
        Tipo = tipo;
        Turma = turma;
    }

    public bool ValidarDados()
    {
        var validacao = new InlineValidator<CriarUsuarioCommand>();
        validacao.RuleFor(usuario => usuario.Email)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("O e-mail é obrigatório.")
            .EmailAddress().WithMessage("O formato do e-mail é inválido.")
            .MaximumLength(100).WithMessage("O e-mail deve ter no máximo 100 caracteres.");

        validacao.RuleFor(usuario => usuario.Nome)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("O nome é obrigatório.")
            .MinimumLength(3).WithMessage("O nome deve ter pelo menos 3 caracteres.")
            .MaximumLength(50).WithMessage("O nome deve ter no máximo 50 caracteres.");

        validacao.RuleFor(usuario => usuario.Tipo)
            .Must(t => Enum.TryParse<TipoUsuario>(t, true, out _))
            .WithMessage("Tipo inválido. Valores permitidos: Aluno, Professor, Admin.");

        ResultadoValidacao = validacao.Validate(this);
        return ResultadoValidacao.IsValid;
    }
    
    public TipoUsuario ObterTipoEnum()
    {
        return Enum.TryParse<TipoUsuario>(Tipo, true, out var tipoEnum) ? tipoEnum : TipoUsuario.Aluno;
    }
}