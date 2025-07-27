using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace BackendAPI.Models{
    public class Slot
    {
        public int SlotId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsAvailable { get; set; }
        public string Status { get; set; } = "Available";
        public int CreatedByUserId { get; set; }
        [ForeignKey("CreatedByUserId")]
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime? ModifiedOn { get; set; }
    }
}