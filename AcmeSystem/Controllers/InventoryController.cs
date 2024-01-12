using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AcmeSys.App.DTOs;
using AcmeSys.App.Services;
namespace AcmeSystem.Controllers
{
    

    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly InventoryService _inventoryService;

        public InventoryController(InventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        // GET: api/inventory
        [HttpGet]
        public async Task<IActionResult> GetAllInventory()
        {
            var inventories = await _inventoryService.GetAllInventoryAsync();
            return Ok(inventories);
        }

        // GET: api/inventory/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInventory(int id)
        {
            var inventory = await _inventoryService.GetInventoryByIdAsync(id);
            if (inventory == null)
            {
                return NotFound();
            }
            return Ok(inventory);
        }

        // POST: api/inventory
        [HttpPost]
        public async Task<IActionResult> CreateInventory([FromBody] InventoryDto inventoryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _inventoryService.AddInventoryAsync(inventoryDto);
            return CreatedAtAction(nameof(GetInventory), new { id = inventoryDto.InventoryId }, inventoryDto);
        }

        // DELETE: api/inventory/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInventory(int id)
        {
            var inventory = await _inventoryService.GetInventoryByIdAsync(id);
            if (inventory == null)
            {
                return NotFound();
            }

            await _inventoryService.DeleteInventoryAsync(id);
            return NoContent(); // Retorna un código de estado 204 No Content
        }

    }

}
