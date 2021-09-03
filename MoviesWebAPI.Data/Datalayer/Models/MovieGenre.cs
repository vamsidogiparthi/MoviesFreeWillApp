using System;
using System.Collections.Generic;

#nullable disable

namespace MoviesWebAPI.Data.Datalayer.Models
{
    public partial class MovieGenre
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int GenreId { get; set; }

        public virtual Genre Genre { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
