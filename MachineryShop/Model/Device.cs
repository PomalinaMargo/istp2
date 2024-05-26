using System;
using System.Collections.Generic;

namespace MachineryShop.Model;

public partial class Device
{
    public int Id { get; set; }

    public int Categoryid { get; set; }

    public string? Name { get; set; } 

    public int Cost { get; set; }

    public string? Description { get; set; } 

    public virtual Category? Category { get; set; } 

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
