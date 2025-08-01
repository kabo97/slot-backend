using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BackendAPI.Models;
using BackendAPI.Data;

namespace BackendAPI.Services
{
    public class SlotService : ISlotService
    {
        private readonly AppDbContext _context;

        public SlotService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Slot>> GetAvailableSlotsAsync()
        {
            return await _context.Slots
                .Where(s => s.IsAvailable && s.Status == "Available")
                .ToListAsync();
        }
        public async Task<IEnumerable<Slot>> GetAllSlotsAsync()
        {
            return await _context.Slots.ToListAsync();
        }

        public async Task<Slot> CreateSlotAsync(Slot slot)
        {
            slot.StartTime = DateTime.SpecifyKind(slot.StartTime, DateTimeKind.Utc);
            slot.EndTime = DateTime.SpecifyKind(slot.EndTime, DateTimeKind.Utc);
            slot.CreatedOn = DateTime.UtcNow;
            _context.Slots.Add(slot);
            await _context.SaveChangesAsync();
            return slot;
        }

        public async Task<Slot> UpdateSlotAsync(int id, Slot updatedSlot)
        {
            var slot = await _context.Slots.FindAsync(id);
            if (slot == null) return null;

            if (slot.Status == "Booked") return null;

            slot.StartTime = updatedSlot.StartTime;
            slot.EndTime = updatedSlot.EndTime;
            slot.IsAvailable = updatedSlot.IsAvailable;
            slot.Status = updatedSlot.Status;
            slot.ModifiedOn = DateTime.UtcNow;


            await _context.SaveChangesAsync();
            return slot;
        }

        public async Task<bool> DeleteSlotAsync(int id)
        {
            var slot = await _context.Slots.FindAsync(id);
            if (slot == null || slot.Status == "Booked") return false;

            _context.Slots.Remove(slot);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}