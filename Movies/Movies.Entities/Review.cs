using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Entities
{
    public  class Review
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public int Score { get; set; }
        public int? MovieId { get; set; }

        public virtual Movie Movie { get; set; }
    }
}
