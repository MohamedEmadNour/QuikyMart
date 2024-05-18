using AutoMapper;
using QuikyMart.Data.Entites;
using QuikyMart.Data.Entites.Order;
using QuikyMart.Repositores.Interfaces;
using QuikyMart.Repositores.Specifications.OrderSpecificationProfile;
using QuikyMart.Service.OrderServices.OrderDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikyMart.Service.OrderServices
{
    public class OrderServices : IOrderServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBasketReopsitories _BasketReopsitories;
        private readonly IMapper _mapper;

        public OrderServices(
            IUnitOfWork unitOfWork,
            IBasketReopsitories basketReopsitories,
            IMapper mapper
            )
        {
            _unitOfWork = unitOfWork;
            _BasketReopsitories = basketReopsitories;
            _mapper = mapper;
        }


        public async Task<OrderResultDTO> CreateOrderAsync(OrderDTO Order)
        {
            var basket = await _BasketReopsitories.GetBasket(Order.BasketId);
            if (basket is null ) return null;

            var order = new List<OrderItemDTO>();

            foreach (var item in basket.Items)
            {
                var productItem = await _unitOfWork.repositories<Product, int>().GetByIdAsync(item.Id);
                if (productItem is null) return null;

                var orderItem = new OrderItem()
                {
                    ProductId = productItem.Id,
                    ProductName = productItem.Name,
                    PictureURL = productItem.PictureUrl,
                    Price = productItem.Price,
                    Quntity = item.Quantity,
                };

                var MappedOrderItem = _mapper.Map<OrderItemDTO>(orderItem);

                order.Add(MappedOrderItem);

                
            }
            var deliviryMethod = await _unitOfWork.repositories<DeliveryMethod, int>().GetByIdAsync(Order.DeliveryMethodId);

            if (deliviryMethod is null) return null;

            var SubTotal = order.Sum(It => It.Quntity * It.Price);


            var ShipAddMap = _mapper.Map<ShippingAddress>(Order.ShippingAddress);
            var mappedOrderItem = _mapper.Map<List<OrderItem>>(order);

            var orderR = new OrderR
            {
                deliveryMethodID = deliviryMethod.Id,
                ShippingAddress = ShipAddMap,
                BuyerEmail = Order.BuyerEmail,
                Items = mappedOrderItem,
                SubTotal = SubTotal,
            };

            await _unitOfWork.repositories<OrderR, int>().AddAsync(orderR);

            await _unitOfWork.CompleteAsync();

            return _mapper.Map<OrderResultDTO>(orderR);

        }

        public async Task<IReadOnlyList<OrderResultDTO>> GetAllOrderAsync(string BuyerEmail)
        {
            var spec = new OrderWithItemSpec(BuyerEmail);

            var orders = await _unitOfWork.repositories<OrderR,int>().GetAllWithSpecificatioAsync(spec);

            var mappedOrders = _mapper.Map<List<OrderResultDTO>>(orders);

            return mappedOrders;
        }



        public async Task<OrderResultDTO> GetOrderAsync(int id, string BuyerEmail)
        {
            var spec = new OrderWithItemSpec(id, BuyerEmail);

            var orders = await _unitOfWork.repositories<OrderR, int>().GetByIdWithSpecificatioAsync(spec);

            var mappedOrders = _mapper.Map<OrderResultDTO>(orders);

            return mappedOrders;
        }



        public async Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync()
            => await _unitOfWork.repositories<DeliveryMethod, int>().GetAllAsync();
    }
}
