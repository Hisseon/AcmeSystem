using Microsoft.AspNetCore.Mvc;
using AcmeSys.App.Services;
using AcmeSys.App.DTOs;

namespace AcmeSystem.Controllers
{
    

    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly SaleService _saleService;

        public SalesController(SaleService saleService)
        {
            _saleService = saleService;
        }

        // Métodos GET, POST, etc.

        // GET: api/sale
        [HttpGet]
        public async Task<IActionResult> GetAllSale()
        {
            var sales = await _saleService.GetAllSalesAsync();
            return Ok(sales);
        }

        // GET: api/sale/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSale(int id)
        {
            var sale = await _saleService.GetSaleByIdAsync(id);
            if (sale == null)
            {
                return NotFound();
            }
            return Ok(sale);
        }

        // POST: api/sale
        [HttpPost]
        public async Task<IActionResult> CreateSale([FromBody] SaleDto saleDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _saleService.AddSaleAsync(saleDto);
            return CreatedAtAction(nameof(GetSale), new { id = saleDto.SaleId }, saleDto);
        }

        // DELETE: api/sales/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSale(int id)
        {
            var sale = await _saleService.GetSaleByIdAsync(id);
            if (sale == null)
            {
                return NotFound();
            }

            await _saleService.DeleteSaleAsync(id);
            return NoContent();
        }
    }

}
