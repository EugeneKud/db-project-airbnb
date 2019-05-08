using System.Collections.Generic;

namespace DbProjectAirbnb.Web.Model
{
    public class Listing
    {
        public Listing()
        {
            Availabilities = new HashSet<Availability>();
            ListingsHaveAmenityTypes = new HashSet<ListingHasAmenityType>();
            ListingsHaveBedTypes = new HashSet<ListingHasBedType>();
            UsersReviewListings = new HashSet<UserReviewsListing>();
        }

        public decimal Id { get; set; }
        public string Access { get; set; }
        public byte Accommodates { get; set; }
        public byte? Bathrooms { get; set; }
        public decimal BedTypeId { get; set; }
        public byte? Bedrooms { get; set; }
        public decimal CancellationPolicyId { get; set; }
        public decimal? CleaningFee { get; set; }
        public string Description { get; set; }
        public decimal ExtraPeople { get; set; }
        public byte GuestsIncluded { get; set; }
        public decimal HostId { get; set; }
        public string HouseRules { get; set; }
        public string Interaction { get; set; }
        public bool IsBusinessTravelReady { get; set; }
        public decimal Latitude { get; set; }
        public string ListingUrl { get; set; }
        public decimal Longitude { get; set; }
        public int MaximumNights { get; set; }
        public byte MinimumNights { get; set; }
        public decimal? MonthlyPrice { get; set; }
        public string Name { get; set; }
        public decimal NeighborhoodId { get; set; }
        public string NeighborhoodOverview { get; set; }
        public string Notes { get; set; }
        public string PictureUrl { get; set; }
        public decimal Price { get; set; }
        public decimal PropertyTypeId { get; set; }
        public bool RequireGuestPhoneVerification { get; set; }
        public bool RequireGuestProfilePicture { get; set; }
        public byte? ReviewScoresAccuracy { get; set; }
        public byte? ReviewScoresCheckin { get; set; }
        public byte? ReviewScoresCleanliness { get; set; }
        public byte? ReviewScoresCommunication { get; set; }
        public byte? ReviewScoresLocation { get; set; }
        public byte? ReviewScoresRating { get; set; }
        public byte? ReviewScoresValue { get; set; }
        public decimal RoomTypeId { get; set; }
        public decimal? SecurityDeposit { get; set; }
        public string Space { get; set; }
        public byte? SquareFeet { get; set; }
        public string Summary { get; set; }
        public string Transit { get; set; }
        public decimal? WeeklyPrice { get; set; }

        public virtual BedType BedType { get; set; }
        public virtual CancellationPolicy CancellationPolicy { get; set; }
        public virtual Host Host { get; set; }
        public virtual Neighborhood Neighborhood { get; set; }
        public virtual PropertyType PropertyType { get; set; }
        public virtual RoomType RoomType { get; set; }
        public virtual ICollection<Availability> Availabilities { get; set; }
        public virtual ICollection<ListingHasAmenityType> ListingsHaveAmenityTypes { get; set; }
        public virtual ICollection<ListingHasBedType> ListingsHaveBedTypes { get; set; }
        public virtual ICollection<UserReviewsListing> UsersReviewListings { get; set; }
    }
}
