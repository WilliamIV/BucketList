using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BucketList.Models
{
    public class SportsType
    {
        [Key]

        public int SportsTypeId { get; set; }
        public string  SportType { get; set; }
        public virtual ICollection<Sports> Sports { get; set; }
    }
}