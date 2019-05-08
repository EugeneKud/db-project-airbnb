using System;
using System.Collections.Generic;

namespace DbProjectAirbnb.Web.Model
{
    public partial class ListingsHaveAmenityTypes
    {
        public decimal ListingId { get; set; }
        public decimal AmenityTypeId { get; set; }

        public virtual AmenityTypes AmenityType { get; set; }
        public virtual Listings Listing { get; set; }
    }
}
