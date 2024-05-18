using QuikyMart.Data.Entites.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikyMart.Service.OrderServices.OrderDtos
{
    public class OrderDTO
    {
        public string BasketId { get; set; }
        public string BuyerEmail { get; set; }

        public int DeliveryMethodId { get; set; }

        public ShippingAddressDTO ShippingAddress { get; set; }

    }
}
