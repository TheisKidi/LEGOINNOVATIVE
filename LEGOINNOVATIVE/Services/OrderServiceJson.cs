using LEGOINNOVATIVE.MockData;
using LEGOINNOVATIVE.Model;
using System.Text.Json;

namespace LEGOINNOVATIVE.Services
{
    public class OrderServiceJson : IOrderService
    {
        private const string fileDir = @"../";
        private const string fileName = fileDir + "Order.json";

        private readonly List<Order> _order;

        public OrderServiceJson()
        {
            _order = ReadFromJson();
        }

        public void Add(Order order)
        {
            _order.Add(order);
            SaveToJson();
        }

        public void DeleteOrder(int id)
        {
            Order order = FindOrder(id);
            _order.Remove(order);
            SaveToJson();
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

        public List<Order> GetOrders()
        {
            return new List<Order>(_order);
        }

        private List<Order> ReadFromJson()
        {
            if (File.Exists(fileName))
            {
                using(var file = File.OpenText(fileName))
                {
                    string json = file.ReadToEnd();
                    return JsonSerializer.Deserialize<List<Order>>(json);
                }
            }
            return new List<Order>();
        }

        private void SaveToJson()
        {
            string json = JsonSerializer.Serialize(_order);
            File.WriteAllText(fileName, json);
        }

        public void EditOrder(int id, Order newValues)
        {
            var order = FindOrder(newValues.Id);

            order.Title = newValues.Title;
            order.Description = newValues.Description;
            order.Publish = newValues.Publish;
            order.Plan = newValues.Plan;
            order.Accepted = newValues.Accepted;
            order.Completed = newValues.Completed;

            SaveToJson();
        }
    }
}
