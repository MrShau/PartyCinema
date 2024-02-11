using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace PartyCinema.Server.Models
{
    [Index(nameof(Login), IsUnique = true)]
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Login { get; set; }

        [Required]
        [StringLength(500)]
        public string PasswordHash { get; set; }

        [Required]
        [StringLength(250)]
        public string ImagePath { get; set; }

        [DataType(DataType.EmailAddress)]
        public string? EmailAddress { get; set; }

        [Required]
        public int RoleId { get; set; }
        public Role Role { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; }

        public int CreatedRoomId { get; set; }
        public Room? CreatedRoom { get; set; }

        public List<Room> ViewRooms { get; set; } = new List<Room>();

        public User() => CreatedAt = DateTime.UtcNow;
     
        public User(string login, string password, Role role, string imagePath = "images/default_profile.png", string? emailAddress = null) : this()
        {
            Login = login.ToLower();
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);
            ImagePath = imagePath;
            EmailAddress = emailAddress;
            Role = role;
        }

        public bool CheckPassword(string password) => BCrypt.Net.BCrypt.Verify(password, PasswordHash);
    }
}
