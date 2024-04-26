using QuikyMart.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QuikyMart.Repositores.Specifications.ProductSpecificationsProfile
{
    public class ProductCountSpic : BaseSpecification<Product>
    {
        public ProductCountSpic(ProductSpec Specs)
            : base
            (
                  product => (!Specs.BrandId.HasValue || product.BrandId == Specs.BrandId.Value) &&
                             (!Specs.TypeId.HasValue || product.TypeId == Specs.TypeId.Value)
            )
        {
        }
    }
}
