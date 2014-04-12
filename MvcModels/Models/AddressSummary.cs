
using System.Web.Mvc;
namespace MvcModels.Models
{
    [Bind(Include = "Country")]
    public class AddressSummary
    {
        public string City { get; set; }
        public string Country { get; set; }
    }
}