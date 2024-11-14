using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace UdemyMVC1.Models
{
    //First Model
    public class Contact
    {
        [Key]//I like to leave it explicit even if .Net knows, more easy to understand
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        public string Phone { get; set; }
        public DateTime createDate { get; set; } = DateTime.Now;
    }
}
