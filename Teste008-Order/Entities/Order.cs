using System;
using System.Globalization;
using System.Collections.Generic;
using System.Text;

namespace Teste008_Order
{
    class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public Client Client { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public Order()
        {
        }

        public Order(DateTime moment, OrderStatus status)
        {
            Moment = moment;
            Status = status;
        }

        public void AddItem (OrderItem orderItem)
        {
            Items.Add(orderItem);
        }

        public void RemoveItem (OrderItem orderItem)
        {
            Items.Remove(orderItem);
        }

        public double Total()
        {
            double sum = 0;

            foreach (OrderItem o in Items)
            {
                sum += o.SubTotal();
            }

            return sum;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Order Moment: " + Moment);
            sb.AppendLine("Order Status: " + Status.ToString());
            sb.AppendLine("Client: " + Client.Name + "(" + Client.BirthDate.ToString("dd/MM/yyyy") + ") - " + Client.Email);
            sb.AppendLine("Order Items: ");

            foreach (OrderItem oi in Items)
            {
                sb.Append(oi.Product.Name + ", ");
                sb.Append("Quantity: " + oi.Quantity + ", ");
                sb.AppendLine("SubTotal: $" + oi.SubTotal().ToString("F2", CultureInfo.InvariantCulture));
            }

            sb.AppendLine("Total proce: $" + Total().ToString("F2", CultureInfo.InvariantCulture));

            return sb.ToString();
        }
    }
}
