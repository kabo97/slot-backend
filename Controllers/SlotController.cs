using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackendAPI.Data;
using BackendAPI.Models;
using BackendAPI.Services;

namespace BackendAPI.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class SlotController : ControllerBase
    {
        private readonly ISlotService _slotService;

        public SlotController(ISlotService slotService)
        {
            _slotService = slotService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAvailableSlots()
        {
            var slots = await _slotService.GetAvailableSlotsAsync();
            return Ok(slots);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSlot(Slot slot)
        {
            var created = await _slotService.CreateSlotAsync(slot);
            return CreatedAtAction(nameof(CreateSlot), new { id = created.SlotId }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSlot(int id, Slot slot)
        {
            var updated = await _slotService.UpdateSlotAsync(id, slot);
            if (updated == null) return BadRequest("Slot cannot be edited.");
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSlot(int id)
        {
            var deleted = await _slotService.DeleteSlotAsync(id);
            return deleted ? Ok() : BadRequest("Cannot delete this slot.");
        }
    }
}