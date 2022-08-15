using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using InstaPrep.Data.Models;

namespace InstaPrep.Data.Scrapers
{
    class MicroData : IRecipeScraper
    {
        private List<RecipeIngredient> GetIngredients(HtmlDocument recipeDoc){
            List<RecipeIngredient> ingredientsList = new List<RecipeIngredient>();
            var ingredients = recipeDoc.DocumentNode.SelectNodes("//*[@itemprop='ingredients']");
            if (ingredients.Count == 0)
            {
                ingredients = recipeDoc.DocumentNode.SelectNodes("//*[@itemprop='recipeIngredient]");
            }

            if (ingredients.Count > 0)
            {
                ingredientsList = ingredients.Select((x) => { return new RecipeIngredient() { Title = x.InnerHtml }; }).ToList();
                return ingredientsList;
            }

            return ingredientsList;
        }

        private string GetDirections(HtmlDocument recipeDoc)
        {
            var node = recipeDoc.DocumentNode.SelectSingleNode("//*[@itemprop='recipeInstructions']");

            if(node != null)
            {
                return node.InnerHtml;
            }

            return String.Empty;
        }

        private string GetTitle(HtmlDocument recipeDoc)
        {
            var node = recipeDoc.DocumentNode.SelectSingleNode("//*[@itemprop='name']");

            if (node != null)
            {
                return node.InnerHtml;
            }

            return "";
        }

        private string GetImageUrl(HtmlDocument recipeDoc)
        {
            var node = recipeDoc.DocumentNode.SelectSingleNode("//*[@itemprop='image']");
            if(node != null)
            {
                return node.GetAttributeValue("src", "nothing");
            }
            return String.Empty;
        }

        public Recipe Scrape(HtmlDocument recipeDoc)
        {
            return new Recipe()
            {
                Title = GetTitle(recipeDoc),
                IngredientsList = GetIngredients(recipeDoc),
                ImageUrl = GetImageUrl(recipeDoc)
            };
        }
    }
}
