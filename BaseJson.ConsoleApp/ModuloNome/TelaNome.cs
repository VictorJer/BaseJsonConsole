using BaseJson.ConsoleApp.Compartilhado;

namespace BaseJson.ConsoleApp.ModuloNome;

public class TelaNome : TelaBase<Nome>, ITelaOpcoes, ITelaCrud
{
    IRepositorio<Nome> repositorioNome;
    public TelaNome(IRepositorio<Nome> repositorioNome) : base("nome", repositorioNome)
    {
        this.repositorioNome = repositorioNome;
    }

    public override void VisualizarTodos(bool deveExibirCabecalho)
    {
        if (deveExibirCabecalho)
            ExibirCabecalho("Visualização de nomes");

        List<Nome> nomes = repositorioNome.SelecionarTodos();

        if (nomes.Count == 0)
        {
            Console.WriteLine("Nenhum nome cadastrado.");
            return;
        }

        foreach (Nome nome in nomes)
            Console.WriteLine($"ID: {nome.Id} | Nome: {nome.NomeUsuario}");
    }

    protected override Nome ObterDadosCadastrais()
    {
        Console.Write("Digite o nome: ");
        string nomeUsuario = Console.ReadLine() ?? string.Empty;

        return new Nome(nomeUsuario);
    }
}