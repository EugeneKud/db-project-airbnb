using Microsoft.EntityFrameworkCore;

namespace DbProjectAirbnb.Web.Entities
{
    public class ModelContext : DbContext
    {
        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AmenityType> AmenityTypes { get; set; }
        public virtual DbSet<Availability> Availabilities { get; set; }
        public virtual DbSet<BedType> BedTypes { get; set; }
        public virtual DbSet<CancellationPolicy> CancellationPolicies { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<HostVerification> HostVerifications { get; set; }
        public virtual DbSet<Host> Hosts { get; set; }
        public virtual DbSet<HostHasHostVerification> HostsHaveHostVerifications { get; set; }
        public virtual DbSet<Listing> Listings { get; set; }
        public virtual DbSet<ListingHasAmenityType> ListingsHaveAmenityTypes { get; set; }
        public virtual DbSet<ListingHasBedType> ListingsHaveBedTypes { get; set; }
        public virtual DbSet<Neighborhood> Neighborhoods { get; set; }
        public virtual DbSet<PropertyType> PropertyTypes { get; set; }
        public virtual DbSet<RoomType> RoomTypes { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserReviewsListing> UsersReviewListings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:DefaultSchema", "C##DB2019_G30");

            modelBuilder.Entity<AmenityType>(entity =>
            {
                entity.ToTable("AMENITY_TYPES");

                entity.HasIndex(e => e.Id)
                    .HasName("SYS_C0029277")
                    .IsUnique();

                entity.HasIndex(e => e.Name)
                    .HasName("SYS_C0029278")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasColumnType("VARCHAR2(50)");
            });

            modelBuilder.Entity<Availability>(entity =>
            {
                entity.ToTable("AVAILABILITIES");

                entity.HasIndex(e => e.Id)
                    .HasName("SYS_C0038423")
                    .IsUnique();

                entity.HasIndex(e => new { e.Date, e.ListingId })
                    .HasName("U_AVAILABILITIES_DATE_LISTING_ID")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.Available).HasColumnName("AVAILABLE");

                entity.Property(e => e.Date)
                    .HasColumnName("DATE")
                    .HasColumnType("DATE");

                entity.Property(e => e.ListingId)
                    .HasColumnName("LISTING_ID")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.Price)
                    .HasColumnName("PRICE")
                    .HasColumnType("NUMBER(10,2)");

                entity.HasOne(d => d.Listing)
                    .WithMany(p => p.Availabilities)
                    .HasForeignKey(d => d.ListingId)
                    .HasConstraintName("SYS_C0038425");
            });

            modelBuilder.Entity<BedType>(entity =>
            {
                entity.ToTable("BED_TYPES");

                entity.HasIndex(e => e.Id)
                    .HasName("SYS_C0029281")
                    .IsUnique();

                entity.HasIndex(e => e.Name)
                    .HasName("SYS_C0029282")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasColumnType("VARCHAR2(20)");
            });

            modelBuilder.Entity<CancellationPolicy>(entity =>
            {
                entity.ToTable("CANCELLATION_POLICIES");

                entity.HasIndex(e => e.Id)
                    .HasName("SYS_C0029285")
                    .IsUnique();

                entity.HasIndex(e => e.Name)
                    .HasName("SYS_C0029286")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasColumnType("VARCHAR2(30)");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("CITIES");

                entity.HasIndex(e => e.Id)
                    .HasName("SYS_C0038352")
                    .IsUnique();

                entity.HasIndex(e => new { e.Name, e.CountryId })
                    .HasName("U_CITIES_NAME_COUNTRY_ID")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CountryId)
                    .HasColumnName("COUNTRY_ID")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasColumnType("VARCHAR2(50)");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("SYS_C0038354");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("COUNTRIES");

                entity.HasIndex(e => e.Code)
                    .HasName("SYS_C0029291")
                    .IsUnique();

                entity.HasIndex(e => e.Id)
                    .HasName("SYS_C0029290")
                    .IsUnique();

                entity.HasIndex(e => e.Name)
                    .HasName("SYS_C0029292")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("CODE")
                    .HasColumnType("VARCHAR2(2)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasColumnType("VARCHAR2(60)");
            });

