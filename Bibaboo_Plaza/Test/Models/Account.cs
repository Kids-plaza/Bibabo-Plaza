using System;
using System.Collections.Generic;

namespace Test.Models;

public partial class Account
{
    public Guid id { get; set; }

    public string email { get; set; } = null!;

    public string password { get; set; } = null!;

    public string fullname { get; set; } = null!;

    public string phone_number { get; set; } = null!;

    public string address { get; set; } = null!;

    public int status { get; set; }

    public int role { get; set; }

    public DateTime created_on { get; set; }

    public bool is_deleted { get; set; }

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();

    public virtual ICollection<Report> Reports { get; set; } = new List<Report>();
}
