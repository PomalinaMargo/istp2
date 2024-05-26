using System;
using System.Collections.Generic;

namespace MachineryShop.Model;

public partial class Order
{
    public int Id { get; set; }

    public int? Deviceid { get; set; }

    public int? Userid { get; set; }

    public virtual Device? Device { get; set; } 

    public virtual User? User { get; set; } 
}
