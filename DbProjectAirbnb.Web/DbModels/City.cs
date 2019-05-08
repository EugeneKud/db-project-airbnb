using System;
using System.Collections.Generic;

namespace DbProjectAirbnb.Web.Model
{
    public partial class City
    {
        public City()
        {
            Neighborhoods = new HashSet<Neighborhood>();
        }

        public decimal Id { get; set; }
        public string Name { get; set; }
        public decimal? CountryId { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<Neighborhood> Neighborhoods { get; set; }
    }
}
