using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BucketList.Models
{
    public class RestraurantType
    {
        [Key]
        public int RestraurantTypeId { get; set; }
        public string RestraurantsType { get; set; }
        public virtual ICollection<Restaurants> Restraurants { get; set; }

    }
}