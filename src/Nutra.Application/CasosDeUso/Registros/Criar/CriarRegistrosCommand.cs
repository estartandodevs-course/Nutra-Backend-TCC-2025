using MediatR;
using FluentValidation;
using FluentValidation.Results;
using System.Net;
using Nutra.Domain.Enums;

namespace Nutra.Application.CasosDeUso.Registros.Criar;

public class CriarRegistrosCommand : IRequest<Response<Domain.Entidades.Registros>>
{
    public int Quantidade { get; set;}
    public string? Observacao { get; set; }
    public int IdUsuario { get; set; }
    public CategoriaRegistro Categoria { get; set; }
    
    public ValidationResult ResultadoValidacao { get; set; }


    public CriarRegistrosCommand() { }

    public CriarRegistrosCommand(int quantidade, string? observacao, int idUsuario, CategoriaRegistro categoria)
    {
        Quantidade = quantidade;
        Observacao = observacao;
        IdUsuario = idUsuario;
        Categoria = categoria;
    }
    
    public bool ValidarDados()
    {
        var validacao = new InlineValidator<CriarRegistrosCommand>();

        validacao.RuleFor(x => x.Quantidade)
            .GreaterThan(0).WithMessage("A quantidade deve ser maior que zero.")
            .LessThanOrEqualTo(10).WithMessage("A quantidade deve ser no máximo 10.")
            .WithErrorCode(HttpStatusCode.BadRequest.ToString());

        validacao.RuleFor(x => x.Observacao)
            .MaximumLength(200)
            .WithMessage("A observação deve ter no máximo 200 caracteres.")
            .WithErrorCode(HttpStatusCode.BadRequest.ToString())
            .When(x => !string.IsNullOrWhiteSpace(x.Observacao));

        validacao.RuleFor(x => x.IdUsuario)
            .GreaterThan(0)
            .WithMessage("O id do usuário é obrigatório.")
            .WithErrorCode(HttpStatusCode.BadRequest.ToString());

        validacao.RuleFor(x => x.Categoria)
            .IsInEnum()
            .WithMessage("A categoria informada é inválida.")
            .WithErrorCode(HttpStatusCode.BadRequest.ToString());

        ResultadoValidacao = validacao.Validate(this);
        return ResultadoValidacao.IsValid;
    }
}
