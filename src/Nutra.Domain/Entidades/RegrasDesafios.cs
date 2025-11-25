namespace Nutra.Domain.Entidades;

public class RegrasDesafios : Entity
{
    public int IdOpcao { get; private set; }
    public int IdDesafio { get; private set; }
    public Desafios Desafios { get; private set; }
    public RegrasDesafios() { }

    public RegrasDesafios
        (
            int idDesafio,
            int idOpcao
        )
    {
        IdDesafio = idDesafio;
        IdOpcao = idOpcao;
    }
}