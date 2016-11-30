using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BucketList.Models
{
    public class Museum
    {
        [Key]
        public int MuseumId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string Location { get; set; }
        public virtual ApplicationUser User { get; set; }   //This SHOULD be the fk

        [ForeignKey ("MuseumsType")]
        public  int MuseumTypeId { get; set; }
        public virtual MuseumType MuseumsType { get; set; }
    }
}