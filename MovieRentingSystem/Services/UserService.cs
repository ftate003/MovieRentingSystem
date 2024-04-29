using MovieRentingSystem.Interface;
using MovieRentingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentingSystem.Services
{
    public class UserService : IUserService
    {
        private List<User> users = new List<User>();

        //Constructor
        public UserService()
        {            
            users = new List<User>();
          
            PopulateUsers();
        }

        //Add new sample users
        private void PopulateUsers()
        {
            
            AddUser(new User { Id = 1, Name = "Joni Taikina", Email = "joni@example.com", RegistrationDate = DateTime.Now, Status = UserStatus.Active });
            AddUser(new User { Id = 2, Name = "Jaana Seppä", Email = "jaana@example.com", RegistrationDate = DateTime.Now, Status = UserStatus.Active });
            AddUser(new User { Id = 3, Name = "Pekka Puujalka", Email = "pekka@example.com", RegistrationDate = DateTime.Now, Status = UserStatus.Active });
            AddUser(new User { Id = 4, Name = "Kimi Räikkä", Email = "kimi@example.com", RegistrationDate = DateTime.Now, Status = UserStatus.Suspended });
            
        }

        public void AddUser(User user)
        {
            users.Add(user);
        }

        public bool RemoveUser(int userId)
        {
            var userToRemove = users.FirstOrDefault(user => user.Id == userId);
            if (userToRemove != null)
            {
                users.Remove(userToRemove);
                return true;
            }
            return false;
        }

        public bool ModifyUser(User user)
        {
            var existingUser = users.FirstOrDefault(u => u.Id == user.Id);
            if (existingUser != null)
            {
                existingUser.Name = user.Name;
                existingUser.Email = user.Email;
                existingUser.RegistrationDate = user.RegistrationDate;
                existingUser.Status = user.Status;
                return true;
            }
            return false;
        }

        public List<User> SearchUsers(string userName)
        {
            // Search users by name
            return users.Where(user => user.Name.Contains(userName)).ToList();
        }

        public List<User> GetAllUsers()
        {
            return users;
        }

        public UserStatus GetUserStatus(int userId)
        {
            var user = users.FirstOrDefault(u => u.Id == userId);
            // Return user status or default to Inactive
            return user != null ? user.Status : UserStatus.Inactive; 
        }
    }
}
