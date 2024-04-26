using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikyMart.Data.Entites
{
    public class CustomerBasket
    {
        public CustomerBasket(string id)
        {
            Id = id;
            Items = new List<BaskitItem>() ;
        }

        public string Id { get; set; }
        public List<BaskitItem> Items { get; set; }
    }
}
