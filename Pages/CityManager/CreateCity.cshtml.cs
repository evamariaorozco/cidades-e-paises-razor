using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace eva_carrasquel_DR4_TP2.Pages.CityManager;

public class CreateCityModel : PageModel
{
    [BindProperty]
    public InputModel Input { get; set; } = new();

    public string Mensagem { get; set; } = "";

    public class InputModel
    {
        [Required(ErrorMessage = "O nome da cidade é obrigatório.")]
        [MinLength(3, ErrorMessage = "O nome da cidade deve ter no mínimo 3 caracteres.")]
        public string CityName { get; set; } = "";
    }

    public void OnGet()
    {
    }

    public void OnPost()
    {
        if (ModelState.IsValid)
        {
            Mensagem = "Cidade recebida: " + Input.CityName;
        }
    }
}
