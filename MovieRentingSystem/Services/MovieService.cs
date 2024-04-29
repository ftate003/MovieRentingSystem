using MovieRentingSystem.Interface;
using MovieRentingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentingSystem.Services
{
    public class MovieService : IMovieService
    {
        private List<Movie> movies = new List<Movie>();

        //Constructor
        public MovieService()
        {
            PopulateMovies();
        }

        private void PopulateMovies()
        {
            AddMovie(new Movie
            {
                Id = 1,
                Title = "John Wick",
                Director = "Chad Stahelski",
                ReleaseYear = 2014,
                Genre = "Action",
                Duration = 101,
                Rating = "R",
                Description = "An ex-hitman comes out of retirement to track down the gangsters who killed his dog and stole his car.",
                AvailableCopies = 5
            });

            AddMovie(new Movie
            {
                Id = 2,
                Title = "Interstellar",
                Director = "Christopher Nolan",
                ReleaseYear = 2014,
                Genre = "Scifi",
                Duration = 169,
                Rating = "T",
                Description = "When Earth becomes uninhabitable in the future, a farmer and ex-NASA pilot, Joseph Cooper, is tasked to pilot a spacecraft, along with a team of researchers, to find a new planet for humans.",
                AvailableCopies = 4
            });

            AddMovie(new Movie
            {
                Id = 3,
                Title = "Dune: Part Two",
                Director = "Denis Villeneuve",
                ReleaseYear = 2024,
                Genre = "Action",
                Duration = 166,
                Rating = "T",
                Description = "Paul Atreides unites with Chani and the Fremen while seeking revenge against the conspirators who destroyed his family.",
                AvailableCopies = 6
            });
        }

        public void AddMovie(Movie movie)
        {
            movies.Add(movie);
        }

        public bool RemoveMovie(int movieId)
        {
            var movieToRemove = movies.FirstOrDefault(movie => movie.Id == movieId);
            if (movieToRemove != null)
            {
                movies.Remove(movieToRemove);
                return true;
            }
            return false;
        }

        public bool ModifyMovie(Movie movie)
        {
            var existingMovie = movies.FirstOrDefault(m => m.Id == movie.Id);
            if (existingMovie != null)
            {
                // Modify the existing movie
                existingMovie.Title = movie.Title;
                existingMovie.Director = movie.Director;
                existingMovie.ReleaseYear = movie.ReleaseYear;
                existingMovie.Genre = movie.Genre;
                existingMovie.Duration = movie.Duration;
                existingMovie.Rating = movie.Rating;
                existingMovie.Description = movie.Description;
                existingMovie.AvailableCopies = movie.AvailableCopies;
                return true;
            }
            return false;
        }

        public Movie SearchMovie(string title)
        {
            return movies.FirstOrDefault(m => m.Title.Contains(title, StringComparison.OrdinalIgnoreCase));
        }

        public List<Movie> GetAllMovies()
        {
            return movies;
        }

        public bool IsMovieAvailableForLoan(int movieId)
        {
            var movie = movies.FirstOrDefault(movie => movie.Id == movieId);
            return movie != null && movie.AvailableCopies > 0;
        }

        public bool LoanOutMovie(int movieId)
        {
            var movie = movies.FirstOrDefault(m => m.Id == movieId);
            if (movie != null && movie.AvailableCopies > 0)
            {
                movie.AvailableCopies--;
                return true;
            }
            return false;
        }

        public bool ReturnMovie(int movieId)
        {
            var movie = movies.FirstOrDefault(m => m.Id == movieId);
            if (movie != null)
            {
                movie.AvailableCopies++;
                return true;
            }
            return false;
        }
    }
}