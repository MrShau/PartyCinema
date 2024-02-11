using System.ComponentModel.DataAnnotations;

namespace PartyCinema.Server.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        public List<User> Users { get; set; }

        public Role() { }
        public Role(string name) => Name = name.ToUpper();
    }
}
