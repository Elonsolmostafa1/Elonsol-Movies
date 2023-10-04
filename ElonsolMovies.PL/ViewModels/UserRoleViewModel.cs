using ElonsolMovies.PL.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ElonsolMovies.PL.Models
{
    public class UserRoleViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public List<RoleViewModel> Roles { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public UserRoleViewModel()
        {
            Id = Guid.NewGuid().ToString();
        }

    }

    
}
