using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BucketList.Models
{
    public class ListCategory
    {
        [Display(Name ="Category")]
        public int ListCategoryId { get; set; }
        public string ListCategories { get; set; }
        public virtual ICollection<UserList> UserList { get; set; }
    }
}