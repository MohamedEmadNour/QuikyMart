using QuikyMart.Data.Entites.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QuikyMart.Repositores.Specifications.OrderSpecificationProfile
{
    public class OrderWithItemSpec : BaseSpecification<OrderR>
    {
        public OrderWithItemSpec(string buyerEmail) : base
            (
                order => order.BuyerEmail == buyerEmail
            )
        {
            AddIncludes(order => order.Items);
            AddIncludes(order => order.deliveryMethod);
            OrderingDesc(order => order.CreatedTime);
        }

        public OrderWithItemSpec(int id ,string buyerEmail) : base
        (
            order => order.BuyerEmail == buyerEmail && order.Id == id
        )
            {
                AddIncludes(order => order.Items);
                AddIncludes(order => order.deliveryMethod);
            }
    }
}
