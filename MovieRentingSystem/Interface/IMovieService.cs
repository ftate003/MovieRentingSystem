using MovieRentingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentingSystem.Interface
{
    public interface IMovieService
    {
        void AddMovie(Movie movie);
        bool RemoveMovie(int movieId);
        bool ModifyMovie(Movie movie);
        Movie SearchMovie(string title);
        List<Movie> GetAllMovies();
        bool IsMovieAvailableForLoan(int movieId);
        bool LoanOutMovie(int movieId);
        bool ReturnMovie(int movieId);
    }
}
