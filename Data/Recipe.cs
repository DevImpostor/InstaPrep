using System;
namespace InstaPrep.Data
{
	public class Recipe
	{
		public string Id { get; set; } = string.Empty;
		public string ImageUrl { get; set; } = string.Empty;
		public string Title { get; set; } = string.Empty;
		public string Rating { get; set; } = string.Empty;
		public string Duration { get; set; } = string.Empty;
		public string Effort { get; set; } = string.Empty;

		public List<RecipeIngredient> IngredientsList = new List<RecipeIngredient>();

		public Recipe()
		{
			Id = Guid.NewGuid().ToString();
		}
	}
}