            modelBuilder.Entity<HostVerification>(entity =>
            {
                entity.ToTable("HOST_VERIFICATIONS");

                entity.HasIndex(e => e.Id)
                    .HasName("SYS_C0038357")
                    .IsUnique();

                entity.HasIndex(e => e.Name)
                    .HasName("SYS_C0038358")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasColumnType("NVARCHAR2(30)");
            });

            modelBuilder.Entity<Host>(entity =>
            {
                entity.ToTable("HOSTS");

                entity.HasIndex(e => e.Id)
                    .HasName("SYS_C0038373")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.About)
                    .HasColumnName("ABOUT")
                    .HasColumnType("CLOB");

                entity.Property(e => e.NeighborhoodId)
                    .HasColumnName("NEIGHBORHOOD_ID")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.PictureUrl)
                    .IsRequired()
                    .HasColumnName("PICTURE_URL")
                    .HasColumnType("VARCHAR2(150)");

                entity.Property(e => e.ResponseRate)
                    .IsRequired()
                    .HasColumnName("RESPONSE_RATE")
                    .HasColumnType("VARCHAR2(4)");

                entity.Property(e => e.ResponseTime)
                    .IsRequired()
                    .HasColumnName("RESPONSE_TIME")
                    .HasColumnType("VARCHAR2(30)");

                entity.Property(e => e.Since)
                    .HasColumnName("SINCE")
                    .HasColumnType("DATE");

                entity.Property(e => e.ThumbnailUrl)
                    .IsRequired()
                    .HasColumnName("THUMBNAIL_URL")
                    .HasColumnType("VARCHAR2(150)");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasColumnName("URL")
                    .HasColumnType("VARCHAR2(50)");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Host)
                    .HasForeignKey<Host>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SYS_C0038374");

