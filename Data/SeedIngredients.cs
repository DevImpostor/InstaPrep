using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InstaPrep.Data
{
    public class SeedIngredients
    {
        private List<Recipe> AllRecipes { get; set; } = new List<Recipe>()
                {
                    new Recipe()
                    {
                        ImageUrl = "https://www.simplyrecipes.com/thmb/H4fqk2mwQtlil9fc2FBrUrz8zYU=/648x0/filters:no_upscale():max_bytes(150000):strip_icc()/__opt__aboutcom__coeus__resources__content_migration__simply_recipes__uploads__2007__03__salmon-moqueca-vertical-a-1600-d79c82bba5fb48c09de050fc0dbbfa6f.jpg",
                        Title = "Brazilian Salmon Stew  (Moqueca)",
                        Duration = "1-2 Hours",
                        Effort = "Easy",
                        Rating = "2",
                        IngredientsList = new List<RecipeIngredient>()
                        {
                            new RecipeIngredient()
                            {
                                Title = "Garlic",
                                Measure = "4 cloves"
                            },
                            new RecipeIngredient()
                            {
                                Title = "Lime Juice",
                                Measure = "2 tbsp"
                            },
                            new RecipeIngredient()
                            {
                                Title = "Salt",
                                Measure = "3/4 tsp"
                            }
                        }
                    },
                    new Recipe()
                    {
                        ImageUrl = "https://www.simplyrecipes.com/thmb/Cq-nXMpurSH2lkL5olkG1tIBeTE=/648x0/filters:no_upscale():max_bytes(150000):strip_icc()/__opt__aboutcom__coeus__resources__content_migration__simply_recipes__uploads__2016__07__zucchini-noodle-chicken-pesto-bowl-vertical-a-1600-51560a436ab14af087d11aad2f9d2e3e.jpg",
                        Title = "Zucchini Noodle Chicken Pesto Bowl",
                        Duration = "1 Hour",
                        Effort = "Hard",
                        Rating = "2"
                    },
                    new Recipe()
                    {
                        ImageUrl = "https://www.simplyrecipes.com/thmb/b8GgK0mUbud6yc3kLSRYPHKUVXw=/648x0/filters:no_upscale():max_bytes(150000):strip_icc()/__opt__aboutcom__coeus__resources__content_migration__simply_recipes__uploads__2020__09__Cauliflower-Bolognese-LEAD-3-fe948fa876eb4cf79e7a35d31d547d01.jpg",
                        Title = "Roasted Cauliflower and Mushroom Bolognese",
                        Duration = "1-2 Hours",
                        Effort = "Medium",
                        Rating = "2"
                    },
                    new Recipe()
                    {
                        ImageUrl = "https://www.simplyrecipes.com/thmb/aSVwF5cLIPsxTV6Shh41yTfJzQI=/736x0/filters:no_upscale():max_bytes(150000):strip_icc()/__opt__aboutcom__coeus__resources__content_migration__simply_recipes__uploads__2014__09__apple-pie-horiz-a-1800-1ffab9404eb04308a8149c7d69a52472.jpg",
                        Title = "Homemade Apple Pie",
                        Duration = "3 Hours",
                        Effort = "Hard",
                        Rating = "2"
                    }
                };
        public async Task SeedData(InstaPrepContext context)
        {
            context.Recipes?.AddRange(AllRecipes);
            await context.SaveChangesAsync();
        }
    }
}


       

