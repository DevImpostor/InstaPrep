using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace InstaPrep.Data.Models
{
    public class Ingredient
    {
        [Key]
        public string Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Measure { get; set; } = string.Empty;
    }
}
