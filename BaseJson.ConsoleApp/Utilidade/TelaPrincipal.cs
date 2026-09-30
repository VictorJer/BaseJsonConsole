using BaseJson.ConsoleApp.Compartilhado;
using BaseJson.ConsoleApp.ModuloNome;

namespace BaseJson.ConsoleApp.Utilidade;

public class TelaPrincipal
{
    private readonly IRepositorio<Nome> repositorioNome;

    public TelaPrincipal(IRepositorio<Nome> repositorioNome)
    {
        // this.repositorioCategoria = repositorioCategoria;
        // this.repositorioProduto = repositorioProduto;
        // this.repositorioListaCompras = repositorioListaCompras; so ADD repositorios nessesarios 
        this.repositorioNome = repositorioNome;
    }

    public ITelaOpcoes? ApresentarMenuOpcoesPrincipal()
    {
        // Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Lista de Compras");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("1 - Gerenciar Nome");
        Console.WriteLine("2 - Gerenciar algo");
        Console.WriteLine("3 - Gerenciar listas algo");
        Console.WriteLine("S - Sair");
        Console.WriteLine("---------------------------------");
        Console.Write("> ");
        string? opcaoMenuPrincipal = Console.ReadLine()?.ToUpper();

        if (opcaoMenuPrincipal == "S")
            return null;

        if (opcaoMenuPrincipal == "1")
            return new TelaNome(repositorioNome);

        // if (opcaoMenuPrincipal == "2")
        // return new TelaProduto(repositorioProduto, repositorioCategoria);

        // if (opcaoMenuPrincipal == "3")
        // return new TelaListaCompras(repositorioListaCompras, repositorioProduto);

        return null;
    }
}