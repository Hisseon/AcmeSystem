using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using AcmeSys.App.DTOs; 

public class SubsidiariesModel : PageModel
{
    private readonly HttpClient _httpClient;

    public SubsidiariesModel(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public IList<SubsidiaryDto> Subsidiaries { get; private set; }

    public async Task OnGetAsync()
    {
        var response = await _httpClient.GetAsync("https://localhost:7010/api/subsidiary");
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            Subsidiaries = JsonConvert.DeserializeObject<IList<SubsidiaryDto>>(content);
        }
        else
        {
            Subsidiaries = new List<SubsidiaryDto>();
        }
    }
}
