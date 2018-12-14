using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class RestaurantMenu
    {
        public int id { get; set; }
        public string item { get; set; }
        public decimal price { get; set; }
        public int qty{ get; set; }
    }
}