using Microsoft.AspNetCore.Mvc.RazorPages;

namespace eva_carrasquel_DR4_TP2.Pages.CityManager;

public class CitiesModel : PageModel
{
    public List<string> Cities { get; set; } = ["Rio", "São Paulo", "Brasília"];

    public void OnGet()
    {
    }
}
