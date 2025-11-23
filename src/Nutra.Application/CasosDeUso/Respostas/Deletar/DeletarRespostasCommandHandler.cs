using MediatR;
using Nutra.Domain.Repository;

namespace Nutra.Application.CasosDeUso.Respostas.Deletar
{
    public class DeletarRespostasCommandHandler : IRequestHandler<DeletarRespostasCommand, Response<bool>>
    {
        private readonly IRespostasRepository _respostasRepository;

        public DeletarRespostasCommandHandler(IRespostasRepository respostasRepository)
        {
            _respostasRepository = respostasRepository;
        }

        public async Task<Response<bool>> Handle(DeletarRespostasCommand comando, CancellationToken cancellationToken)
        {
            var sucesso = await _respostasRepository.DeletarRespostas(comando.Id, cancellationToken);

            if (!sucesso)
                return Response<bool>.Erro("Não foi possível deletar a resposta ou ela não existe.");

            return Response<bool>.Ok(sucesso);
        }
    }
}