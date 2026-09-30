using System.Text.Json;
using System.Text.Json.Serialization;

public class ContextoJson
{
    // public List<Categoria> Categorias { get; set; } = new List<Categoria>();
    // public List<Produto> Produtos { get; set; } = new List<Produto>();
    // public List<ListaCompras> ListaCompras { get; set; } = new List<ListaCompras>(); so ADD as List aqui nesse modelo
    public List<Nome> Nomes { get; set; } = new List<Nome>();

    private readonly string caminhoArquivo;
    public ContextoJson()
    {
        string caminhoAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData); // acha o caminho de %AppData%

        string caminhoDiretorio = Path.Combine(caminhoAppData, "Lista"); // Liga o caminho mult plataforma

        Directory.CreateDirectory(caminhoDiretorio); // ve se tem uma pasta se n tiver cra

        caminhoArquivo = Path.Combine(caminhoDiretorio, "dados.json");
    }

    public void Salvar()
    {
        JsonSerializerOptions opcoesJson = new JsonSerializerOptions();
        opcoesJson.WriteIndented = true;
        opcoesJson.ReferenceHandler = ReferenceHandler.Preserve; // preserva as referencias

        string jsonString = JsonSerializer.Serialize(this, opcoesJson);

        File.WriteAllText(caminhoArquivo, jsonString);
    }

    public void Carregar()
    {
        if (!File.Exists(caminhoArquivo))
            return;

        JsonSerializerOptions opcoesJson = new JsonSerializerOptions();
        opcoesJson.ReferenceHandler = ReferenceHandler.Preserve; // preserva as referencias

        string jsonString = File.ReadAllText(caminhoArquivo);

        ContextoJson? contextoSalvo = JsonSerializer.Deserialize<ContextoJson>(jsonString, opcoesJson);

        if (contextoSalvo == null)
            return;

        // this.Categorias = contextoSalvo.Categorias;
        // this.Produtos = contextoSalvo.Produtos;
        // this.ListaCompras = contextoSalvo.ListaCompras; so ADD as List aqui nesse modelo
        this.Nomes = contextoSalvo.Nomes;
    }
}