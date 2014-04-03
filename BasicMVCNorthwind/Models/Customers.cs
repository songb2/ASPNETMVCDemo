//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BasicMVCNorthwind.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    
    public partial class Customers
    {
        public Customers()
        {
            this.Orders = new HashSet<Orders>();
            this.CustomerDemographics = new HashSet<CustomerDemographics>();
        }
    
        [HiddenInput(DisplayValue=false)]
        [Display(Name = "Customer ID")]
        public string CustomerID { get; set; }

        [Display(Name="Company Name")]
        public string CompanyName { get; set; }

        [Display(Name = "Contact Name")]
        public string ContactName { get; set; }

        [Display(Name="Contact Title")]
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }

        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }

        [ScaffoldColumn(false)]
        public string Fax { get; set; }
    
        public virtual ICollection<Orders> Orders { get; set; }
        public virtual ICollection<CustomerDemographics> CustomerDemographics { get; set; }
    }
}
