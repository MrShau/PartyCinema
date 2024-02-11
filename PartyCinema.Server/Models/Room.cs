using System.ComponentModel.DataAnnotations;

namespace PartyCinema.Server.Models
{
    public class Room
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int VideoId { get; set; }
        public Video Video { get; set; }

        [Required]
        public int CreatedUserId { get; set; }
        public User CreatedUser { get; set; }

        [Required]
        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; }
        
        public List<User> Viewers { get; set; } = new List<User>();

        public Room() => CreatedAt = DateTime.UtcNow;

        public Room(Video video, User createdUser, Movie movie)
        {
            Video = video;
            CreatedUser = createdUser;
            Movie = movie;
        }
    }
}
