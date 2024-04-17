using QuikyMart.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikyMart.Repositores.Specifications.ProductSpecificationsProfile
{
    public class ProductWithSpecification : BaseSpecification<Product>
    {
        public ProductWithSpecification(ProductSpec Specs) 
            : base
            (
                  product => ( !Specs.BrandId.HasValue || product.BrandId == Specs.BrandId.Value ) &&
                             (!Specs.TypeId.HasValue || product.TypeId == Specs.TypeId.Value)
            )       
        {
            AddIncludes(P => P.Brand);
            AddIncludes(P => P.Type);
            Ordering(P => P.Name);

            if (Specs.Sort is not null)
            {
                switch (Specs.Sort)
                {
                    case ProductSortCasses.Name:
                        Ordering(P => P.Name);
                        break;
                    case ProductSortCasses.NameDesc:
                        OrderingDesc(P => P.Name);
                        break;
                    case ProductSortCasses.Price:
                        Ordering(P => P.Price);
                        break;
                    case ProductSortCasses.PriceDesc:
                        OrderingDesc(P => P.Price);
                        break;

                    default:
                        Ordering(P => P.Name);
                        break;
                }

            }


        }

        public ProductWithSpecification(int id) : base (product => product.Id == id)
        {
            AddIncludes(P => P.Brand);
            AddIncludes(P => P.Type);
        }
    }
}
