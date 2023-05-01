using LEGOINNOVATIVE.Model;

namespace LEGOINNOVATIVE.MockData
{
    public class MockPlans
    {

        private static List<Plans> PlansList = new List<Plans>()
        {
        new Plans("Starter", 1, 500, false, 750.00, false),
        new Plans("Hobby", 3, 1000, false, 1500.00, false),
        new Plans("Enthusiast", 5, 2000, false, 3000.00, true),
        new Plans("Master", 5, 3500, true, 5000.00, true)
        };

        public List<Plans> GetMockPlans()
        {
            return new List<Plans>(PlansList);
        }


    }
}
