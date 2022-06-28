using HtmlAgilityPack;
using System;
using System.IO;
using InstaPrep.Models;
namespace InstaPrep.Data
{
    public class ScrapeIngredients
    {
        public static List<string>? GetIngredients(string filePath)
        {
            List<string> list = new List<string>();
            StreamReader reader = File.OpenText(filePath);

            HtmlDocument recipeDocument = new HtmlDocument();
            recipeDocument.Load(filePath);
            try
            {
                HtmlNode[] nodes = recipeDocument.DocumentNode.SelectNodes("//li[@class='ingredient']").ToArray();
                return nodes.Select((x) => { return x.InnerHtml; }).ToList();
            }
            catch (Exception e)
            {
                return null;
            }

        }

        private static (List<string>, int) GetsAny(string haystack, List<string> needles)
        {
            List<string> foundVals = new List<string>();
            int index = -1;
            int s_index = 0;
            string last = "";
            foreach (string needle in needles)
            {
                if ((index = haystack.IndexOf( needle+" ")) != -1)
                {
                    foundVals.Add(needle);
                    if (index > s_index)
                    {
                        s_index = index;
                        last = needle;
                    }
                    //s_index = Math.Max(index, s_index);
                }
                    
            }

            return (foundVals, s_index + last.Length);
        }

        // Gets Very last measurement and splits based on this
        // then returning an ingredient
        private static RecipeIngredient ParseIngredient(string ingredient)
        {
            if(String.IsNullOrEmpty(ingredient)){
                return new RecipeIngredient();
            }
            var ingredients = GetsAny(ingredient.ToLower(), Measurements.GetMeasurements());
            var measurements = GetsAny(ingredient.ToLower(), Measurements.GetAmounts());

            int last = Math.Max(ingredients.Item2, measurements.Item2);

            return new RecipeIngredient() { 
                Title = ingredient.Substring(ingredients.Item2),
                Measure = String.Join(" ", measurements.Item1) +  " " + String.Join(" ", ingredients.Item1)
            };
        }

        public static List<Recipe> Scrape()
        {
            var allIngredients = new List<RecipeIngredient>();
            var allRecipes = new List<Recipe>();
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    var ingredients = GetIngredients("Scrape/American/" + i.ToString() + ";" + j.ToString() + ".html");
                    if (ingredients != null)
                    {
                        allRecipes.Add(new Recipe());
                       
                        foreach (var ingredient in ingredients)
                        {
                            
                            var parsed = ParseIngredient(ingredient);
                            allIngredients.Add(parsed);
                           
                            Console.WriteLine(parsed.Title + ": " + parsed.Measure);
                        }

                        foreach(var ingredient in allIngredients)
                        {
                            ingredient.RecipeId = allRecipes.Last().Id;
                        }

                        // We place some "dummy" data here along with the list of Recipe ingredients 
                        allRecipes[allRecipes.Count - 1].IngredientsList = allIngredients;
                        allRecipes[allRecipes.Count - 1].Duration = "5 mins";
                        allRecipes[allRecipes.Count - 1].Rating = "3";
                        allRecipes[allRecipes.Count - 1].Effort = "4";

                        allIngredients = new List<RecipeIngredient>();
                    }
                }
            }

            return allRecipes;
        }
    }
}
