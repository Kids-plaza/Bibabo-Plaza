using System;
using System.Collections.Generic;

namespace Test.Models;

public partial class OrderDetail
{
    public Guid id { get; set; }

    public int quantity { get; set; }

    public double price { get; set; }

    public Guid order_id { get; set; }

    public Guid product_id { get; set; }

    public DateTime created_on { get; set; }

    public bool is_deleted { get; set; }

    public virtual Order order { get; set; } = null!;

    public virtual Product product { get; set; } = null!;
}
