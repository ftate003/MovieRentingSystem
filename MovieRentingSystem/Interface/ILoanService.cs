using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentingSystem.Interface
{
    internal interface ILoanService
    {
        bool LoanMovie(int movieId, int loanerId, DateTime loanDate, DateTime dueDate);
        bool ReturnMovie(int loanId, DateTime returnDate);
    }
}
