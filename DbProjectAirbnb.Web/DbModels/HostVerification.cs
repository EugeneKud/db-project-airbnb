using System;
using System.Collections.Generic;

namespace DbProjectAirbnb.Web.Model
{
    public partial class HostVerification
    {
        public HostVerification()
        {
            HostsHaveHostVerifications = new HashSet<HostHasHostVerification>();
        }

        public decimal Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<HostHasHostVerification> HostsHaveHostVerifications { get; set; }
    }
}
