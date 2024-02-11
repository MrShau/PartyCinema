using System.ComponentModel.DataAnnotations;

namespace PartyCinema.Server.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public List<Movie> Movies { get; set; } = new List<Movie>();

        public Genre() { }
        public Genre(string name) => Name = name;
    }
}
