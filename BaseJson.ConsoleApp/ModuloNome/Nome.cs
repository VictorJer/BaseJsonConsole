using BaseJson.ConsoleApp.Compartilhado;

public class Nome : EntidadeBase
{
    public string NomeUsuario { get; set; } = string.Empty;

    public Nome() { }

    public Nome(string nomeUsuario)
    {
        NomeUsuario = nomeUsuario;
    }

    public override void AtualizarDados(EntidadeBase entidadeAtualizada)
    {
        Nome? entidadeAtualixzada = (Nome?)entidadeAtualizada;

        NomeUsuario = entidadeAtualixzada.NomeUsuario;
    }

    public override List<string> Validar()
    {
        List<string> erros = new();

        if (string.IsNullOrWhiteSpace(NomeUsuario))
            erros.Add("O nome é obrigatório.");

        return erros;
    }
}