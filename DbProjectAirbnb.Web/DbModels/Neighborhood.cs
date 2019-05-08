using System.Collections.Generic;

namespace DbProjectAirbnb.Web.Model
{
    public class Neighborhood
    {
        public Neighborhood()
        {
            Hosts = new HashSet<Host>();
            Listings = new HashSet<Listing>();
        }

        public decimal Id { get; set; }
        public string Name { get; set; }
        public decimal CityId { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<Host> Hosts { get; set; }
        public virtual ICollection<Listing> Listings { get; set; }
    }
}
