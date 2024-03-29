﻿
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Blog
    {
        [Key]
        public int BlogId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? ThumbnailImage { get; set; }
        public string? Image { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Status { get; set; } = true;

        // Category
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        //Comments
        public List<Comment> Comments { get; set; }

        //Writer
        public int WriterId { get; set; }
        public Writer Writer { get; set; }
    }
}
