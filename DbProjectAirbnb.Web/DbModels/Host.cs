using System;
using System.Collections.Generic;

namespace DbProjectAirbnb.Web.Model
{
    public class Host
    {
        public Host()
        {
            HostsHaveHostVerifications = new HashSet<HostHasHostVerification>();
            Listings = new HashSet<Listing>();
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

        public virtual User IdNavigation { get; set; }
        public virtual Neighborhood Neighborhood { get; set; }
        public virtual ICollection<HostHasHostVerification> HostsHaveHostVerifications { get; set; }
        public virtual ICollection<Listing> Listings { get; set; }
    }
}
