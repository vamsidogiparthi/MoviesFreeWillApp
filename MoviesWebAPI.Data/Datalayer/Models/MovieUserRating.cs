using System;
using System.Collections.Generic;

#nullable disable

namespace MoviesWebAPI.Data.Datalayer.Models
{
    public partial class MovieUserRating
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RatingId { get; set; }
        public int MovieId { get; set; }

        public virtual Movie Movie { get; set; }
        public virtual Rating Rating { get; set; }
        public virtual User User { get; set; }
    }
}
