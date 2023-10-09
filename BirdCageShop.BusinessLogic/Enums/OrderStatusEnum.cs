﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdCageShop.BusinessLogic.Enums
{
    public enum OrderStatusEnum
    {
        Pending = 1, 
        Processing = 2,
        Shipped = 3,
        Delivered = 4,
        Cancelled = 5,
    }
}
