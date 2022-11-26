using AdessoRideShare.Models;
using System.ComponentModel.DataAnnotations;

namespace AdessoRideShare.Domain
{
    public class TravelPlan
    {
        [Key]
        public Guid Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime? Date { get; set; }
        public string? Description { get; set; }
        public int? NumberOfSeats { get; set; }
        public bool IsPublished { get; set; }

        public List<Passenger> Passengers { get; set; }
    }
}
