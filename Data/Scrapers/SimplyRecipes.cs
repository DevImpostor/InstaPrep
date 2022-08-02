using HtmlAgilityPack;
using Newtonsoft.Json.Linq;
namespace InstaPrep.Data.Scrapers
{
    public class SimplyRecipes : JsonLd
    {
        public override Recipe Scrape(HtmlDocument recipeDoc)
        {
            var node = recipeDoc.DocumentNode.SelectSingleNode("//script[@type='application/ld+json']");

            if (node == null)
            {
                return new Recipe() { Title = "No Recipe Found" };
            }

            var recipeObject = JToken.Parse(node.InnerHtml);

            Recipe r = new Recipe();

            r.IngredientsList = GetIngredients(recipeObject);
            r.Title = GetTitle(recipeObject);
            return r;

        }
    }
}
