using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace InstaPrep.Data
{
	public class RecipeIngredient
	{
        [Key]
		public string Id { get; set; } = string.Empty;
		public string Title { get; set; } = string.Empty;
		public string Measure {  get; set; } = string.Empty;

        [ForeignKey(nameof(_Recipe))]
		public string RecipeId { get; set; }
		public Recipe _Recipe { get; set; }
		public RecipeIngredient()
		{
			Id = Guid.NewGuid().ToString();
		}
	}
}

