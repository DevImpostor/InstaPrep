using Microsoft.EntityFrameworkCore.Migrations;
using InstaPrep.Data;
#nullable disable

namespace InstaPrep.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            using (var databaseContext = InstaPrepContext.CreateContext())
            {
                var recipes = ScrapeIngredients.Scrape();
                databaseContext.Recipes.AddRange(recipes);
                foreach (var recipe in recipes)
                {
                    databaseContext.RecipeIngredients.AddRange(recipe.IngredientsList);
                }
                databaseContext.SaveChanges();
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
