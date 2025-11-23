using MediatR;

namespace Nutra.Application.CasosDeUso.Registros.Deletar
{
    public class DeletarRegistrosCommand : IRequest<Response<bool>>
    {
        public int Id { get; set; }

        public DeletarRegistrosCommand(int id)
        {
            Id = id;
        }
    }
}