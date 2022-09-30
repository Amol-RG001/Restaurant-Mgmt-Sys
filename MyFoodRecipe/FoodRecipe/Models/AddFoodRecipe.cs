using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodRecipe.Models
{
    /// <summary>
    /// FoodRecipes table - store  the particular FoodRecipeId, FoodRecipeName, FoodIngredient
    /// and FoodMakingStep data in column
    /// 
    ///  #region block Navigated Properties to the Master Model to FoodSubCategory
    /// </summary>
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

        /* Not Used in v.1 code */
        //public string Image { get; set; } //adding new functionality

        //[NotMapped]
        //public IFormFile ImageUpload { get; set; }

       

        #region Navigation Properties to the Master Model - FoodSubCategory
        [Required]
        public int FoodSubCategoryId { get; set; }
        [ForeignKey(nameof(AddFoodRecipe.FoodSubCategoryId))]
        public FoodSubCategory FoodSubCategory { get; set; }
        #endregion

    }
}
