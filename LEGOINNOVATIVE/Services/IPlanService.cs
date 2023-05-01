using LEGOINNOVATIVE.Model;

namespace LEGOINNOVATIVE.Services
{
    public interface IPlanService
    {
        public List<Plans> GetPlans();

        public Plans FindPlan(string type);


    }
}
