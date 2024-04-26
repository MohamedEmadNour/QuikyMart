using QuikyMart.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikyMart.Repositores.Interfaces
{
    public interface IBasketReopsitories
    {
        Task<CustomerBasket> GetBasket(string BasketId);
        Task<CustomerBasket> UpdateOrCreateBasket(CustomerBasket Basket);
        Task<bool> DeleteBasket (string BasketId);

    }
}
