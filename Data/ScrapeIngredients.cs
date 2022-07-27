using HtmlAgilityPack;
using System;
using System.IO;
using InstaPrep.Data;
using System.Net;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InstaPrep.Data
{
    public class ScrapeIngredients
    {
        // .  recipeingredient row selector 
        // Get image
        /// <summary>
        /// returns a blob image from link from html
        /// </summary>
        /// <param name="recipeDocument"></param>
        /// <returns>List of ingredients as strings from html form</returns>
        /// 
        public static byte[] GetImage(HtmlDocument recipeDocument)
        {
            WebClient webClient = new WebClient();
            var imList = recipeDocument.DocumentNode.SelectNodes("//img[@class='recipe-image']").ToList();
            // imList.Where(x => x.GetAttributeValue("src", "nothing").Contains("")).GetAttributeValue("src", "nothing");
            var src = imList[1].GetAttributeValue("src", "").Substring(2);
            byte[] image = webClient.DownloadData("http://" + src);

            return image;
        }

        public static string GetImageSrc(HtmlDocument recipeDocument)
        {
            try
            {
                var image = recipeDocument.DocumentNode.SelectNodes("//img[@class='recipe-image row']").ToList();
                return image[0].GetAttributeValue("src", "nothing");
            }
            catch (Exception E)
            {
                return "";
            }
        }

        public static List<string>? GetIngredients(HtmlDocument recipeDocument)
        {
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

        private static string GetTitle(HtmlDocument recipeDocument)
        {
            return recipeDocument.DocumentNode.SelectNodes("//h3[@class='recipe-name']//a").First().InnerHtml;
        }

        private static RecipeIngredient ParseIngredient(string ingredient)
        {
            RecipeIngredient r = new RecipeIngredient();
            var list = ingredient.Split(" ").ToList();
            var measure = "";
            var amount = "";

            // ToList() because we are mutating data in this loop
            foreach (var l in list.ToList())
            {
                if (Measurements.GetMeasurements().Contains(l))
                {
                    measure = l;
                    list.Remove(l);
                }

                if (Measurements.GetAmounts().Contains(l))
                {
                    amount = l;
                    list.Remove(l);
                }
            }


            r.Measure = amount + " " + measure;
            r.Title = string.Join(" ", list);
            return r;
        }

        public static List<Recipe> Scrape()
        {
            var allIngredients = new List<RecipeIngredient>();
            var allRecipes = new List<Recipe>();


            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    StreamReader reader = File.OpenText("Scrape/American/" + i.ToString() + ";" + j.ToString() + ".html");

                    HtmlDocument recipeDocument = new HtmlDocument();
                    recipeDocument.Load(reader);

                    var ingredients = GetIngredients(recipeDocument);
                    if (ingredients != null)
                    {
                        allRecipes.Add(new Recipe());

                        foreach (var ingredient in ingredients)
                        {

                            var parsed = ParseIngredient(ingredient);
                            allIngredients.Add(parsed);

                            Console.WriteLine(parsed.Title + ": " + parsed.Measure);
                        }

                        foreach (var ingredient in allIngredients)
                        {
                            ingredient.RecipeId = allRecipes.Last().Id;
                        }


                        // We place some "dummy" data here along with the list of Recipe ingredients 
                        allRecipes[allRecipes.Count - 1].IngredientsList = allIngredients;
                        allRecipes[allRecipes.Count - 1].Duration = "5 mins";
                        allRecipes[allRecipes.Count - 1].Rating = "3";
                        allRecipes[allRecipes.Count - 1].Effort = "4";

                        allRecipes[allRecipes.Count - 1].Title = GetTitle(recipeDocument);
                        allRecipes[allRecipes.Count - 1].ImageUrl = GetImageSrc(recipeDocument);
                        allIngredients = new List<RecipeIngredient>();
                    }

                    reader.Close();
                }
            }

            return allRecipes;
        }
    }
}
