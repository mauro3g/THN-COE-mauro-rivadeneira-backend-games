using System.ComponentModel.DataAnnotations;


// MODEL OR ENTITY
namespace Company.DAL.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        [Required]
        public int Identification { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int Age { get; set; }


    }
}
