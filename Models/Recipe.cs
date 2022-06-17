namespace InstaPrep.Models
{
    public class Recipe
    {
        public String? Title { get; set; }
        public DateTime? Duration { get; set; }
        public List<RecipeIngredient> Ingredients { get; set; }
        public int Rating { get; set; }
    }
}
