using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string? Image { get; set; }
        [NotMapped]
        public IFormFile? File { get; set; }
        public string FullName { get; set; }
        public string Profession { get; set; }

    }
}
