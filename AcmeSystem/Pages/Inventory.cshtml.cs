using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using AcmeSys.App.DTOs; 
public class InventoryModel : PageModel
{
    private readonly HttpClient _httpClient;

    public InventoryModel(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public IList<InventoryDto> InventoryItems { get; private set; }

    public async Task OnGetAsync()
    {
        var response = await _httpClient.GetAsync("https://localhost:7010/api/inventory");
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            InventoryItems = JsonConvert.DeserializeObject<IList<InventoryDto>>(content);
        }
        else
        {
            InventoryItems = new List<InventoryDto>();
        }
    }
}
