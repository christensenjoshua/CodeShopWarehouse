using System;
using System.Collections.Generic;
using System.Text;

namespace CodeShopWarehouse.Entities.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int QuantityMod { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? ProcessedAt { get; set; }
    }
}
