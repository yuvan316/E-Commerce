using System;
using System.Collections.Generic;

namespace Ecommerce_Repository.DBContext.Core
{
    public partial class Product
    {
        public Product()
        {
            Images = new HashSet<Image>();
            OrderItems = new HashSet<OrderItem>();
            Reviews = new HashSet<Review>();
        }

        public int ProductId { get; set; }
        public int? CategoryId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string? Sku { get; set; }

        public virtual Category? Category { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
