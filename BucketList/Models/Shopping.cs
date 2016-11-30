using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BucketList.Models
{
    public class Shopping
    {
        [Key]
        public int ShoppingId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Link { get; set; }
        public virtual ApplicationUser User { get; set; }

        [ForeignKey("ShoppingsType")]
        public int ShoppingTypeID { get; set; }   //This SHOULD be the fk
        public virtual ShoppingType ShoppingsType { get; set; }



    }
}