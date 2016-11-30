using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BucketList.Models
{
    public class Sports
    {
        [Key]
        public int SportsId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string Location { get; set; }
        public virtual ApplicationUser User { get; set; }   
        
        [ForeignKey ("SportType")] //This SHOULD be the fk
        public int SportTypeId { get; set; }
        public virtual SportsType SportType { get; set;}
    }
}