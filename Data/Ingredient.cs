using System.ComponentModel.DataAnnotations;

namespace InstaPrep.Data
{
    public class Ingredient
    {
        public Ingredient()
        {
            Id = Guid.NewGuid().ToString();
        }
        [Key]
        public string Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsVolumeMeasure { get; set; }
        public bool IsWeightMeasure { get; set; }

    }
}
