using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class OrderDetails
    {
        [Key, Column(Order = 0)]
        [ForeignKey("order")]
        public int rentID { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("menu")]
        public int menuID { get; set; }

        public int qtyOrdered { get; set; }
        public DateTime orderDueDate { get; set; }

        public virtual Order order { get; set; }
        public virtual RestaurantMenu menu { get; set; }
    }
}