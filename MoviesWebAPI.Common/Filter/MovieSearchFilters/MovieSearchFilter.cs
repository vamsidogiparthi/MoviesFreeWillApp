using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesWebAPI.Common.Filter.MovieSearchFilters
{
    public class MovieSearchFilter
    {
        public string Title { get; set; }
        public int? YearOfRelease { get; set; }
        public string[] Genres { get; set; }
    }
}
