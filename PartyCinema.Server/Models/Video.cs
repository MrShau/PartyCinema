using System.ComponentModel.DataAnnotations;

namespace PartyCinema.Server.Models
{
    public class Video
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        [Required]
        public string Path { get; set; }

        [Required]
        public string Resolution { get; set; }

        [Required]
        public uint Duration { get; set; }

        public byte Season { get; set; }
        public byte Serie { get; set; }

        [Required]
        public uint Views { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; }

        public List<Room> Rooms { get; set; } = new List<Room>();

        public Video()
        {
            CreatedAt = DateTime.UtcNow;
            Views = 0;
        }
        public Video(Movie movie, string path, string resolution, uint duration, byte season = 0, byte serie = 0) : this()
        {
            Movie = movie;
            Path = path;
            Resolution = resolution;
            Duration = duration;
            Season = season;
            Serie = serie;
        }
    }
}
