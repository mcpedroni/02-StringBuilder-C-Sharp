using System;
using Orders.Entities;
using Orders.Enums;
using System.Globalization;

namespace Orders {

    class Program {

        static void Main(string[] args) {

            Console.WriteLine("Enter client data: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth date(dd/mm/yyyy): ");
            DateTime dateBirth = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter order data: ");
            Console.Write("Status (PENDING_PAYMENT/PROCESSING/SHIPPED/DELIVERED): ");
            OrderStatus orderStatus;
            if (!Enum.TryParse<OrderStatus>(Console.ReadLine(), out orderStatus))
                throw new Exception("Value is not valid member of enumeration OrderStatus enum.");

            Client client = new Client(name, email, dateBirth);
            Order order = new Order(DateTime.Now, orderStatus, client);

            Console.Write("How many items to this order? ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++) {
                Console.WriteLine("Enter #" + i + " item data:");
                Console.Write("Product name: ");
                string nameProduct = Console.ReadLine();
                Console.Write("Product price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Product product = new Product(nameProduct, price);

                Console.Write("Quantity: ");
                int quant = int.Parse(Console.ReadLine());

                OrderItem orderItem = new OrderItem(quant, price, product);

                order.AddItem(orderItem);
            }

            Console.WriteLine();
            Console.WriteLine(order);
        }
    }
}
