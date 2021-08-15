using System;
using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularProjectAPI.Models
{
    public class Post
    {
        public int PostID { get; set; }
        public string Text { get; set; }

        [NotMapped]
        public int[] likes { get; set; }

        //Relations
        public int UserID { get; set; }
        public User User { get; set; }
    }
}
