using AdessoRideShare.Domain;
using AdessoRideShare.Interfaces;
using AdessoRideShare.Models;
using AdessoRideShare.Service;
using Microsoft.AspNetCore.Mvc;

namespace AdessoRideShare.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RouteController : Controller
    {
        /*
    - [ ] Kullanıcı sisteme seyahat planını Nereden, Nereye, Tarih ve Açıklama, Koltuk Sayısı bilgileri ile ekleyebilmeli
    - [ ] Kullanıcı tanımladığı seyahat planını yayına alabilmeli ve yayından kaldırabilmeli
    - [ ] Kullanıcılar sistemdeki yayında olan seyahat planlarını Nereden ve Nereye bilgileri ile aratabilmeli
    - [ ] Kullanıcılar yayında olan seyehat planlarına "Koltuk Sayısı" dolana kadar katılım isteği gönderebilmeli
         */
        private readonly IRouteService _routeService;
        private readonly ILogger<RouteController> _logger;

        public RouteController(ILogger<RouteController> logger, IRouteService routeService)
        {
            _logger = logger;
            _routeService = routeService;
        }

        [HttpPut("SetTravelPlan")]
        public IActionResult SetTravelPlan(TravelPlanRequest tp)
        {
            TravelPlan plan = new TravelPlan()
            {
                Id = Guid.NewGuid(),
                Date = tp.Date,
                Description = tp.Description,
                From = tp.From,
                To = tp.To,
                NumberOfSeats = tp.NumberOfSeats,
                IsPublished = false,
                Passengers = new List<Passenger>()
            };
            var result = _routeService.SaveTravelPlan(plan);
            return Ok(new ApiResponse() { IsSuccess = true , Response = result});
        }

        [HttpPost("PublishTravelPlan")]
        public IActionResult PublishTravelPlan(Guid id)
        {
            var result = _routeService.ManageTravelPlan(id, true);
            return Ok(new ApiResponse() { IsSuccess = true, Response = result });
        }

        [HttpPost("HideTravelPlan")]
        public IActionResult HideTravelPlan(Guid id)
        {
            var result = _routeService.ManageTravelPlan(id, false);
            return Ok(new ApiResponse() { IsSuccess = true, Response = result });
        }

        [HttpPost("SearchTravelPlan")]
        public IActionResult SearchTravelPlan(string from, string to)
        {
            var result = _routeService.SearchTravelPlan(from, to);
            return Ok(new ApiResponse() { IsSuccess = true, Response = result });
        }

        [HttpPost("JoinTravelPlan")]
        public IActionResult JoinTravelPlan(Guid id, Passenger passenger)
        {
            var result = _routeService.JoinTravel(id, passenger);
            return Ok(new ApiResponse() { IsSuccess = true, Response = result });
        }
    }
}