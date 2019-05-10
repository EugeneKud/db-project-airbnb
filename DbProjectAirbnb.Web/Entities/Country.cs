using System.Collections.Generic;

namespace DbProjectAirbnb.Web.Entities
{
    public class Country
    {
        public Country()
        {
            Cities = new HashSet<City>();
        }

        public decimal Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}
