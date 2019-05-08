using System;
using System.Collections.Generic;

namespace DbProjectAirbnb.Web.Model
{
    public partial class HostsHaveHostVerifications
    {
        public decimal HostId { get; set; }
        public decimal HostVerificationId { get; set; }

        public virtual Hosts Host { get; set; }
        public virtual HostVerifications HostVerification { get; set; }
    }
}
