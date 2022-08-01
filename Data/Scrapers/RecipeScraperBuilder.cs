using System.Net;
using HtmlAgilityPack;

namespace InstaPrep.Data.Scrapers
{

    public class Scraper : IRecipeScraper
    {
        public string GetTitle() { return "abc"; }
        public string GetDescription() { return ""; }
        public string GetDirections() { return ""; }
        public List<RecipeIngredient> GetIngredients() { return new List<RecipeIngredient>(); }
        public string GetYield() { return ""; }
        public Recipe Scrape(HtmlDocument recipeDocument) { return new Recipe() { Title="abc" }; }
    }

    public class RecipeScraperBuilder
    {
        private IRecipeScraper Scraper;
        private string Url = String.Empty;
        public Recipe Result { get; }

        private Dictionary<string, string> Scrapers = new Dictionary<string, string>()
        {
            { "https://somedumbass-site.com", nameof(InstaPrep.Data.Scrapers.Scraper) },
            {"https://www.therecipedepository.com", "InstaPrep.Data.Scrapers.TheRecipeDepository"},
            {"https://www.allrecipes.com", "InstaPrep.Data.Scrapers.JsonLd" }
        };

        public RecipeScraperBuilder(string url)
        {
            string baseUrl = GetBaseUrl(url);
            Scraper = GenerateScraper(baseUrl);
            string htmlString = GetRequest(url);
            HtmlDocument recipeDocument = new HtmlDocument();
            recipeDocument.LoadHtml(htmlString);

            Result = Scraper.Scrape(recipeDocument);
        }

        private string GetBaseUrl(string url)
        {
            var uri = new Uri(url);
            string baseUrl = uri.GetLeftPart(UriPartial.Authority);
            return baseUrl;
        }

        private string GetRequest(string url)
        {
            var web = new WebClient();
            
            return web.DownloadString(url);
        }

        private IRecipeScraper GenerateScraper(string url)
        {
            Type t = Type.GetType($"{Scrapers[url]}");
            return (IRecipeScraper)Activator.CreateInstance(t);
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
        
        public string HtmlTagStripper(string html)
        {
            return String.Empty;
        }
    }
}
