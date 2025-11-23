using MediatR;
using Nutra.Domain.Repository;

namespace Nutra.Application.CasosDeUso.Usuario.Deletar
{
    public class DeletarUsuarioCommandHandler : IRequestHandler<DeletarUsuarioCommand, bool>
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public DeletarUsuarioCommandHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<bool> Handle(DeletarUsuarioCommand comando, CancellationToken cancellationToken)
        {
            return await _usuarioRepository.DeletarUsuario(comando.Id, cancellationToken);
        }
    }
}