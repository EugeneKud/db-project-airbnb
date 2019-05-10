namespace DbProjectAirbnb.Web.Entities
{
    public class ListingHasBedType
    {
        public decimal ListingId { get; set; }
        public decimal BedTypeId { get; set; }
        public byte? Amount { get; set; }

        public virtual BedType BedType { get; set; }
        public virtual Listing Listing { get; set; }
    }
}
