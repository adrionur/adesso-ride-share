using AdessoRideShare.Domain;

namespace AdessoRideShare.Interfaces
{
    public interface IPlanRepository
    {
        bool InsertPlan(TravelPlan plan);

        bool UpdatePlan(TravelPlan plan);

        TravelPlan FindPlanById(Guid id);

        TravelPlan FindPlanByDestination(string from, string to);


    }
}
