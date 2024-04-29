using MovieRentingSystem.Interface;
using MovieRentingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentingSystem.Services
{
    internal class LoanService : ILoanService
    {
        private List<LoanInfo> loanRecords;
        private IMovieService movieService;
        private IUserService userService;

        public LoanService(IMovieService movieService, IUserService userService)
        {
            this.movieService = movieService;
            this.userService = userService;
            this.loanRecords = new List<LoanInfo>();
        }

        public bool LoanMovie(int movieId, int loanerId, DateTime loanDate, DateTime dueDate)
        {
            // Movie loan availability
            if (!movieService.IsMovieAvailableForLoan(movieId))
                return false;

            // Check if user is active
            if (userService.GetUserStatus(loanerId) != UserStatus.Active)
                return false;

            // Loan the movie
            if (!movieService.LoanOutMovie(movieId))
                return false;

            // Create a new loan info
            var loanInfo = new LoanInfo
            {
                LoanId = loanRecords.Count + 1,
                MovieId = movieId,
                LoanerId = loanerId,
                LoanDate = loanDate,
                DueDate = dueDate
            };
            loanRecords.Add(loanInfo);
            return true;
        }

        public bool ReturnMovie(int loanId, DateTime returnDate)
        {
            var loanInfo = loanRecords.FirstOrDefault(loan => loan.LoanId == loanId);
            if (loanInfo != null && !loanInfo.ReturnDate.HasValue)
            {
                // Mark movie as returned
                loanInfo.ReturnDate = returnDate;
                // Add available copies
                movieService.ReturnMovie(loanInfo.MovieId);
                return true;
            }
            return false;
        }
    }
}
