﻿using System.Collections.Generic;

namespace DbProjectAirbnb.Web.Entities
{
    public class CancellationPolicy
    {
        public CancellationPolicy()
        {
            Listings = new HashSet<Listing>();
        }

        public decimal Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Listing> Listings { get; set; }
    }
}
