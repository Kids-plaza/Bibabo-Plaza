using System;
using System.Collections.Generic;

namespace Test.Models;

public partial class Product
{
    public Guid id { get; set; }

    public string product_name { get; set; } = null!;

    public double price { get; set; }

    public string description { get; set; } = null!;

    public string img_url { get; set; } = null!;

    public int quantity { get; set; }

    public int status { get; set; }

    public Guid brand_id { get; set; }

    public DateTime created_on { get; set; }

    public bool is_deleted { get; set; }

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual Brand brand { get; set; } = null!;
}
