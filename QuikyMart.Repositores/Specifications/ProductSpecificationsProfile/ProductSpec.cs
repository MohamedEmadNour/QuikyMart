using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace QuikyMart.Repositores.Specifications.ProductSpecificationsProfile
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ProductSortCasses
    {
        Price , PriceDesc , Name , NameDesc
    }
    public class ProductSpec
    {
        public int? BrandId { get; set; }
        public int? TypeId { get; set; }
        public ProductSortCasses? Sort { get; set; }
    }
}
