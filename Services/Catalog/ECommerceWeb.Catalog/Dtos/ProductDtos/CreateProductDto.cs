﻿namespace ECommerceWeb.Catalog.Dtos.ProductDtos
{
    public class CreateProductDto
    {
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductImageUrl { get; set; }
        public string ProductDesciption { get; set; }
        public string CategoryId { get; set; }
    }
}