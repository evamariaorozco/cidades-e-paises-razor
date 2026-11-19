using eva_carrasquel_DR4_TP2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace eva_carrasquel_DR4_TP2.Pages.CountryManager;

public class CreateCountriesModel : PageModel
{
    [BindProperty]
    public List<CreateCountryModel.InputModel> Inputs { get; set; } = new();

    public List<Country> Paises { get; set; } = new();

    public void OnGet()
    {
        for (int i = 0; i < 5; i++)
        {
            Inputs.Add(new CreateCountryModel.InputModel());
        }
    }

    public void OnPost()
    {
        if (ModelState.IsValid)
        {
            foreach (var input in Inputs)
            {
                Paises.Add(new Country
                {
                    CountryName = input.CountryName,
                    CountryCode = input.CountryCode
                });
            }
        }
    }
}
