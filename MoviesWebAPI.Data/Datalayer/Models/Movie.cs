using System;
using System.Collections.Generic;

#nullable disable

namespace MoviesWebAPI.Data.Datalayer.Models
{
    public partial class Movie
    {
        public Movie()
        {
            MovieGenres = new HashSet<MovieGenre>();
            MovieUserRatings = new HashSet<MovieUserRating>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int YearOfRelease { get; set; }
        public long RunningTime { get; set; }

        public virtual ICollection<MovieGenre> MovieGenres { get; set; }
        public virtual ICollection<MovieUserRating> MovieUserRatings { get; set; }
    }
}
