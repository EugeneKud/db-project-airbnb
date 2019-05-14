using System.Collections.Generic;
using System.Data;

namespace DbProjectAirbnb.Web.Models
{
    public class TablesToSearchMask
    {
        public string SearchText { get; set; }
        public bool AmenityTypes { get; set; }
        public bool Availabilities { get; set; }
        public bool BedTypes { get; set; }
        public bool CancellationPolicies { get; set; }
        public bool Cities { get; set; }
        public bool Countries { get; set; }
        public bool HostVerifications { get; set; }
        public bool Hosts { get; set; }
        public bool HostsHaveHostVerifications { get; set; }
        public bool Listings { get; set; }
        public bool ListingsHaveAmenityTypes { get; set; }
        public bool ListingsHaveBedTypes { get; set; }
        public bool Neighborhoods { get; set; }
        public bool PredefinedQueries { get; set; }
        public bool PropertyTypes { get; set; }
        public bool RoomTypes { get; set; }
        public bool Users { get; set; }
        public bool UsersReviewListings { get; set; }
        public Dictionary<string, DataTable> ResultData { get; set; }
    }
}