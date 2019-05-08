using System;
using System.Collections.Generic;

namespace DbProjectAirbnb.Web.Model
{
    public class Availability
    {
        public decimal Id { get; set; }
        public DateTime Date { get; set; }
        public decimal ListingId { get; set; }
        public bool Available { get; set; }
        public decimal? Price { get; set; }

        public virtual Listing Listing { get; set; }
    }
}
