using System;
using System.Collections.Generic;

#nullable disable

namespace MoviesWebAPI.Data.Datalayer.Models
{
    public partial class User
    {
        public User()
        {
            MovieUserRatings = new HashSet<MovieUserRating>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<MovieUserRating> MovieUserRatings { get; set; }
    }
}
