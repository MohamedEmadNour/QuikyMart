using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikyMart.Data.Entites.Order
{
    public class OrderR : BaseEntity<int>
    {

        public OrderR(string buyerEmail, DeliveryMethod deliveryMethod, ICollection<OrderItem> items, decimal subTotal)
        {
            BuyerEmail = buyerEmail;
            this.deliveryMethod = deliveryMethod;
            Items = items;
            SubTotal = subTotal;
        }

        public OrderR()
        {
        }

        public string BuyerEmail { get; set; }

        public OrderStatus Status { get; set; } = OrderStatus.Pending;

        public ShippingAddress ShippingAddress { get; set; }        
        public int deliveryMethodID { get; set; }
        public DeliveryMethod deliveryMethod { get; set; }
        public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();

        public decimal SubTotal { get; set; }
    
        public decimal GetTotal() => SubTotal + deliveryMethod.Price;

        public string PaymentIntentID  { get; set; }


    }
}
