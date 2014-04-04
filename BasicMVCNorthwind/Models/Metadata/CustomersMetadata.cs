using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace BasicMVCNorthwind.Models
{
    [DisplayName("New Customer")]
    public partial class CustomersMetaData
    {
        [DisplayName("Beautiful City")]
        public string City { get; set; }
    }
}