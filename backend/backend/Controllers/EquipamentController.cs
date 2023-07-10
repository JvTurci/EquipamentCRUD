using backend.Entities;
using backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("equipament")]
    public class EquipamentController : Controller
    {
        private readonly IEquipamentService _equipamentService;

        public EquipamentController(IEquipamentService equipamentService)
        {
            _equipamentService = equipamentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var equipaments = await _equipamentService.GetEquipamentsAsync();
            return Ok(equipaments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var equipament = await _equipamentService.GetEquipamentByIdAsync(id);

            if(equipament == null)
                return NotFound();

            return Ok(equipament);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEquipament(Equipament equipament)
        {
            var createdEquipament = await _equipamentService.CreateEquipamentAsync(equipament);
            return CreatedAtAction(nameof(GetById), new { id = createdEquipament.Id }, createdEquipament);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEquipament(int id, Equipament equipament)
        {
            if (id != equipament.Id)
            {
                return BadRequest();
            }

            var updatedEquipament = await _equipamentService.UpdateEquipamentAsync(id, equipament);

            if (updatedEquipament == null)
            {
                return NotFound();
            }

            return Ok(updatedEquipament);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEquipament(int id)
        {
            var deletedEquipament = await _equipamentService.DeleteEquipamentAsync(id);

            if (deletedEquipament == null)
            {
                return NotFound();
            }

            return Ok(deletedEquipament);
        }
    }
}
