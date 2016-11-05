namespace EClassBook.API.ViewModels
{
    using Microsoft.AspNetCore.Mvc;
    using Model;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    [Route("api/[controller]")]
    public class StudentViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public IEnumerable<Grade> grades { get; set; }

        public int ClassGroupId { get; set; }

    }
}
