using System.ComponentModel.DataAnnotations;

namespace PartyCinema.Server.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(250)]
        public string ImagePath { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set;}

        public List<Genre> Genres { get; set; } = new List<Genre>();
        public List<Video> Videos { get; set; } = new List<Video>();
        public List<Room> Rooms { get; set; } = new List<Room>();

        public Movie() => CreatedAt = DateTime.UtcNow;

        public Movie(string title, string imagePath, DateTime releaseDate) : this()
        {
            Title = title;
            ImagePath = imagePath;
            ReleaseDate = releaseDate;
        }
    }
}
