using ECommerce.DataAccess.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Models
{
    public class OrderModel
    {
        public Order Order { get; set; }
        public decimal Total { get; set; }

        public OrderModel(Order order)
        {
            Order= order;
            Total = Order.Product.Price * Order.Amount;
        }
    }
}
