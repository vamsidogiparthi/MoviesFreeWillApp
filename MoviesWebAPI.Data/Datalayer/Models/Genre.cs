using System;
using System.Collections.Generic;

#nullable disable

namespace MoviesWebAPI.Data.Datalayer.Models
{
    public partial class Genre
    {
        public Genre()
        {
            MovieGenres = new HashSet<MovieGenre>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<MovieGenre> MovieGenres { get; set; }
    }
}
