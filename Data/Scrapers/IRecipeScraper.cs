using HtmlAgilityPack;

namespace InstaPrep.Data.Scrapers
{
    public interface IRecipeScraper
    {
        public Recipe Scrape(HtmlDocument recipeDocument);
    }
}
