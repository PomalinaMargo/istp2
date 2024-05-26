﻿using System;
using System.Collections.Generic;

namespace MachineryShop.Model;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Device> Devices { get; set; } = new List<Device>();
}
