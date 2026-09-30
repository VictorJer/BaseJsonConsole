using BaseJson.ConsoleApp.Compartilhado;
using BaseJson.ConsoleApp.ModuloNome;
using BaseJson.ConsoleApp.Utilidade;

ContextoJson contexto = new ContextoJson();
contexto.Carregar();

IRepositorio<Nome> repositorioNome = new RepositorioNomeEmArquivo(contexto);

TelaPrincipal telaPrincipal = new TelaPrincipal(
// repositorioCategoria,
// repositorioProduto,
// repositorioListaCompras
repositorioNome
);

while (true)
{
    ITelaOpcoes? telaSelecionada = telaPrincipal.ApresentarMenuOpcoesPrincipal();

    if (telaSelecionada == null)
    {
        Console.Clear();
        break;
    }

    while (true)
    {
        string? opcaoSubMenu = telaSelecionada.ObterOpcaoMenu();

        if (opcaoSubMenu == "S")
        {
            Console.Clear();
            break;
        }

        if (telaSelecionada is ITelaCrud telaCrud)
        {
            if (opcaoSubMenu == "1")
                telaCrud.Cadastrar();

            else if (opcaoSubMenu == "2")
                telaCrud.Editar();

            else if (opcaoSubMenu == "3")
                telaCrud.Excluir();

            else if (opcaoSubMenu == "4")
                telaCrud.VisualizarTodos(deveExibirCabecalho: true);

        }
    }
}
