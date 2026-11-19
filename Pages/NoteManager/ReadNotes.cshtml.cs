using Microsoft.AspNetCore.Mvc.RazorPages;

namespace eva_carrasquel_DR4_TP2.Pages.NoteManager;

public class ReadNotesModel : PageModel
{
    private readonly IWebHostEnvironment _environment;

    public ReadNotesModel(IWebHostEnvironment environment)
    {
        _environment = environment;
    }

    public List<string> Arquivos { get; set; } = new();

    public string ArquivoSelecionado { get; set; } = "";

    public string Conteudo { get; set; } = "";

    public void OnGet(string? arquivo)
    {
        string pasta = Path.Combine(_environment.WebRootPath, "files");

        if (Directory.Exists(pasta))
        {
            foreach (string caminho in Directory.GetFiles(pasta, "*.txt"))
            {
                Arquivos.Add(Path.GetFileName(caminho));
            }
        }

        // So abre arquivos que estao na lista da pasta files
        if (arquivo != null && Arquivos.Contains(arquivo))
        {
            ArquivoSelecionado = arquivo;
            Conteudo = System.IO.File.ReadAllText(Path.Combine(pasta, arquivo));
        }
    }
}
