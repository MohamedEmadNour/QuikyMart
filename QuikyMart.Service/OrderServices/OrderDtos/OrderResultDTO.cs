using QuikyMart.Data.Entites.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikyMart.Service.OrderServices.OrderDtos
{
    public class OrderResultDTO
    {
        public int Id { get; set; }
        public string BuyerEmail { get; set; }

        public DateTime CreatedTime { get; set; }

        public ShippingAddressDTO ShippingAddress { get; set; }

        public string deliveryMethodName { get; set; }

        public OrderStatus Status { get; set; }

        public IReadOnlyList<OrderItemDTO> orderItemDTOs { get; set; }

        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
        public decimal ShippingPrice { get; set; }

        public string PaymentIntentID { get; set; }
    }
}
