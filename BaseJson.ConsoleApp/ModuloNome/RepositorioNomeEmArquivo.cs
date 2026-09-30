using BaseJson.ConsoleApp.Compartilhado;
using BaseJson.ConsoleApp.Compartilhado.Arquivos;

namespace BaseJson.ConsoleApp.ModuloNome;

public class RepositorioNomeEmArquivo : RepositorioBaseEmArquivo<Nome>, IRepositorio<Nome>
{
    public RepositorioNomeEmArquivo(ContextoJson contexto) : base(contexto)
    {
    }

    protected override List<Nome> CarregarRegistros()
    {
        return contexto.Nomes;
    }
}