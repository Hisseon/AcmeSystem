using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using AcmeSys.App.DTOs; 
public class SalesModel : PageModel
{
    private readonly HttpClient _httpClient;

    public SalesModel(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public IList<SaleDto> Sales { get; private set; }

    public async Task OnGetAsync()
    {
        var response = await _httpClient.GetAsync("https://localhost:7010/api/sales");
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            Sales = JsonConvert.DeserializeObject<IList<SaleDto>>(content);
        }
        else
        {
            Sales = new List<SaleDto>();
        }
    }
}
