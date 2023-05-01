using LEGOINNOVATIVE.MockData;
using LEGOINNOVATIVE.Model;

namespace LEGOINNOVATIVE.Services
{
    public class OrderService : IOrderService
    {
        private MockOrders _mockOrders = new MockOrders();

        private readonly List<Order> _order;

        public void Add(Order order)
        {
            _mockOrders.Add(order);
        }
        public Order FindOrder(int id)
        {
            Order o = _order.Find(o => o.Id == id);
            if (o is not null)
            {
                return o;
            }
            throw new KeyNotFoundException();
        }

        public void DeleteOrder(int id)
        {
            Order order = FindOrder(id);
            _order.Remove(order);
        }

        public List<Order> GetOrders()
        {
            return _mockOrders.GetMockOrders();
        }

        public void EditOrder(int id, Order newValues)
        {
            var order = _order.Find(o => o.Id == id);
            _mockOrders.EditOrder(newValues);
        }
    }
}