using System.Collections.Generic;
using System.Data;
using DbProjectAirbnb.Web.Entities;

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
        public bool PropertyTypes { get; set; }
        public bool RoomTypes { get; set; }
        public bool Users { get; set; }
        public bool UsersReviewListings { get; set; }
        
        public ICollection<AmenityType> AmenityTypesResult { get; set; }
        public int AmenityTypesResultCount { get; set; }
        public ICollection<Availability> AvailabilitiesResult { get; set; }
        public ICollection<BedType> BedTypesResult { get; set; }
        public ICollection<CancellationPolicy> CancellationPoliciesResult { get; set; }
        public ICollection<City> CitiesResult { get; set; }
        public ICollection<Country> CountriesResult { get; set; }
        public ICollection<HostVerification> HostVerificationsResult { get; set; }
        public ICollection<Host> HostsResult { get; set; }
        public ICollection<HostHasHostVerification> HostsHaveHostVerificationsResult { get; set; }
        public ICollection<Listing> ListingsResult { get; set; }
        public ICollection<ListingHasAmenityType> ListingsHaveAmenityTypesResult { get; set; }
        public ICollection<ListingHasBedType> ListingsHaveBedTypesResult { get; set; }
        public ICollection<Neighborhood> NeighborhoodsResult { get; set; }
        public ICollection<PropertyType> PropertyTypesResult { get; set; }
        public ICollection<RoomType> RoomTypesResult { get; set; }
        public ICollection<User> UsersResult { get; set; }
        public ICollection<UserReviewsListing> UsersReviewListingsResult { get; set; }
        
        public Dictionary<string, DataTable> ResultData { get; set; }
    }
}