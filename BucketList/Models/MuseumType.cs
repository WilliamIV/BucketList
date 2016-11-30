using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BucketList.Models
{
    public class MuseumType
    {
        [Key]
        public int MuseumTypeId { get; set; }
        public string MuseumsType { get; set; }
        public virtual ICollection<Museum> Museum { get; set; }

    }
}