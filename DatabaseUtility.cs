﻿using Microsoft.EntityFrameworkCore;
using InstaPrep.Data;
namespace InstaPrep
{
    public static class DatabaseUtility
    {
        public static async Task EnsureDbCreatedAndSeedWithCountOfAsync(DbContextOptions<InstaPrepContext> options, int count)
        {
            // empty to avoid logging while inserting (otherwise will flood console)
            var factory = new LoggerFactory();
            var builder = new DbContextOptionsBuilder<InstaPrepContext>(options)
                .UseLoggerFactory(factory);
            var recipes = ScrapeIngredients.Scrape();
            using var context = new InstaPrepContext(builder.Options);
            // result is true if the database had to be created
            var seed = new SeedIngredients();
            seed.SeedData(context, recipes);

            
            if (await context.Database.EnsureCreatedAsync())
            {
                    //var seed = new SeedIngredients();
                   //seed.SeedData(context, new List<Recipe>());
            }
        }
    }
}