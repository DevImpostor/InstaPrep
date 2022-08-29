using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace InstaPrep.Data
{
    public class RecipeDbService : IDataService
    {
        private readonly InstaPrepContext _context;

        /*public IEnumerable<Event> events;*/
        public RecipeDbService(InstaPrepContext context)
        {
            _context = context;
        }
        public List<Recipe> GetRecipes()
        {
            var recipes = (from r in _context.Recipes select r).ToList();

            return recipes;
        }

        public Recipe AddRecipe(Recipe r)
        {
            _context.Add(r);
            r.IngredientsList = r.IngredientsList.Select(x => { x.RecipeId = r.Id; return x; }).ToList();
            _context.AddRange(r.IngredientsList);

            _context.SaveChanges();

            return r;
        }
        public Recipe GetRecipeById(string id)
        {
            var recipe = (from r in _context.Recipes
                    where r.Id == id
                    select r).ToList()[0];

            var ingredients = (from r in _context.RecipeIngredients
                               where r.RecipeId == recipe.Id
                               select r);
            recipe.IngredientsList = ingredients.ToList();

            return recipe;
        }
    }
}
