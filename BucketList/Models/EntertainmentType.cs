using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BucketList.Models
{
    public class EntertainmentType
    {
        [Key]
        public int EntertainmentTypeId { get; set; }
        public string EntertainmentsType { get; set; }
        public virtual ICollection<Entertainment> Entertainment {get; set;}


     }
}