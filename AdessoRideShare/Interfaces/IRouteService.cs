using AdessoRideShare.Domain;

namespace AdessoRideShare.Interfaces
{
    public interface IRouteService
    {
        Guid SaveTravelPlan(TravelPlan tp);
        bool ManageTravelPlan(Guid id, bool publish);
        TravelPlan SearchTravelPlan(string from, string to);
        bool JoinTravel(Guid id,Passenger passenger);
    }
}
