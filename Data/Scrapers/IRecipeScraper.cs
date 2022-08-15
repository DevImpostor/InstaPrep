using HtmlAgilityPack;
using InstaPrep.Data.Models;

namespace InstaPrep.Data.Scrapers
{
    public interface IRecipeScraper
    {
        public Recipe Scrape(HtmlDocument recipeDocument);
    }
}
