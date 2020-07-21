using System.Collections.Generic;

namespace Vidly.Models.ViewModels
{
    public class MovieFormViewModel
    {
        public string Action { get; set; } = "Add a new movie";

        public Movie Movie { get; set; }

        public IEnumerable<Genre> Genres { get; set; }
    }
}