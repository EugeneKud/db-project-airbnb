using System;
using System.Collections.Generic;

namespace DbProjectAirbnb.Web.Model
{
    public partial class AmenityTypes
    {
        public AmenityTypes()
        {
            ListingsHaveAmenityTypes = new HashSet<ListingsHaveAmenityTypes>();
        }

        public decimal Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ListingsHaveAmenityTypes> ListingsHaveAmenityTypes { get; set; }
    }
}
