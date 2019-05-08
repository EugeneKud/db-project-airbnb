using System;
using System.Collections.Generic;

namespace DbProjectAirbnb.Web.Model
{
    public partial class BedTypes
    {
        public BedTypes()
        {
            Listings = new HashSet<Listings>();
            ListingsHaveBedTypes = new HashSet<ListingsHaveBedTypes>();
        }

        public decimal Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Listings> Listings { get; set; }
        public virtual ICollection<ListingsHaveBedTypes> ListingsHaveBedTypes { get; set; }
    }
}