                entity.HasOne(d => d.Neighborhood)
                    .WithMany(p => p.Hosts)
                    .HasForeignKey(d => d.NeighborhoodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SYS_C0038375");
            });

            modelBuilder.Entity<HostHasHostVerification>(entity =>
            {
                entity.HasKey(e => new { e.HostId, e.HostVerificationId })
                    .HasName("SYS_C0038403");

                entity.ToTable("HOSTS_HAVE_HOST_VERIFICATIONS");

                entity.HasIndex(e => new { e.HostId, e.HostVerificationId })
                    .HasName("SYS_C0038403")
                    .IsUnique();

                entity.Property(e => e.HostId)
                    .HasColumnName("HOST_ID")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.HostVerificationId)
                    .HasColumnName("HOST_VERIFICATION_ID")
                    .HasColumnType("NUMBER");

                entity.HasOne(d => d.Host)
                    .WithMany(p => p.HostsHaveHostVerifications)
                    .HasForeignKey(d => d.HostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SYS_C0038404");

                entity.HasOne(d => d.HostVerification)
                    .WithMany(p => p.HostsHaveHostVerifications)
                    .HasForeignKey(d => d.HostVerificationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SYS_C0038405");
            });

            modelBuilder.Entity<Listing>(entity =>
            {
                entity.ToTable("LISTINGS");

                entity.HasIndex(e => e.Id)
                    .HasName("SYS_C0038396")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.Access)
                    .HasColumnName("ACCESS")
                    .HasColumnType("CLOB");

                entity.Property(e => e.Accommodates)
                    .HasColumnName("ACCOMMODATES")
                    .HasColumnType("NUMBER(2)");

                entity.Property(e => e.Bathrooms)
                    .HasColumnName("BATHROOMS")
                    .HasColumnType("NUMBER(2)");

                entity.Property(e => e.BedTypeId)
                    .HasColumnName("BED_TYPE_ID")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.Bedrooms)
                    .HasColumnName("BEDROOMS")
                    .HasColumnType("NUMBER(2)");

                entity.Property(e => e.CancellationPolicyId)
                    .HasColumnName("CANCELLATION_POLICY_ID")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.CleaningFee)
                    .HasColumnName("CLEANING_FEE")
                    .HasColumnType("NUMBER(5,2)");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasColumnType("CLOB");

                entity.Property(e => e.ExtraPeople)
                    .HasColumnName("EXTRA_PEOPLE")
                    .HasColumnType("NUMBER(5,2)");

                entity.Property(e => e.GuestsIncluded)
                    .HasColumnName("GUESTS_INCLUDED")
                    .HasColumnType("NUMBER(2)");

                entity.Property(e => e.HostId)
                    .HasColumnName("HOST_ID")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.HouseRules)
                    .HasColumnName("HOUSE_RULES")
                    .HasColumnType("CLOB");

                entity.Property(e => e.Interaction)
                    .HasColumnName("INTERACTION")
                    .HasColumnType("CLOB");

                entity.Property(e => e.IsBusinessTravelReady).HasColumnName("IS_BUSINESS_TRAVEL_READY");

                entity.Property(e => e.Latitude)
                    .HasColumnName("LATITUDE")
                    .HasColumnType("NUMBER(17,15)");

                entity.Property(e => e.ListingUrl)
                    .IsRequired()
                    .HasColumnName("LISTING_URL")
                    .HasColumnType("VARCHAR2(50)");

                entity.Property(e => e.Longitude)
                    .HasColumnName("LONGITUDE")
                    .HasColumnType("NUMBER(17,15)");

                entity.Property(e => e.MaximumNights).HasColumnName("MAXIMUM_NIGHTS");

                entity.Property(e => e.MinimumNights)
                    .HasColumnName("MINIMUM_NIGHTS")
                    .HasColumnType("NUMBER(4)");

                entity.Property(e => e.MonthlyPrice)
                    .HasColumnName("MONTHLY_PRICE")
                    .HasColumnType("NUMBER(7,2)");

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasColumnType("VARCHAR2(150)");

                entity.Property(e => e.NeighborhoodId)
                    .HasColumnName("NEIGHBORHOOD_ID")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.NeighborhoodOverview)
                    .HasColumnName("NEIGHBORHOOD_OVERVIEW")
                    .HasColumnType("CLOB");

                entity.Property(e => e.Notes)
                    .HasColumnName("NOTES")
                    .HasColumnType("CLOB");

                entity.Property(e => e.PictureUrl)
                    .IsRequired()
                    .HasColumnName("PICTURE_URL")
                    .HasColumnType("VARCHAR2(150)");

                entity.Property(e => e.Price)
                    .HasColumnName("PRICE")
                    .HasColumnType("NUMBER(7,2)");

                entity.Property(e => e.PropertyTypeId)
                    .HasColumnName("PROPERTY_TYPE_ID")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.RequireGuestPhoneVerification).HasColumnName("REQUIRE_GUEST_PHONE_VERIFICATION");

                entity.Property(e => e.RequireGuestProfilePicture).HasColumnName("REQUIRE_GUEST_PROFILE_PICTURE");

                entity.Property(e => e.ReviewScoresAccuracy)
                    .HasColumnName("REVIEW_SCORES_ACCURACY")
                    .HasColumnType("NUMBER(2)");

                entity.Property(e => e.ReviewScoresCheckin)
                    .HasColumnName("REVIEW_SCORES_CHECKIN")
                    .HasColumnType("NUMBER(2)");

                entity.Property(e => e.ReviewScoresCleanliness)
                    .HasColumnName("REVIEW_SCORES_CLEANLINESS")
                    .HasColumnType("NUMBER(2)");

                entity.Property(e => e.ReviewScoresCommunication)
                    .HasColumnName("REVIEW_SCORES_COMMUNICATION")
                    .HasColumnType("NUMBER(2)");

                entity.Property(e => e.ReviewScoresLocation)
                    .HasColumnName("REVIEW_SCORES_LOCATION")
                    .HasColumnType("NUMBER(2)");

                entity.Property(e => e.ReviewScoresRating).HasColumnName("REVIEW_SCORES_RATING");

                entity.Property(e => e.ReviewScoresValue)
                    .HasColumnName("REVIEW_SCORES_VALUE")
                    .HasColumnType("NUMBER(2)");

                entity.Property(e => e.RoomTypeId)
                    .HasColumnName("ROOM_TYPE_ID")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.SecurityDeposit)
                    .HasColumnName("SECURITY_DEPOSIT")
                    .HasColumnType("NUMBER(6,2)");

                entity.Property(e => e.Space)
                    .HasColumnName("SPACE")
                    .HasColumnType("CLOB");

                entity.Property(e => e.SquareFeet)
                    .HasColumnName("SQUARE_FEET")
                    .HasColumnType("NUMBER(4)");

                entity.Property(e => e.Summary)
                    .HasColumnName("SUMMARY")
                    .HasColumnType("CLOB");

                entity.Property(e => e.Transit)
                    .HasColumnName("TRANSIT")
                    .HasColumnType("CLOB");

                entity.Property(e => e.WeeklyPrice)
                    .HasColumnName("WEEKLY_PRICE")
                    .HasColumnType("NUMBER(6,2)");

                entity.HasOne(d => d.BedType)
                    .WithMany(p => p.Listings)
                    .HasForeignKey(d => d.BedTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SYS_C0038402");

                entity.HasOne(d => d.CancellationPolicy)
                    .WithMany(p => p.Listings)
                    .HasForeignKey(d => d.CancellationPolicyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SYS_C0038397");

                entity.HasOne(d => d.Host)
                    .WithMany(p => p.Listings)
                    .HasForeignKey(d => d.HostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SYS_C0038398");

                entity.HasOne(d => d.Neighborhood)
                    .WithMany(p => p.Listings)
                    .HasForeignKey(d => d.NeighborhoodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SYS_C0038399");

                entity.HasOne(d => d.PropertyType)
                    .WithMany(p => p.Listings)
                    .HasForeignKey(d => d.PropertyTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SYS_C0038400");

                entity.HasOne(d => d.RoomType)
                    .WithMany(p => p.Listings)
                    .HasForeignKey(d => d.RoomTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SYS_C0038401");
            });

            modelBuilder.Entity<ListingHasAmenityType>(entity =>
            {
                entity.HasKey(e => new { e.ListingId, e.AmenityTypeId })
                    .HasName("SYS_C0038406");

                entity.ToTable("LISTINGS_HAVE_AMENITY_TYPES");

                entity.HasIndex(e => new { e.ListingId, e.AmenityTypeId })
                    .HasName("SYS_C0038406")
                    .IsUnique();

                entity.Property(e => e.ListingId)
                    .HasColumnName("LISTING_ID")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.AmenityTypeId)
                    .HasColumnName("AMENITY_TYPE_ID")
                    .HasColumnType("NUMBER");

                entity.HasOne(d => d.AmenityType)
                    .WithMany(p => p.ListingsHaveAmenityTypes)
                    .HasForeignKey(d => d.AmenityTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SYS_C0038408");

                entity.HasOne(d => d.Listing)
                    .WithMany(p => p.ListingsHaveAmenityTypes)
                    .HasForeignKey(d => d.ListingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SYS_C0038407");
            });

            modelBuilder.Entity<ListingHasBedType>(entity =>
            {
                entity.HasKey(e => new { e.ListingId, e.BedTypeId })
                    .HasName("SYS_C0038411");

                entity.ToTable("LISTINGS_HAVE_BED_TYPES");

                entity.HasIndex(e => new { e.ListingId, e.BedTypeId })
                    .HasName("SYS_C0038411")
                    .IsUnique();

                entity.Property(e => e.ListingId)
                    .HasColumnName("LISTING_ID")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.BedTypeId)
                    .HasColumnName("BED_TYPE_ID")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.Amount)
                    .HasColumnName("AMOUNT")
                    .HasColumnType("NUMBER(2)");

                entity.HasOne(d => d.BedType)
                    .WithMany(p => p.ListingsHaveBedTypes)
                    .HasForeignKey(d => d.BedTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SYS_C0038413");

                entity.HasOne(d => d.Listing)
                    .WithMany(p => p.ListingsHaveBedTypes)
                    .HasForeignKey(d => d.ListingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SYS_C0038412");
            });

            modelBuilder.Entity<Neighborhood>(entity =>
            {
                entity.ToTable("NEIGHBORHOODS");

                entity.HasIndex(e => e.Id)
                    .HasName("SYS_C0038362")
                    .IsUnique();

                entity.HasIndex(e => new { e.Name, e.CityId })
                    .HasName("U_NEIGHBORHOODS_NAME_CITY_ID")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CityId)
                    .HasColumnName("CITY_ID")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasColumnType("VARCHAR2(50)");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Neighborhoods)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SYS_C0038364");
            });

            modelBuilder.Entity<PropertyType>(entity =>
            {
                entity.ToTable("PROPERTY_TYPES");

                entity.HasIndex(e => e.Id)
                    .HasName("SYS_C0029295")
                    .IsUnique();

                entity.HasIndex(e => e.Name)
                    .HasName("SYS_C0029296")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasColumnType("VARCHAR2(30)");
            });

            modelBuilder.Entity<RoomType>(entity =>
            {
                entity.ToTable("ROOM_TYPES");

                entity.HasIndex(e => e.Id)
                    .HasName("SYS_C0029299")
                    .IsUnique();

                entity.HasIndex(e => e.Name)
                    .HasName("SYS_C0029300")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasColumnType("VARCHAR2(20)");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("USERS");

                entity.HasIndex(e => e.Id)
                    .HasName("SYS_C0029301")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasColumnType("VARCHAR2(50)");
            });

            modelBuilder.Entity<UserReviewsListing>(entity =>
            {
                entity.ToTable("USERS_REVIEW_LISTINGS");

                entity.HasIndex(e => e.Id)
                    .HasName("SYS_C0038417")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.Comments)
                    .HasColumnName("COMMENTS")
                    .HasColumnType("CLOB");

                entity.Property(e => e.Date)
                    .HasColumnName("DATE")
                    .HasColumnType("DATE");

                entity.Property(e => e.ListingId)
                    .HasColumnName("LISTING_ID")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .HasColumnType("NUMBER");

                entity.HasOne(d => d.Listing)
                    .WithMany(p => p.UsersReviewListings)
                    .HasForeignKey(d => d.ListingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SYS_C0038419");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UsersReviewListings)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SYS_C0038418");
            });

            modelBuilder.HasSequence("ISEQ$$_108365");

            modelBuilder.HasSequence("ISEQ$$_108493");

            modelBuilder.HasSequence("ISEQ$$_108497");

            modelBuilder.HasSequence("ISEQ$$_108501");

            modelBuilder.HasSequence("ISEQ$$_108505");

            modelBuilder.HasSequence("ISEQ$$_108510");

            modelBuilder.HasSequence("ISEQ$$_108514");

            modelBuilder.HasSequence("ISEQ$$_108523");

            modelBuilder.HasSequence("ISEQ$$_108834");

            modelBuilder.HasSequence("ISEQ$$_108838");

            modelBuilder.HasSequence("ISEQ$$_108842");

            modelBuilder.HasSequence("ISEQ$$_108846");

            modelBuilder.HasSequence("ISEQ$$_108851");

            modelBuilder.HasSequence("ISEQ$$_108855");

            modelBuilder.HasSequence("ISEQ$$_108861");

            modelBuilder.HasSequence("ISEQ$$_108865");

            modelBuilder.HasSequence("ISEQ$$_108869");

            modelBuilder.HasSequence("ISEQ$$_118388");

            modelBuilder.HasSequence("ISEQ$$_122906");

            modelBuilder.HasSequence("ISEQ$$_122910");

            modelBuilder.HasSequence("ISEQ$$_122914");
        }
    }
}
