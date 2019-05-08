using System.Collections.Generic;

namespace DbProjectAirbnb.Web.Model
{
    public class User
    {
        public User()
        {
            UsersReviewListings = new HashSet<UserReviewsListing>();
        }

        public decimal Id { get; set; }
        public string Name { get; set; }

        public virtual Host Host { get; set; }
        public virtual ICollection<UserReviewsListing> UsersReviewListings { get; set; }
    }
}
