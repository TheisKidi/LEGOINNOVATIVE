using LEGOINNOVATIVE.Model;

namespace LEGOINNOVATIVE.Services
{
    public interface IOrderService
    {
        public List<Order> GetOrders();
        public void Add(Order order);
        public Order FindOrder(int id);
        public void DeleteOrder(int id);
        public void EditOrder(int id, Order newValues);
    }
}
