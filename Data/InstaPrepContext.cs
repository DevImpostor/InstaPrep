using Microsoft.EntityFrameworkCore;
using InstaPrep.Data.Models;

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
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            base.OnModelCreating(modelBuilder);
        }

        internal static InstaPrepContext CreateContext()
        {
            return new InstaPrepContext(
                new DbContextOptionsBuilder<InstaPrepContext>()
                .UseSqlite($"Data Source={nameof(InstaPrepContext.InstaPrepDb)}.db").Options);
        } 

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