using Microsoft.AspNetCore.Mvc;
using AcmeSys.App.Services;
using AcmeSys.App.DTOs;
using System.Threading.Tasks;

namespace AcmeSystem.Controllers
{
    

    [Route("api/[controller]")]
    [ApiController]
    public class PurchasesController : ControllerBase
    {
        private readonly PurchaseService _purchaseService;

        public PurchasesController(PurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }

        // Métodos GET, POST, etc.

        // GET: api/purchase
        [HttpGet]
        public async Task<IActionResult> GetAllPurchase()
        {
            var purchases = await _purchaseService.GetAllPurchasesAsync();
            return Ok(purchases);
        }

        // GET: api/purchase/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPurchase(int id)
        {
            var purchase = await _purchaseService.GetPurchaseByIdAsync(id);
            if (purchase == null)
            {
                return NotFound();
            }
            return Ok(purchase);
        }

        // POST: api/purchase
        [HttpPost]
        public async Task<IActionResult> CreatePurchase([FromBody] PurchaseDto purchaseDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _purchaseService.AddPurchaseAsync(purchaseDto);
            return CreatedAtAction(nameof(GetPurchase), new { id = purchaseDto.PurchaseId }, purchaseDto);
        }

        // DELETE: api/purchases/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePurchase(int id)
        {
            var purchase = await _purchaseService.GetPurchaseByIdAsync(id);
            if (purchase == null)
            {
                return NotFound();
            }

            await _purchaseService.DeletePurchaseAsync(id);
            return NoContent();
        }
    }

}
