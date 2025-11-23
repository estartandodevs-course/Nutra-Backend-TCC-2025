using MediatR;
using Nutra.Application.DTOs;

namespace Nutra.Application.CasosDeUso.Registros.Listar;

public class ListarRegistrosQuery : IRequest<Response<List<RegistroResponseDto>>>;