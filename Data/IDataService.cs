using InstaPrep.Data.Models;
using System;
namespace InstaPrep.Data
{
    public interface IDataService
	{
		public List<Recipe> GetRecipes();
		public Recipe AddRecipe(Recipe r);
		public Recipe? GetRecipeById(string recipeId);
	}
}

