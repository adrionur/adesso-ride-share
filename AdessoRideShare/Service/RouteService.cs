using AdessoRideShare.Domain;
using AdessoRideShare.Interfaces;
using Newtonsoft.Json;
using System;

namespace AdessoRideShare.Service
{
    public class RouteService : IRouteService
    {
        private readonly IPlanRepository _planRepository;
        public RouteService(IPlanRepository planRepository)
        {
            _planRepository = planRepository;
        }

        public Guid SaveTravelPlan(TravelPlan tp)
        {
           _planRepository.InsertPlan(tp);

            return tp.Id;
        }

        public bool ManageTravelPlan(Guid id, bool publish)
        {
            var travelPlan = _planRepository.FindPlanById(id);
            travelPlan.IsPublished = publish;
            _planRepository.UpdatePlan(travelPlan);

            return true;
        }

        public TravelPlan SearchTravelPlan(string from, string to)
        {
           return _planRepository.FindPlanByDestination(from, to);    
        }

        public bool JoinTravel(Guid id, Passenger passenger)
        {
            var travelPlan = _planRepository.FindPlanById(id);
            if (travelPlan == null || travelPlan.NumberOfSeats == travelPlan.Passengers.Count())
            {
                return false;
            }
            travelPlan.Passengers.Add(passenger);
            _planRepository.UpdatePlan(travelPlan);

            return true;
        }
    }
}
