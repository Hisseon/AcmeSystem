using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using AcmeSys.App.DTOs; 

public class ProductsModel : PageModel
{
    private readonly HttpClient _httpClient;

    public ProductsModel(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public IList<ProductDto> Products { get; private set; }

    public async Task OnGetAsync()
    {
        var response = await _httpClient.GetAsync("https://localhost:7010/api/products");
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            Products = JsonConvert.DeserializeObject<IList<ProductDto>>(content);
        }
        else
        {
            Products = new List<ProductDto>();
        }
    }
}

