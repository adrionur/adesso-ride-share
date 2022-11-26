using AdessoRideShare.Domain;
using AdessoRideShare.Interfaces;
using Newtonsoft.Json;

namespace AdessoRideShare.Repository
{
    public class PlanRepository : IPlanRepository
    {
        private const string filePath = @"FakeDb/travel_plan.json";
        public TravelPlan FindPlanById(Guid id)
        {
            string db = File.ReadAllText(filePath);
            List<TravelPlan> travelPlans = JsonConvert.DeserializeObject<List<TravelPlan>>(db);
            return travelPlans.Where(x => x.Id == id).FirstOrDefault();
        }

        public TravelPlan FindPlanByDestination(string from, string to)
        {
            string db = File.ReadAllText(filePath);
            List<TravelPlan> travelPlans = JsonConvert.DeserializeObject<List<TravelPlan>>(db);
            return travelPlans.FirstOrDefault(x => x.IsPublished && x.From == from && x.To == to);
        }


        public bool InsertPlan(TravelPlan plan)
        {
            string db = File.ReadAllText(filePath);
            List<TravelPlan> travelPlans = JsonConvert.DeserializeObject<List<TravelPlan>>(db);
            travelPlans.Add(plan);
            File.WriteAllText(filePath, JsonConvert.SerializeObject(travelPlans, Formatting.Indented));

            return true;
        }

        public bool UpdatePlan(TravelPlan plan)
        {
            string db = File.ReadAllText(filePath);
            List<TravelPlan> travelPlans = JsonConvert.DeserializeObject<List<TravelPlan>>(db);
            var existing = travelPlans.Where(x=> x.Id == plan.Id).First();
            int index = travelPlans.IndexOf(existing);
            travelPlans[index] = plan;
            File.WriteAllText(filePath, JsonConvert.SerializeObject(travelPlans, Formatting.Indented));

            return true;
        }
    }
}
