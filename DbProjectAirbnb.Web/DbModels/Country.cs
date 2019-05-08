using System;
using System.Collections.Generic;

namespace DbProjectAirbnb.Web.Model
{
    public partial class Country
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
