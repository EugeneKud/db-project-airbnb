﻿using System;
using System.Collections.Generic;

namespace DbProjectAirbnb.Web.Model
{
    public partial class RoomTypes
    {
        public RoomTypes()
        {
            Listings = new HashSet<Listings>();
        }

        public decimal Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Listings> Listings { get; set; }
    }
}
