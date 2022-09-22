using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Major_Food_Recipe.Models
{
    [Table("FoodRecipes")]
    public class AddFoodRecipe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int FoodRecipeId { get; set; }

        [Display(Name ="Recipe Name")]
        [Required(ErrorMessage ="{0} cannot be empty.")]
        [StringLength(50, ErrorMessage = "{0} cannot have more than {1} characters.")]
        public string FoodRecipeName { get; set; }

        #region Navigation Properties to the Master Model - FoodCategory
        [Required]
        public int FoodCategoryId { get; set; }
        [ForeignKey(nameof(AddFoodRecipe.FoodCategoryId))]
        public FoodCategory FoodCategory { get; set; }
        #endregion

        #region Navigation Properties to the Master Model - FoodSubCategory
        [Required]
        public int FoodSubCategoryId { get; set; }
        [ForeignKey(nameof(AddFoodRecipe.FoodSubCategoryId))]
        public FoodSubCategory FoodSubCategory { get; set; }
        #endregion

    }
}
