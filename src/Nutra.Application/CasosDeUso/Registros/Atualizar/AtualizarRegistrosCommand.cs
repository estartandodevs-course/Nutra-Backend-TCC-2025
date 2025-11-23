using MediatR;
using Nutra.Domain.Enums;
using FluentValidation;
using FluentValidation.Results;
using Nutra.Application.DTOs;

namespace Nutra.Application.CasosDeUso.Registros.Atualizar;

public class AtualizarRegistrosCommand : IRequest<Response<RegistroResponseDto>>
{
    public int Id { get; set; }
    public int? Quantidade { get; set; }
    public string? Observacao { get; set; }
    public int IdUsuario { get; set; }

    public TipoDetalhe? TipoDetalhe { get; set; }

    public ValidationResult ResultadoValidacao { get; set; }

    public bool ValidarDados()
    {
        var validator = new InlineValidator<AtualizarRegistrosCommand>();

        validator.RuleFor(x => x.Quantidade)
            .GreaterThan(0).WithMessage("A quantidade deve ser maior que zero.")
            .LessThanOrEqualTo(10).WithMessage("A quantidade deve ser no máximo 10.")
            .When(x => x.Quantidade.HasValue);

        validator.RuleFor(x => x.Observacao)
            .MaximumLength(200)
            .WithMessage("A observação deve ter no máximo 200 caracteres.")
            .When(x => !string.IsNullOrWhiteSpace(x.Observacao));

        validator.RuleFor(x => x.IdUsuario)
            .GreaterThan(0).WithMessage("O id do usuário é obrigatório.");

        ResultadoValidacao = validator.Validate(this);
        return ResultadoValidacao.IsValid;
    }
}