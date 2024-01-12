using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using AcmeSys.App.DTOs; 

public class PurchasesModel : PageModel
{
    private readonly HttpClient _httpClient;

    public PurchasesModel(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public IList<PurchaseDto> Purchases { get; private set; }

    public async Task OnGetAsync()
    {
        var response = await _httpClient.GetAsync("https://localhost:7010/api/purchases");
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            Purchases = JsonConvert.DeserializeObject<IList<PurchaseDto>>(content);
        }
        else
        {
            Purchases = new List<PurchaseDto>();
        }
    }
}
