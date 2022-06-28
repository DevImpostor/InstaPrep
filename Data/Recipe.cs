using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InstaPrep.Data
{
	public class Recipe
	{
        [Key]
		public string Id { get; set; } = string.Empty;
		public string ImageUrl { get; set; } = string.Empty;
		public string Title { get; set; } = string.Empty;
		public string Rating { get; set; } = string.Empty;
		public string Duration { get; set; } = string.Empty;
		public string Effort { get; set; } = string.Empty;

		[Required]
		public List<RecipeIngredient> IngredientsList = new List<RecipeIngredient>();

		public Recipe()
		{
			Id = Guid.NewGuid().ToString();
		}
	}
}

