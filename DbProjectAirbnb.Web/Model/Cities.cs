using System;
using System.Collections.Generic;

namespace DbProjectAirbnb.Web.Model
{
    public partial class Cities
    {
        public Cities()
        {
            Neighborhoods = new HashSet<Neighborhoods>();
        }

        public decimal Id { get; set; }
        public string Name { get; set; }
        public decimal? CountryId { get; set; }

        public virtual Countries Country { get; set; }
        public virtual ICollection<Neighborhoods> Neighborhoods { get; set; }
    }
}
