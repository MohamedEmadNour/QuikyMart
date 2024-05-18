using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuikyMart.Data.Entites.Order;
using QuikyMart.Repositores.Interfaces;
using QuikyMart.Service.ExceptionsHandeling;
using QuikyMart.Service.OrderServices;
using QuikyMart.Service.OrderServices.OrderDtos;
using StackExchange.Redis;
using System.Security.Claims;

namespace QuikyMart.Api.Controllers
{
    [Authorize]
    public class OrderController : BaseCont
    {



        private readonly IOrderServices _orderServices;

        public OrderController(
            IOrderServices orderServices
            )
        {
            _orderServices = orderServices;
        }



        [HttpPost]
        public async Task<ActionResult<OrderResultDTO>> CreateOrderAsync(OrderDTO orderDTO)
        {
            var order = _orderServices.CreateOrderAsync( orderDTO );
            if (order is null)
                return BadRequest(new ApiResponse(400, "Error while create order"));

            return Ok(order);
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<OrderResultDTO>>> GetOrderForUser()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);

            var orders = await _orderServices.GetAllOrderAsync(email);
            if (orders.Count <= 0)
                return BadRequest(new ApiResponse(404, "U dont have any order yet"));

            return Ok(orders);

        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<OrderResultDTO>>> GetOrderForUserById(int id)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);

            var order = await _orderServices.GetOrderAsync(id ,email);

            if (order is null)
                return BadRequest(new ApiResponse(404, "U dont have any order yet"));

            return Ok(order);
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<DeliveryMethod>>> GetDeliviryMethod()
            => Ok(await _orderServices.GetDeliveryMethodsAsync());
    }
}
