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

        public int MaxPageIndex { get; set; } = 50;

        public int pageIndex { get; set; } = 1;

        private int _pageSize = 5;

        public int pageSize
        {
            get => _pageSize;
            set { _pageSize = value > MaxPageIndex ? MaxPageIndex : value; }
        }

        private string? _search;

        public string? Search
        {
            get { return _search; }
            set { _search = value.ToLower(); }
        }


    }
}
