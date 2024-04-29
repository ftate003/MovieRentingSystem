using MovieRentingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentingSystem.Interface
{
    internal interface IUserService
    {
        void AddUser(User user);
        bool RemoveUser(int userId);
        bool ModifyUser(User user);
        List<User> SearchUsers(string userName);
        List<User> GetAllUsers();
        UserStatus GetUserStatus(int userId);
    }
}
