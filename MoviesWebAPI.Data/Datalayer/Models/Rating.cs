using System;
using System.Collections.Generic;

#nullable disable

namespace MoviesWebAPI.Data.Datalayer.Models
{
    public partial class Rating
    {
        public Rating()
        {
            MovieUserRatings = new HashSet<MovieUserRating>();
        }

        public int Id { get; set; }
        public int Value { get; set; }

        public virtual ICollection<MovieUserRating> MovieUserRatings { get; set; }
    }
}
