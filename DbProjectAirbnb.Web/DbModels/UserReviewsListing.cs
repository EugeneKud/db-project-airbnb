using System;
using System.Collections.Generic;

namespace DbProjectAirbnb.Web.Model
{
    public partial class UserReviewsListing
    {
        public decimal Id { get; set; }
        public string Comments { get; set; }
        public DateTime Date { get; set; }
        public decimal ListingId { get; set; }
        public decimal UserId { get; set; }

        public virtual Listing Listing { get; set; }
        public virtual User User { get; set; }
    }
}
