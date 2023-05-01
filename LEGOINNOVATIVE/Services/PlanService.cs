using LEGOINNOVATIVE.MockData;
using LEGOINNOVATIVE.Model;

namespace LEGOINNOVATIVE.Services
{
    public class PlanService : IPlanService
    {

        private MockPlans _mockPlans = new MockPlans();
        public List<Plans> GetPlans()
        {
            return _mockPlans.GetMockPlans();
        }

        public Plans FindPlan(string type)
        {
            foreach (Plans p in _mockPlans.GetMockPlans())
            {
                if (type == p.Type)
                {
                    return p;
                }
            }
            throw new KeyNotFoundException();
        }

    }
}
