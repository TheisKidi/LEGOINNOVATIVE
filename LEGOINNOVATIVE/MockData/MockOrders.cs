using LEGOINNOVATIVE.Model;

namespace LEGOINNOVATIVE.MockData
{
    public class MockOrders
    {
        private static List<Order> orderList = new List<Order>();

        public List<Order> GetMockOrders()
        {
            return new List<Order>(orderList);
        }

        public void Add(Order order)
        {
            orderList.Add(order);
        }

        public Order FindOrder(int id)
        {
            foreach(Order o in orderList)
            {
                if (o.Id == id)
                {
                    return o;
                }
            }
            throw new KeyNotFoundException();
        }

        public void EditOrder(Order newValues)
        {
            Order editOrder = FindOrder(newValues.Id);

            editOrder.Title = newValues.Title;
            editOrder.Description = newValues.Description;
            editOrder.Publish = newValues.Publish;
            editOrder.Plan = newValues.Plan;
        }

        public void Delete(int id)
        {
            Order deleteOrder = FindOrder(id);

            orderList.Remove(deleteOrder);
        }

    }
}
