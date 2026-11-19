using System.ComponentModel.DataAnnotations;
using eva_carrasquel_DR4_TP2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace eva_carrasquel_DR4_TP2.Pages.CountryManager;

public class CreateCountryModel : PageModel
{
    [BindProperty]
    public InputModel Input { get; set; } = new();

    public Country? Pais { get; set; }

    public class InputModel
    {
        [Required(ErrorMessage = "O nome do país é obrigatório.")]
        public string CountryName { get; set; } = "";

        [Required(ErrorMessage = "O código do país é obrigatório.")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "O código do país deve ter exatamente 2 caracteres.")]
        public string CountryCode { get; set; } = "";
    }

    public void OnGet()
    {
    }

    public void OnPost()
    {
        if (!ModelState.IsValid)
        {
            return;
        }

        char letraNome = char.ToUpper(Input.CountryName[0]);
        char letraCodigo = char.ToUpper(Input.CountryCode[0]);

        if (letraNome != letraCodigo)
        {
            ModelState.AddModelError("Input.CountryCode", "O código deve começar com a mesma letra do nome do país.");
            return;
        }

        Pais = new Country
        {
            CountryName = Input.CountryName,
            CountryCode = Input.CountryCode
        };
    }
}
