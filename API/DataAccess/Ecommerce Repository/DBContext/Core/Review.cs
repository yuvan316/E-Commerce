using System;
using System.Collections.Generic;

namespace Ecommerce_Repository.DBContext.Core
{
    public partial class Review
    {
        public int ReviewId { get; set; }
        public int? ProductId { get; set; }
        public int? UserId { get; set; }
        public int Rating { get; set; }
        public string? Comments { get; set; }

        public virtual Product? Product { get; set; }
    }
}
