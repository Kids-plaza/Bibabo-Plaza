using System;
using System.Collections.Generic;

namespace Test.Models;

public partial class Order
{
    public Guid id { get; set; }

    public double total_price { get; set; }

    public int total_quantity { get; set; }

    public int order_status { get; set; }

    public Guid customer_id { get; set; }

    public DateTime created_on { get; set; }

    public bool is_deleted { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual Account customer { get; set; } = null!;
}
