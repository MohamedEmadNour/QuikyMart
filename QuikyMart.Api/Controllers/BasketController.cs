using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuikyMart.Data.Entites;
using QuikyMart.Repositores.Interfaces;
using QuikyMart.Service.ExceptionsHandeling;

namespace QuikyMart.Api.Controllers
{
    [Authorize]
    public class BasketController : BaseCont
    {
        private readonly IBasketReopsitories _basketReopsitories;

        public BasketController(IBasketReopsitories basketReopsitories)
        {
            _basketReopsitories = basketReopsitories;
        }

        [HttpGet]
        public async Task<ActionResult<CustomerBasket>> GetBasket(string id)
        {
            var basket = await _basketReopsitories.GetBasket(id);
            return Ok(basket ?? new CustomerBasket(id));
        }

        [HttpPost]
        public async Task<ActionResult<CustomerBasket>> UpdateBasket(CustomerBasket basket)
        {
            var BasketCust = await _basketReopsitories.UpdateOrCreateBasket(basket);
            if (BasketCust != null)
            {
                return BadRequest(new ApiResponse(400));
            }

            return Ok(BasketCust);
        }

        [HttpDelete]
        public async void DeleteBasket(string id)
        {
            var BasketCust = await _basketReopsitories.DeleteBasket(id);
        }
    }
}
