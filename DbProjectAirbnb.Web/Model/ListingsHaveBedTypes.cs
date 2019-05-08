using System;
using System.Collections.Generic;

namespace DbProjectAirbnb.Web.Model
{
    public partial class ListingsHaveBedTypes
    {
        public decimal ListingId { get; set; }
        public decimal BedTypeId { get; set; }
        public byte? Amount { get; set; }

        public virtual BedTypes BedType { get; set; }
        public virtual Listings Listing { get; set; }
    }
}
