using MediatR;
using Nutra.Domain.Enums;
using FluentValidation;
using FluentValidation.Results;
using Nutra.Application.DTOs;

namespace Nutra.Application.CasosDeUso.Registros.ListarTiposRegistros;

public class ListarTiposRegistrosQuery(int categoria) : IRequest<Response<List<TiposRegistrosResponseDto>>>
{
    public CategoriaRegistro Categoria { get; set; } = (CategoriaRegistro)categoria;

    public ValidationResult ResultadoValidacao { get; set; }

    public bool ValidarDados()
    {
        var validator = new InlineValidator<ListarTiposRegistrosQuery>();

        validator.RuleFor(x => x.Categoria)
            .Must(x => Enum.IsDefined(x))
            .WithMessage("O valor da categoria deve ser válido.");

        ResultadoValidacao = validator.Validate(this);
        return ResultadoValidacao.IsValid;
    }
}