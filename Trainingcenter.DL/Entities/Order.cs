﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Trainingcenter.DL.Entities
{
    public class Order
    {
        public string OrderId { get; set; }
        public int UserId { get; set; }

        public string Exchange { get; set; }
        public string Symbol { get; set; }
        public bool Side { get; set; }
        public double OrderQty { get; set; }
        public string Currency { get; set; }
        public double Price { get; set; }
        public DateTime Timestamp { get; set; }
        
        public User User { get; set; }
    }
}
