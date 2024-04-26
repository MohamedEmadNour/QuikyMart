using QuikyMart.Data.Entites;
using QuikyMart.Repositores.Interfaces;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace QuikyMart.Repositores.Repositories
{
    public class BasketReopsitories : IBasketReopsitories
    {
        private readonly IDatabase _connectionMultiplexer;

        public BasketReopsitories(IConnectionMultiplexer connectionMultiplexer)
        {
            _connectionMultiplexer = connectionMultiplexer.GetDatabase();
        }


        public async Task<CustomerBasket?> GetBasket(string BasketId)
        {
           var basket = await _connectionMultiplexer.StringGetAsync(BasketId);


            return basket.IsNullOrEmpty ? null : JsonSerializer.Deserialize<CustomerBasket>(basket);
        }

        public async Task<CustomerBasket> UpdateOrCreateBasket(CustomerBasket Basket)
        {
            var basket = await _connectionMultiplexer.StringSetAsync(Basket.Id , JsonSerializer.Serialize(Basket) , TimeSpan.FromDays(30));

            if (basket is false)
                return null;

            return await GetBasket(Basket.Id);

        }

        public async Task<bool> DeleteBasket(string BasketId)
        {
            return await _connectionMultiplexer.KeyDeleteAsync(BasketId);
        }
    }
}
