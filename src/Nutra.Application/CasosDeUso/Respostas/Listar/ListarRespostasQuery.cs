using MediatR;
using Nutra.Domain.Entidades;

namespace Nutra.Application.CasosDeUso.Respostas.Listar;

public class ListarRespostasQuery : IRequest<Response<List<Domain.Entidades.Respostas>>>
{
}