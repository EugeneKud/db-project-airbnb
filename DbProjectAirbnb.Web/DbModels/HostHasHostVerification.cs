namespace DbProjectAirbnb.Web.Model
{
    public class HostHasHostVerification
    {
        public decimal HostId { get; set; }
        public decimal HostVerificationId { get; set; }

        public virtual Host Host { get; set; }
        public virtual HostVerification HostVerification { get; set; }
    }
}
