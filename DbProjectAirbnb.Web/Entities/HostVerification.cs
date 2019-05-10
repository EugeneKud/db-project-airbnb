using System.Collections.Generic;

namespace DbProjectAirbnb.Web.Entities
{
    public class HostVerification
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
