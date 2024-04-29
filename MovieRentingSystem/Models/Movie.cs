using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentingSystem.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public int ReleaseYear { get; set; }
        public string Genre { get; set; }
        public int Duration { get; set; }
        public string Rating { get; set; }
        public string Description { get; set; }
        public int AvailableCopies { get; set; }

        // Non-null values for properties to avoid the warnings
        public Movie()
        {
            Id = 0; // Default value
            Title = ""; // Default value
            Director = ""; // Default value
            ReleaseYear = 0; // Default value
            Genre = ""; // Default value
            Duration = 0; // Default value
            Rating = ""; // Default value
            Description = ""; // Default value
            AvailableCopies = 0; // Default value
        }
    }


}
