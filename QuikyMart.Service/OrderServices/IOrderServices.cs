using QuikyMart.Data.Entites.Order;
using QuikyMart.Service.OrderServices.OrderDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikyMart.Service.OrderServices
{
    public interface IOrderServices
    {
        Task<OrderResultDTO> CreateOrderAsync(OrderDTO orderDTO);
        Task<IReadOnlyList<OrderResultDTO>> GetAllOrderAsync(string BuyerEmail);
        Task <OrderResultDTO> GetOrderAsync(int id ,string BuyerEmail);

        Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync(); 
    }
}
