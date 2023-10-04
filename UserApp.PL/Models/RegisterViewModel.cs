using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace UserApp.PL.Models
{
    public class RegisterViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }
        public IFormFile Pic { get; set; }
        public string ProfilePic { get; set; }
        public string PhoneNumber { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        public IEnumerable<string> Roles { get; set; }

        public RegisterViewModel()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
