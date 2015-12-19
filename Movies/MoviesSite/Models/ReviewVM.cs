using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoviesSite.Models
{
    public class ReviewVM
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public int Score { get; set; }
        public int? MovieId { get; set; }
    }
}