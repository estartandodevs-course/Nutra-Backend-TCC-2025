using MediatR;
using System.Net;
using Nutra.Application;
using Nutra.Domain.Repository;

namespace Nutra.Application.CasosDeUso.Registros.Deletar
{
    public class DeletarRegistrosCommandHandler 
        : IRequestHandler<DeletarRegistrosCommand, Response<bool>>
    {
        private readonly IRegistrosRepository _registrosRepository;

        public DeletarRegistrosCommandHandler(IRegistrosRepository registrosRepository)
        {
            _registrosRepository = registrosRepository;
        }

        public async Task<Response<bool>> Handle(
            DeletarRegistrosCommand comando, 
            CancellationToken cancellationToken)
        {
            var resultado = await _registrosRepository.DeletarRegistros(
                comando.Id, 
                cancellationToken
            );

            if (!resultado)
                return Response<bool>.Erro("Registro não encontrado ou não pôde ser deletado.");

            return Response<bool>.Ok(true);
        }
    }
}