namespace EClassBook.API.ViewModels
{
    using Microsoft.AspNetCore.Mvc;
    using System.ComponentModel.DataAnnotations;

    [Route("api/[controller]")]

    public class GroupViewModel
    {
        [Required]
        public string Name { get; set; }

    }
}
