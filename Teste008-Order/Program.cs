using System;
using System.Globalization;

namespace Teste008_Order
{
    class Program
    {
        static void Main(string[] args)
        {
            Client c = new Client();
            Order o = new Order();

            Console.WriteLine("Enter cliente data: ");
            Console.Write("Name: ");
            c.Name = Console.ReadLine();
            Console.Write("Email: ");
            c.Email = Console.ReadLine();
            Console.Write("Birth date (DD/MM/YYYY): ");
            c.BirthDate = DateTime.Parse(Console.ReadLine());
            o.Client = c;

            Console.WriteLine();
            Console.WriteLine("Enter order data:");
            Console.Write("Status: ");
            o.Moment = DateTime.Now;
            o.Status = Enum.Parse<OrderStatus>(Console.ReadLine());
            Console.Write("How many items to this order? ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Product p = new Product();
                OrderItem oi = new OrderItem();

                Console.WriteLine();
                Console.WriteLine($"Enter #{i} item data: ");
                Console.Write("Product name: ");
                p.Name = Console.ReadLine();
                Console.Write("Product price: ");
                p.Price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                oi.Product = p;
                oi.Price = p.Price;
                Console.Write("Quantity: ");
                oi.Quantity = int.Parse(Console.ReadLine());

                o.AddItem(oi);
            }

            Console.WriteLine();
            Console.WriteLine("ORDER SUMMARY:");
            Console.WriteLine(o);

        }
    }
}
