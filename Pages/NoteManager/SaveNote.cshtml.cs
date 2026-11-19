using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace eva_carrasquel_DR4_TP2.Pages.NoteManager;

public class SaveNoteModel : PageModel
{
    private readonly IWebHostEnvironment _environment;

    public SaveNoteModel(IWebHostEnvironment environment)
    {
        _environment = environment;
    }

    [BindProperty]
    public InputModel Input { get; set; } = new();

    public string NomeArquivo { get; set; } = "";

    public class InputModel
    {
        [Required(ErrorMessage = "O texto da nota é obrigatório.")]
        public string Content { get; set; } = "";
    }

    public void OnGet()
    {
    }

    public void OnPost()
    {
        if (ModelState.IsValid)
        {
            string pasta = Path.Combine(_environment.WebRootPath, "files");
            Directory.CreateDirectory(pasta);

            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            NomeArquivo = "note-" + timestamp + ".txt";

            string caminho = Path.Combine(pasta, NomeArquivo);
            System.IO.File.WriteAllText(caminho, Input.Content);
        }
    }
}
