using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
	
namespace BucketList.Models
{
    public class ShoppingType
    {
        [Key]
        public int ShoppingTypeId { get; set; }
        public string ShoppingsType { get; set; }
        public virtual ICollection<Shopping> Shopping { get; set; }

    }
}