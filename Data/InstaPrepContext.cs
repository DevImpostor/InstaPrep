using Microsoft.EntityFrameworkCore;
using InstaPrep.Data;

namespace InstaPrep.Data
{
    public class InstaPrepContext : DbContext
    {
        public static readonly string InstaPrepDb = nameof(InstaPrepDb).ToLower();
        public static readonly string RowVersion = nameof(RowVersion);

        public InstaPrepContext(DbContextOptions<InstaPrepContext> options)
        : base(options)
        {
        }

        public DbSet<Recipe>? Recipes { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredient { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // this property isn't on the C# class
            // so we set it up as a "shadow" property and use it for concurrency
            modelBuilder.Entity<RecipeIngredient>()
                .Property<byte[]>(RowVersion)
                .IsRowVersion();

            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// Dispose pattern.
        /// </summary>
        public override void Dispose()
        { 
            base.Dispose();
        }

        /// <summary>
        /// Dispose pattern.
        /// </summary>
        /// <returns>A <see cref="ValueTask"/></returns>
        public override ValueTask DisposeAsync()
        {
            return base.DisposeAsync();
        }
    }
}