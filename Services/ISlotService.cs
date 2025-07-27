using System.Collections.Generic;
using System.Threading.Tasks;
using BackendAPI.Models;

namespace BackendAPI.Services
{
    public interface ISlotService
    {
        Task<IEnumerable<Slot>> GetAvailableSlotsAsync();
        Task<Slot> CreateSlotAsync(Slot slot);
        Task<Slot> UpdateSlotAsync(int id, Slot slot);
        Task<bool> DeleteSlotAsync(int id);
    }
}
