using System;
using System.Collections.Generic;

namespace DbProjectAirbnb.Web.Model
{
    public partial class ListingHasBedType
    {
        public decimal ListingId { get; set; }
        public decimal BedTypeId { get; set; }
        public byte? Amount { get; set; }

        public virtual BedType BedType { get; set; }
        public virtual Listing Listing { get; set; }
    }
}
