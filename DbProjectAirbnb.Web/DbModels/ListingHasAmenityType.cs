using System;
using System.Collections.Generic;

namespace DbProjectAirbnb.Web.Model
{
    public partial class ListingHasAmenityType
    {
        public decimal ListingId { get; set; }
        public decimal AmenityTypeId { get; set; }

        public virtual AmenityType AmenityType { get; set; }
        public virtual Listing Listing { get; set; }
    }
}
