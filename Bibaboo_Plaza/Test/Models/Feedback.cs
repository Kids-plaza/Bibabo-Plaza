using System;
using System.Collections.Generic;

namespace Test.Models;

public partial class Feedback
{
    public Guid id { get; set; }

    public string content { get; set; } = null!;

    public Guid customer_id { get; set; }

    public Guid product_id { get; set; }

    public DateTime created_on { get; set; }

    public bool is_deleted { get; set; }

    public virtual Account customer { get; set; } = null!;

    public virtual Product product { get; set; } = null!;
}
