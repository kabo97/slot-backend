namespace BackendAPI.Models{
    public class Slot
    {
        public int SlotId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsAvailable { get; set; }
        public string Status { get; set; } = "Available";
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}