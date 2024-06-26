﻿namespace ASP.NET_CORE_WEB_API_CRUD_OPERATION.Data.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; } = null!;
        public int Qty { get; set; }
        public decimal Price { get; set; }

        public virtual Category Category { get; set; } = null!;
    }
}
