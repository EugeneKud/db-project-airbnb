using System;
using System.Collections.Generic;

namespace DbProjectAirbnb.Web.Model
{
    public partial class Hosts
    {
        public Hosts()
        {
            HostsHaveHostVerifications = new HashSet<HostsHaveHostVerifications>();
            Listings = new HashSet<Listings>();
        }

        public decimal Id { get; set; }
        public string About { get; set; }
        public decimal NeighborhoodId { get; set; }
        public string PictureUrl { get; set; }
        public string ResponseRate { get; set; }
        public string ResponseTime { get; set; }
        public DateTime Since { get; set; }
        public string ThumbnailUrl { get; set; }
        public string Url { get; set; }

        public virtual Users IdNavigation { get; set; }
        public virtual Neighborhoods Neighborhood { get; set; }
        public virtual ICollection<HostsHaveHostVerifications> HostsHaveHostVerifications { get; set; }
        public virtual ICollection<Listings> Listings { get; set; }
    }
}
