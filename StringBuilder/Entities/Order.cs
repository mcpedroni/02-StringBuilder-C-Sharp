using System;
using System.Collections.Generic;
using System.Text;
using Orders.Enums;
using System.Globalization;

namespace Orders.Entities {

    class Order {

        public DateTime moment { get; set; }
        public OrderStatus status { get; set; }
        public List<OrderItem> orderItens { get; set; } = new List<OrderItem>();
        public Client client { get; set; } 

        public Order() { }

        public Order(DateTime moment, OrderStatus status, Client client) {
            this.moment = moment;
            this.status = status;
            this.client = client;
        }

        public void AddItem(OrderItem orderItem) {
            orderItens.Add(orderItem);
        }

        public void RemoveItem(OrderItem orderItem) {
            orderItens.Remove(orderItem);
        }

        public double Total() {
            double sum = 0.0;
            foreach (OrderItem oi in orderItens) {
                sum += oi.SubTotal();
            }
            return sum;
        }

        public override string ToString() {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("ORDER SUMARY:");
            sb.AppendLine("Order moment: " + moment);
            sb.AppendLine("Order status: " + status);
            sb.AppendLine("Client: " + client);
            sb.AppendLine("Order items: ");
            foreach (OrderItem order in orderItens) {
                sb.AppendLine(order.ToString());
            }
            sb.AppendLine("Total price: $" + Total().ToString("F2", CultureInfo.InvariantCulture));

            return sb.ToString();
        }
    }
}
