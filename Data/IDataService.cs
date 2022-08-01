using System;
namespace InstaPrep.Data
{
	public interface IDataService
	{
		public List<Recipe> GetRecipes();
		public void AddRecipe(Recipe r);
		public Recipe? GetRecipeById(string recipeId);
	}
}

