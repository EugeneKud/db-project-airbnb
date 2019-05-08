using System;
using System.Collections.Generic;

namespace DbProjectAirbnb.Web.Model
{
    public class AmenityType
    {
        public AmenityType()
        {
            ListingsHaveAmenityTypes = new HashSet<ListingHasAmenityType>();
        }

        public decimal Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ListingHasAmenityType> ListingsHaveAmenityTypes { get; set; }
    }
}
