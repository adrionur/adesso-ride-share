namespace AdessoRideShare.Models
{
    public class TravelPlanRequest
    {
        public string From { get; set; }
        public string To { get; set; }
        public DateTime? Date { get; set; }
        public string? Description { get; set; }
        public int? NumberOfSeats { get; set; }
    }
}
