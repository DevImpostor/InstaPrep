namespace InstaPrep.Models
{
    public class RecipeIngredient
    {
        public float? MeasureValue { get; set; }
        public Ingredient? Ingredient { get; set; } 
        public MeasureUnit? MeasureUnit { get; set; }
        public CuttingMethod CuttingMethod { get; set; }
    }
}
