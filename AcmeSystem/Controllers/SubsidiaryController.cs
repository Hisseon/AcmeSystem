using Microsoft.AspNetCore.Mvc;
using AcmeSys.App.Services;
using AcmeSys.App.DTOs;
using System.Threading.Tasks;

namespace AcmeSystem.Controllers
{
    

    [Route("api/[controller]")]
    [ApiController]
    public class SubsidiariesController : ControllerBase
    {
        private readonly SubsidiaryService _subsidiaryService;

        public SubsidiariesController(SubsidiaryService subsidiaryService)
        {
            _subsidiaryService = subsidiaryService;
        }

        // GET: api/subsidiaries
        [HttpGet]
        public async Task<IActionResult> GetAllSubsidiaries()
        {
            var subsidiaries = await _subsidiaryService.GetAllSubsidiariesAsync();
            return Ok(subsidiaries);
        }

        // GET: api/subsidiaries/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubsidiary(int id)
        {
            var subsidiary = await _subsidiaryService.GetSubsidiaryByIdAsync(id);
            if (subsidiary == null)
            {
                return NotFound();
            }
            return Ok(subsidiary);
        }

        // POST: api/subsidiaries
        [HttpPost]
        public async Task<IActionResult> CreateSubsidiary([FromBody] SubsidiaryDto subsidiaryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _subsidiaryService.AddSubsidiaryAsync(subsidiaryDto);
            return CreatedAtAction(nameof(GetSubsidiary), new { id = subsidiaryDto.SubsidiaryId }, subsidiaryDto);
        }

        // DELETE: api/subsidiaries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubsidiary(int id)
        {
            var subsidiary = await _subsidiaryService.GetSubsidiaryByIdAsync(id);
            if (subsidiary == null)
            {
                return NotFound();
            }

            await _subsidiaryService.DeleteSubsidiaryAsync(id);
            return NoContent(); // Retorna un código de estado 204 No Content
        }
    }

}
