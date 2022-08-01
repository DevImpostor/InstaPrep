using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Newtonsoft.Json.Linq;

namespace InstaPrep.Data.Scrapers
{
    class JsonLd : IRecipeScraper
    {
        private string GetTitle(JToken token)
        {

            return token["name"].ToString();
        }

        private List<RecipeIngredient> GetIngredients(JToken token)
        {
            var ingredients = JArray.Parse(token["recipeIngredient"].ToString());
            var ing = ingredients.Children().Select((x) => { return new RecipeIngredient() { Title = x.ToString() }; });
            return ing.ToList();
        }

        private string GetDirections(JToken token)
        {
            return token["directions"].ToString();
        }

        public Recipe Scrape(HtmlDocument recipeDoc)
        {
            var node = recipeDoc.DocumentNode.SelectSingleNode("//script[@type='application/ld+json']");

            if (node == null)
            {
                return new Recipe() { Title = "No Recipe Found" };
            }

            var Json = JArray.Parse(node.InnerHtml);

            JToken recipeObject = Json.Children().Where(x => { return x["@type"].ToString() == "Recipe"; }).FirstOrDefault();
            Recipe r = new Recipe();

            r.IngredientsList = GetIngredients(recipeObject);
            r.Title = GetTitle(recipeObject);
            return r;
            
        }
    }
}
