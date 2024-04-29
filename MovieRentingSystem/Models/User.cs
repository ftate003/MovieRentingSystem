using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentingSystem.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }
        public UserStatus Status { get; set; }

        // Non-null values for properties to avoid the warnings
        public User()
        {
            Email = "";//Default value
            Name = "";//Default value
        }
    }

    public enum UserStatus
    {
        Active,
        Inactive,
        Suspended
    }

}
