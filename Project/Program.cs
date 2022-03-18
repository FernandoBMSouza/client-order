using System;
using System.Globalization;
using Project.Entities;
using Project.Entities.Enums;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Enter client data: ");

            System.Console.Write("Name: ");
            string name = Console.ReadLine();

            System.Console.Write("Email: ");
            string email = Console.ReadLine();

            System.Console.Write("Birth date (DD/MM/YYYY): ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());

            Client client = new Client(name, email, birthDate);

            System.Console.WriteLine("Enter order data: ");

            System.Console.Write("Status: ");
            OrderStatus orderStatus = Enum.Parse<OrderStatus>(Console.ReadLine());

            Order order = new Order(DateTime.Now, orderStatus, client);

            System.Console.Write("How many intems to this order? ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                System.Console.WriteLine($"Enter #{i} item data");

                System.Console.Write("Product name: ");
                string productName = Console.ReadLine();

                System.Console.Write("Product price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                System.Console.Write("Quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                Product product = new Product(productName, price);
                OrderItem orderItem = new OrderItem(quantity, price, product);
                order.AddOrderItem(orderItem);
            }

            System.Console.WriteLine("ORDER SUMMARY:");
            System.Console.WriteLine(order);
        }
    }
}
