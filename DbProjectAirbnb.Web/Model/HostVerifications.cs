using System;
using System.Collections.Generic;

namespace DbProjectAirbnb.Web.Model
{
    public partial class HostVerifications
    {
        public HostVerifications()
        {
            HostsHaveHostVerifications = new HashSet<HostsHaveHostVerifications>();
        }

        public decimal Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<HostsHaveHostVerifications> HostsHaveHostVerifications { get; set; }
    }
}
