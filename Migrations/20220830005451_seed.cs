using Microsoft.EntityFrameworkCore.Migrations;
using InstaPrep.Data;
using InstaPrep.Data.Scrapers;
#nullable disable

namespace InstaPrep.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            using var databaseContext = InstaPrepContext.CreateContext();
            var recipes = new TheRecipeDepository().Seed();
            databaseContext.Recipes.AddRange(recipes);
            Dictionary<string, Ingredient> UniqueIngredients = new Dictionary<string, Ingredient>();
            foreach (var recipe in recipes)
            {
                var newIngredients = recipe.IngredientsList.Select(x =>
                {
                    var measureType = Measurements.GetMeasurementType(x.Measure);
                    return new Ingredient()
                    {
                        Name = x.Title,
                        IsVolumeMeasure = measureType.Item1,
                        IsWeightMeasure = measureType.Item2
                    };
                });

                foreach (var ingredient in newIngredients)
                {
                    if (!UniqueIngredients.ContainsKey(ingredient.Name))
                    {
                        UniqueIngredients.Add(ingredient.Name, ingredient);
                    }
                }
            }

            //Adds every unique ingredient to database
            databaseContext.AddRange(UniqueIngredients.Values);

            // Attach proper Ingredient to recipeIngredient
            // and add recipe ingredients to db
            foreach (var recipe in recipes)
            {
                var newRecipeIngredients = new List<RecipeIngredient>();
                foreach (var ingredient in recipe.IngredientsList)
                {
                    ingredient._Ingredient = UniqueIngredients[ingredient.Title];
                    ingredient.IngredientId = ingredient._Ingredient.Id;
                }

                databaseContext.AddRange(recipe.IngredientsList);
            }

            databaseContext.SaveChanges();
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
