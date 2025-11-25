namespace Nutra.Domain.Entidades;

public class Desafios : Entity
{
    public string Titulo { get; private set; }
    public string? Descricao { get; private set; }
    public int QuantidadeMeta { get; private set; }
    public int XpRecompensa { get; private set; }
    public bool Ativo { get; private set; } = false;
    public int IdTipoRegistro { get; private set; }
    public int IdNivel { get; private set; }
    public TipoRegistro TipoRegistro { get; private set; }
    public Niveis Nivel { get; private set; }
    public Desafios() { }

    public Desafios
        (
            string titulo,
            string? descricao,
            int xpRecompensa,
            int quantidadeMeta,
            int idTipoRegistro,
            int idNivel
        )
    {
        Titulo = titulo;
        Descricao = descricao;
        XpRecompensa = xpRecompensa;
        QuantidadeMeta = quantidadeMeta;
        IdTipoRegistro = idTipoRegistro;
        IdNivel = idNivel;
    }
}