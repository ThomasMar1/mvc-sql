using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class MyModel
    {
        public int  ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }
        public string CategoryName { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string Country { get; set; }

    }
}