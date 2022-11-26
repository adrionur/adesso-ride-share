using AdessoRideShare.Models;
using System.ComponentModel.DataAnnotations;

namespace AdessoRideShare.Domain
{
    public class Passenger
    {
        [Required]
        public string NationalId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
