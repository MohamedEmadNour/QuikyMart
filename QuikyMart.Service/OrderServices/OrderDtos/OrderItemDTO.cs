using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikyMart.Service.OrderServices.OrderDtos
{
    public class OrderItemDTO
    {
        public int OrderID { get; set; }
        public int ProductNameId { get; set; }
        public string ProductName { get; set; }
        public string PictureURL { get; set; }
        public decimal Price { get; set; }
        public int Quntity { get; set; }
    }
}
