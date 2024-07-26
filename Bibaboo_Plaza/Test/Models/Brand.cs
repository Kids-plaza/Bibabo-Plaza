using System;
using System.Collections.Generic;

namespace Test.Models;

public partial class Brand
{
    public Guid id { get; set; }

    public string brand_name { get; set; } = null!;

    public string brand_address { get; set; } = null!;

    public string brand_phone { get; set; } = null!;

    public string description { get; set; } = null!;

    public DateTime created_on { get; set; }

    public bool is_deleted { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
