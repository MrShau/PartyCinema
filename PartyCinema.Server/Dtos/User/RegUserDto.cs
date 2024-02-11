using System.ComponentModel.DataAnnotations;

namespace PartyCinema.Server.Dtos.User
{
    public class RegUserDto
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Login { get; set; }

        [Required]
        [StringLength(500)]
        public string Password { get; set; }
    }
}
