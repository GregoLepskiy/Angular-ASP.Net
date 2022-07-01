using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class UserString
    {
        [Key, Required]
        public int Id { get; set; }

        public string? InString { get; set; }

        public DateTime? Date { get; set; }
    }
}
