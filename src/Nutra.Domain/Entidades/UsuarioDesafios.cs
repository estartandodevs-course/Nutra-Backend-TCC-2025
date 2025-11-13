namespace Nutra.Domain.Entidades;

public class UsuarioDesafios : Entity
{
        public int IdUsuario { get; set; }
        public int IdDesafio { get; set; }
        public int ProgressoAtual { get; set; }
        public bool Completo { get; set; }
        public DateTime? DataConclusao { get; set; }
        
        public Usuario? Usuario { get; set; }
        public Desafio? Desafio { get; set; }
    
        public UsuarioDesafios(){ }

        public UsuarioDesafios
        (
                int progressoAtual, 
                DateTime? dataConclusao, 
                int idUsuario, 
                int idDesafio
        )
        {
                ProgressoAtual = progressoAtual;
                DataConclusao = dataConclusao;
                IdUsuario = idUsuario;
                IdDesafio = idDesafio;
        }
}