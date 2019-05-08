using System;
using System.Collections.Generic;

namespace DbProjectAirbnb.Web.Model
{
    public partial class Users
    {
        public Users()
        {
            UsersReviewListings = new HashSet<UsersReviewListings>();
        }

        public decimal Id { get; set; }
        public string Name { get; set; }

        public virtual Hosts Hosts { get; set; }
        public virtual ICollection<UsersReviewListings> UsersReviewListings { get; set; }
    }
}
