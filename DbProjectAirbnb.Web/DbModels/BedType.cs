using System;
using System.Collections.Generic;

namespace DbProjectAirbnb.Web.Model
{
    public class BedType
    {
        public BedType()
        {
            Listings = new HashSet<Listing>();
            ListingsHaveBedTypes = new HashSet<ListingHasBedType>();
        }

        public decimal Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Listing> Listings { get; set; }
        public virtual ICollection<ListingHasBedType> ListingsHaveBedTypes { get; set; }
    }
}
