using System;
using System.Collections.Generic;

namespace DbProjectAirbnb.Web.Model
{
    public partial class UsersReviewListings
    {
        public decimal Id { get; set; }
        public string Comments { get; set; }
        public DateTime Date { get; set; }
        public decimal ListingId { get; set; }
        public decimal UserId { get; set; }

        public virtual Listings Listing { get; set; }
        public virtual Users User { get; set; }
    }
}
