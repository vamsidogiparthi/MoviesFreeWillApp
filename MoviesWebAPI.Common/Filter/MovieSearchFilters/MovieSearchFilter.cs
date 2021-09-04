using System.Collections.Generic;

namespace MoviesWebAPI.Common.Filter.MovieSearchFilters
{
    public class MovieSearchFilter
    {
        public string Title { get; set; }
        public int? YearOfRelease { get; set; }
        public List<string> Genres { get; set; }
    }
}
