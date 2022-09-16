using System.ComponentModel.DataAnnotations;


// MODEL OR ENTITY
namespace Company.DAL.Models
{
    public class Game
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public string Developer { get; set; }
        [Required]
        public string Platform { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        public string Image { get; set; }

    }
}
