using System;
using System.Collections.Generic;

namespace DbProjectAirbnb.Web.Model
{
    public partial class Neighborhoods
    {
        public Neighborhoods()
        {
            Hosts = new HashSet<Hosts>();
            Listings = new HashSet<Listings>();
        }

        public decimal Id { get; set; }
        public string Name { get; set; }
        public decimal CityId { get; set; }

        public virtual Cities City { get; set; }
        public virtual ICollection<Hosts> Hosts { get; set; }
        public virtual ICollection<Listings> Listings { get; set; }
    }
}
