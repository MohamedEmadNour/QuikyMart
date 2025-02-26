﻿using QuikyMart.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikyMart.Service.Dtos
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string PictureUrl { get; set; }

        public string Brand { get; set; }

        public int BrandId { get; set; }

        public string Type { get; set; }

        public int TypeId { get; set; }
    }
}
