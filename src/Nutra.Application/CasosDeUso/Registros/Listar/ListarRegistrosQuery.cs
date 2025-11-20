using MediatR;

namespace Nutra.Application.CasosDeUso.Registros.Listar;

public class ListarRegistrosQuery : IRequest<Response<List<Domain.Entidades.Registros>>>;