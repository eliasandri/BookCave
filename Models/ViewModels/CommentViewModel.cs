using System;
using System.Collections.Generic;
using System.Linq;

namespace BookCave.Models.ViewModels
{
    public class CommentViewModel
    {
        public string Review { get; set; }
        public int BookId { get; set; }
        public int CommentId { get; set; }
        public int Ratings { get; set; }
    }
}