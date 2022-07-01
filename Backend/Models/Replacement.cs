using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Replacement
    {
        [Key, Required]
        public string OldSymbol { get; set; }
        [Required]
        public string NewSymbol { get; set; }
    }
}
