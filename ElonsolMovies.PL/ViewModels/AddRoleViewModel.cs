using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ElonsolMovies.PL.Models
{
    public class AddRoleViewModel
    {

        [Required(ErrorMessage="Role name is required")]
        public string Name { get; set; }
    }
}
