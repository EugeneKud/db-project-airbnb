using System.Data;

namespace DbProjectAirbnb.Web.Entities
{
    public class PredefinedQuery
    {
        public decimal Id { get; set; }
        public decimal Deliverable { get; set; }
        public decimal Order { get; set; }
        public string Description { get; set; }
        public string Sql { get; set; }
        public DataTable DataTable { get; set; } // ef ignored
    }
}