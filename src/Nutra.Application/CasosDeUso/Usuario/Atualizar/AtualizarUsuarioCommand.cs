using System.Net;
using MediatR;
using FluentValidation;
using FluentValidation.Results;

namespace Nutra.Application.CasosDeUso.Usuario.Atualizar;

public class AtualizarUsuarioCommand : IRequest<Response<Domain.Entidades.Usuarios>>
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Turma { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public ValidationResult ResultadoValidacao { get; private set; }

    public AtualizarUsuarioCommand(int id,  string nome, string email,string turma)
    {
        Id = id;
        Nome = nome;
        Email = email;
        Turma = turma;
    }

    public bool ValidarDados()
    {
        var validacao = new InlineValidator<AtualizarUsuarioCommand>();

        validacao.RuleFor(u => u.Email)
            .NotEmpty().WithMessage("O e-mail é obrigatório.")
            .EmailAddress().WithMessage("O formato do e-mail é inválido.")
            .MaximumLength(100).WithMessage("O e-mail deve ter no máximo 100 caracteres.");

        validacao.RuleFor(u => u.Nome)
            .NotEmpty().WithMessage("O nome é obrigatório.")
            .MinimumLength(3).WithMessage("O nome deve ter pelo menos 3 caracteres.")
            .MaximumLength(50).WithMessage("O nome deve ter no máximo 50 caracteres.");

        validacao.RuleFor(u => u.Turma)
            .NotEmpty().WithMessage("A turma é obrigatória.")
            .MaximumLength(20).WithMessage("A turma deve ter no máximo 20 caracteres.");

        ResultadoValidacao = validacao.Validate(this);
        return ResultadoValidacao.IsValid;
    }
}