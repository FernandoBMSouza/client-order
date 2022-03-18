using System;
using System.Collections.Generic;
using System.Text;
using Project.Entities.Enums;
using System.Globalization;

namespace Project.Entities
{
    class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public Client Client { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public Order()
        {
        }
        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = moment;
            Status = status;
            Client = client;
        }

        public void AddOrderItem(OrderItem orderItem)
        {
            OrderItems.Add(orderItem);
        }
        public void RemoveOrderItem(OrderItem orderItem)
        {
            OrderItems.Remove(orderItem);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Order moment: {Moment}");
            sb.AppendLine($"Order status: {Status}");
            sb.AppendLine($"Client: {Client.Name} ({Client.BirthDate}) - {Client.Email}");
            sb.AppendLine("Order items:");
            double sum = 0;
            foreach(OrderItem oi in OrderItems)
            {
                sb.AppendLine(oi.ToString());
                sum += oi.SubTotal();
            }
            sb.AppendLine($"Total price: ${sum.ToString("F2", CultureInfo.InvariantCulture)}");
            return sb.ToString();
        }
    }
}