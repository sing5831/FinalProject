using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Models
{
    [Authorize] //creates an authorization to see order. user has to log in first
    public class Order
    {
        public int id { get; set; }

        [ForeignKey("customer")]
        public int custID { get; set; }
        public DateTime orderDate { get; set; }

        public virtual Customer customer { get; set; }


    }
}