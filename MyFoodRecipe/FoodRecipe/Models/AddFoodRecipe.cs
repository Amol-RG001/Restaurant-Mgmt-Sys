using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodRecipe.Models
{
    [Table("FoodRecipes")]
    public class AddFoodRecipe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
         public int FoodRecipeId { get; set; }


        [Display(Name ="Recipe Name")]
        [Required, MinLength(2, ErrorMessage="Minimum length is 2")]
         public string FoodRecipeName { get; set; }


        [Display(Name ="Ingredients")]
        [Required, MinLength(2, ErrorMessage = "Minimum length is 2")]
         public string FoodIngredient { get; set; }


        [Display(Name = "How to make it?")]
        [Required,MinLength(2, ErrorMessage = "Minimum length is 2")]
        //[StringLength(350, ErrorMessage = "{0} cannot have more than {1} characters.")]
        public string FoodMakingStep { get; set; }

        public string Image { get; set; } //adding new functionality

        [NotMapped]
        public IFormFile ImageUpload { get; set; }

        /* #region Navigation Properties to the Master Model - FoodCategory
         [Required]
         public int FoodCategoryId { get; set; }
         [ForeignKey(nameof(AddFoodRecipe.FoodCategoryId))]
         public FoodCategory FoodCategory { get; set; }
         #endregion*/

        #region Navigation Properties to the Master Model - FoodSubCategory
        [Required]
        public int FoodSubCategoryId { get; set; }
        [ForeignKey(nameof(AddFoodRecipe.FoodSubCategoryId))]
        public FoodSubCategory FoodSubCategory { get; set; }
        #endregion

    }
}
