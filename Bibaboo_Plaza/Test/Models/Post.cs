using System;
using System.Collections.Generic;

namespace Test.Models;

public partial class Post
{
    public Guid id { get; set; }

    public string title { get; set; } = null!;

    public string content { get; set; } = null!;

    public Guid staff_id { get; set; }

    public DateTime created_on { get; set; }

    public bool is_deleted { get; set; }

    public virtual Account staff { get; set; } = null!;
}
